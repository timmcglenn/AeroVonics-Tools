/***************************************************************
 * Name:      wave2c, a WAV file to GBA C source converter.
 * Purpose:   translate audio binaries into AVR memory data
 * Author:    Ino Schlaucher (ino@blushingboy.org)
 * Created:   2008-07-28
 * Copyright: Ino Schlaucher (http://blushingboy.org)
 * License:   GPLv3 (upgrading previous version)
 **************************************************************
 *
 * Based on an original piece of code by Mathieu Brethes.
 *
 * Copyright (c) 2003 by Mathieu Brethes.
 *
 * Contact : thieumsweb@free.fr
 * Website : http://thieumsweb.free.fr/
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */

#include "stdafx.h"

#include "wavdata.h"
#include <stdlib.h>
#include <string.h>

 /* Loads a wave header in memory, and checks for its validity. */
 /* returns NULL on error, a malloced() wavSound* otherwise.    */
wavSound * loadWaveHeader(FILE * fp) {
	char c[5];
	int nbRead;
	int chunkSize;
	int subChunk1Size;
	int subChunk2Size;
	short int audFormat;
	short int nbChannels;
	int sampleRate;
	int byteRate;
	short int blockAlign;
	short int bitsPerSample;
	wavSound *w;

	c[4] = 0;

	nbRead = fread(c, sizeof(char), 4, fp);

	// EOF ?
	if (nbRead < 4) return NULL;

	// Not a RIFF ?
	if (strcmp(c, "RIFF") != 0) {
		printf("Not a RIFF: %s\n", c);
		return NULL;
	}

	nbRead = fread(&chunkSize, sizeof(int), 1, fp);

	// EOF ?
	if (nbRead < 1) return NULL;

	nbRead = fread(c, sizeof(char), 4, fp);

	// EOF ?
	if (nbRead < 4) return NULL;

	// Not a WAVE riff ?
	if (strcmp(c, "WAVE") != 0) {
		printf("Not a WAVE: %s\n", c);
		return NULL;
	}

	nbRead = fread(c, sizeof(char), 4, fp);

	// EOF ?
	if (nbRead < 4) return NULL;

	// Not a "fmt " subchunk ?
	if (strcmp(c, "fmt ") != 0) {
		printf("No fmt subchunk: %s\n", c);
		return NULL;
	}

	// read size of chunk.
	nbRead = fread(&subChunk1Size, sizeof(int), 1, fp);
	if (nbRead < 1) return NULL;

	//// is it a PCM ?
	//if (subChunk1Size != 18) {
	//	printf("Not PCM fmt chunk size: %x\n", subChunk1Size);
	//	return NULL;
	//}

	nbRead = fread(&audFormat, sizeof(short int), 1, fp);
	if (nbRead < 1) return NULL;

	// is it PCM ?
	if (audFormat != 1) {
		printf("No PCM format (1): %x\n", audFormat);
		return NULL;
	}

	nbRead = fread(&nbChannels, sizeof(short int), 1, fp);
	if (nbRead < 1) return NULL;

	// is it mono or stereo ?
	if (nbChannels > 2 || nbChannels < 1) {
		printf("Number of channels invalid: %x\n", nbChannels);
		return NULL;
	}

	nbRead = fread(&sampleRate, sizeof(int), 1, fp);
	if (nbRead < 1) return NULL;

	nbRead = fread(&byteRate, sizeof(int), 1, fp);
	if (nbRead < 1) return NULL;

	nbRead = fread(&blockAlign, sizeof(short int), 1, fp);
	if (nbRead < 1) return NULL;

	nbRead = fread(&bitsPerSample, sizeof(short int), 1, fp);
	if (nbRead < 1) return NULL;

		
	//
	// Align using the "DATA" text - some wav files are 2 bytes different
	//
	nbRead = fread(c, sizeof(char), 2, fp);
	c[2] = 0;
	if (strcmp(c, "da") != 0) {
		nbRead = fread(c, sizeof(char), 4, fp);
	}
	else
	{
		nbRead = fread(c, sizeof(char), 2, fp);
	}


	nbRead = fread(&subChunk2Size, sizeof(int), 1, fp);
	if (nbRead < 1) return NULL;

	// Now we can generate the structure...

	w = (wavSound *)malloc(sizeof(wavSound));
	// out of memory ?
	if (w == NULL) {
		printf("Out of memory, sorry\n");
		return w;
	}

	w->sampleRate = sampleRate;
	w->numChannels = nbChannels;
	w->bitsPerSample = bitsPerSample;
	w->dataLength = subChunk2Size;

	return w;
}

/* Loads the actual wave data into the data structure. */
void saveWave(FILE * fpI, wavSound *s, FILE * fpO, char * name) {
	saveWave_(fpI, s, fpO, name, -1);
}
void saveWave_(FILE * fpI, wavSound *s, FILE * fpO, char * name, int MaxSamples) {
	long filepos;
	int i;
	int realLength, auxLength;
	unsigned char stuff8;
	signed short stuff16;
	int actualCount = 0;
	int zeroCount = 100;
	int max = 0;
	int min = 4096;
	int lastValue = 0;

	filepos = ftell(fpI);

	/* Print general information) */
	fprintf(fpO, "// \n");
	fprintf(fpO, "// Sample Rate = %d \n", s->sampleRate);
	fprintf(fpO, "// Num Channels = %d \n", s->numChannels);
	fprintf(fpO, "// Bits Per Sample = %d \n", s->bitsPerSample);
	fprintf(fpO, "// Data Length = %d \n", s->dataLength);
	fprintf(fpO, "// \n");

	realLength = (s->dataLength / s->numChannels / (s->bitsPerSample / 8));
	if (MaxSamples != -1 && realLength > MaxSamples)
		realLength = MaxSamples;

	fprintf(fpO, "const signed short %s[]= {", name);
	for (i = 0; i < realLength; i++) {

		// Convert from signed 16 bit to unsigned 12 bit, 0 to 4096, center at 2048
		float raw;
		int temp;
		int cread;


		cread = fread(&stuff16, sizeof(signed short), 1, fpI);

		if (cread == 0)
			break;

		// Process the data point
		raw = (float)stuff16;
		
		// Apply Volume
		raw *= 2.1;
		
		// Clip it
		temp = (int)raw;
		if (temp > 32768)
			temp = 32768;
		if (temp < -32768)
			temp = -32768;
		
		// Offset to all positive
		temp += 32768;
		
		// Scale from 16 bits to 12 bits - moves center to 2048
		temp /= 16;

		// Find peaks
		if (temp > max) max = temp;
		if (temp < min) min = temp;

		// Eliminate any dead space, mostly at front and end of sound
//		if (temp == 2048) zeroCount++; else zeroCount = 0;
		if (temp == lastValue) zeroCount++; else zeroCount = 0;
		// Only output if non-zero
		if (zeroCount < 50)
		{
			fprintf(fpO, "%d, ", (unsigned short)(temp));
			actualCount++;
			if ((actualCount % 20) == 0) fprintf(fpO, "\n");
		}
		lastValue = temp;
		// read right output and forget about it
		fread(&stuff16, sizeof(signed short), 1, fpI);
	}
	fprintf(fpO, "};\n\n");
	fprintf(fpO, "const int %s_LEN = %d;\n\n", name, actualCount);

	// Peaks
	fprintf(fpO, "// Max Peak = %d, Min Peak = %d \n", max, min);

}




