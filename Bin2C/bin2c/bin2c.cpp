//
// bin2c.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

//#include <ctype.h>
//#include <stdio.h>
//#include <stdlib.h>
//#include <string.h>

#include <windows.h>
#include <stdio.h>
#include <strsafe.h>
#include <malloc.h>
#include <conio.h>
#include <iostream>

//
// Creates a header file that represents the alpha mask for a bitmap (font set tyically)
// No color information is contained, only the overall intensity.
// The bitmap should be a 24 bit per pixel, non RLE windows bitmap.
// The image should be white, various gray scales, and the background black.
// Black will be mapped to a pixel value of fully transparent.
//
// Windows 24 Bit Spec:
// The 24-bit pixel (24bpp) format supports 16,777,216 distinct colors and stores 1 pixel value per 3 bytes. 
// Each pixel value defines the red, green and blue samples of the pixel (8.8.8.0.0 in RGBAX notation). 
// Specifically in the order (blue, green and red, 8-bits per each sample
//
// A 24-bit bitmap with Width=1, would have 3 bytes of data per row (blue, green, red) and 1 byte of padding,
// while Width=2 would have 2 bytes of padding, Width=3 would have 3 bytes of padding, and Width=4 would not have any padding at all.
//
// syntax:  bin2c [-c] [-z] <input_file> <output_file>
//
//          -c    add the "const" keyword to definition
//          -z    terminate the array with a zero (useful for embedded C strings)
//
// BMP Format must be 16 bits per pixel
// 

# pragma pack (1)
struct INFOHEADER
{
      unsigned short int signature;
      unsigned int size;
      unsigned short int reserved1;
      unsigned short int reserved2;
      int offset_to_start_of_image_data_in_bytes;
      int size_of_BITMAPINFOHEADER;
      int width,height;      
      unsigned short int planes;          
      unsigned short int bits;     
      unsigned int compression;    
      unsigned int imagesize;
      int xresolution,yresolution;
      unsigned int ncolours; 
      unsigned int importantcolours;
};
# pragma pack ()

// Local functions
void processFile(char * ifname);
void scanFiles(void);
 

// Arrays
#define MAX_BITMAPS			200
#define MAX_BITMAP_NAME_LEN	 50

char bmName[MAX_BITMAPS][MAX_BITMAP_NAME_LEN];
int bmXSize[MAX_BITMAPS];
int bmYSize[MAX_BITMAPS];

FILE *ifile, *ofile;

int bmCount = 0;

#ifndef PATH_MAX
#define PATH_MAX 1024
#endif
 
#define HEADER_FILE_NAME "zgResources.h\0"
#define RESOURCE_FILE_NAME "zgResources.c\0"
#define BUFSIZE 255

int useconst = 1;
int zeroterminated = 0;
 
int myfgetc(FILE *f)
{
	int c = fgetc(f);
	if (c == EOF && zeroterminated)
	{
		zeroterminated = 0;
		return 0;
	}
	return c;
}
 
void processFile(char * ifname)
{

	struct INFOHEADER bmpheader ;


	int width, height;
	LPSTR outputFile;
	size_t length_of_arg;

	outputFile = (LPSTR)malloc(BUFSIZE);

	// Input file name is the *.bmp file
	ifile = fopen(ifname, "rb");
	if (ifile == NULL)
	{
		fprintf(stderr, "cannot open %s for reading\n", ifname);
		return;
	}

	// Output file is the same base name as above, but replaced with *.c
	StringCbLength(ifname, BUFSIZE, &length_of_arg);
	StringCbCopyN(outputFile, BUFSIZE, ifname, length_of_arg - 3);
	StringCbCatN(outputFile, BUFSIZE, "c", 1);
	ofile = fopen(outputFile, "wb");
	if (ofile == NULL)
	{
		fprintf(stderr, "cannot open %s for writing\n", outputFile);
		return;
	}

	char buf[PATH_MAX], *p;
	const char *cp;

	if ((cp = strrchr(ifname, '/')) != NULL)
	{
		++cp;
	} else {
		if ((cp = strrchr(ifname, '\\')) != NULL)
			++cp;
		else
			cp = ifname;
	}
	strcpy(buf, cp);
	for (p = buf; *p != '.'; ++p)
	{
		if (!isalnum(*p))
			*p = '_';
	}

	*p = '\0';

	// File header information
	fprintf(ofile, "\n#pragma section BITMAP\n\n");
	fprintf(ofile, "const unsigned char BMP_%s[] = {\n", strupr(buf));




	int c, col = 1;
	int p1,p2, merged;
	
	
	// 
	// Print info to screen
	//
	fread(&bmpheader,sizeof(bmpheader),1,ifile);
    printf("\nImage width=%d\n",bmpheader.width);
    printf("\nImage Height=%d\n",bmpheader.height);
	printf("\nsize=%d\n",bmpheader.size);
	printf("\nstart of data=%d\n",bmpheader.offset_to_start_of_image_data_in_bytes);
	printf("\bit depth=%d\n",bmpheader.bits);


	// Store bitmap info for resource header file
	strcpy(bmName[bmCount], strupr(buf));
	bmXSize[bmCount] = bmpheader.width;
	bmYSize[bmCount] = bmpheader.height;
	bmCount++;

	
	//
	// Read file - use only the red channel
	//
	fseek(ifile,bmpheader.offset_to_start_of_image_data_in_bytes, SEEK_SET);

	// Each byte in the data structure represents two pixels

	// Get first pixel (Red)
	while ((p1 = myfgetc(ifile)) != EOF)
	{
		// Skip the Green and Blue bytes
		c = myfgetc(ifile);
		c = myfgetc(ifile);

		if (col >= 78 - 6)
		{
			fputc('\n', ofile);
			col = 1;
		}

		// Get second pixel (Red)
		if ((p2 = myfgetc(ifile)) != EOF)
		{
			// Skip the Green and Blue bytes
			c = myfgetc(ifile);
			c = myfgetc(ifile);

			// Merge the two pixels/bytes into a single byte
			merged = ((0xf0 & p2) >> 4) | (0xf0 & p1);	
	
			// Print to file
			fprintf(ofile, "0x%.2x, ", merged);
			col += 6;

		}

	}

	fprintf(ofile, "\n};\n");

	// Close output
	fclose(ifile);
	fclose(ofile);




}
 
void usage(void)
{
	fprintf(stderr, "usage: bin2c [-cz] <input_file> <output_file>\n");
	exit(1);
}
 



//
// Scan directory for files
//
void scanFiles(void)
{

	LPSTR DirSpec;
	TCHAR currentDir[255];
	size_t length_of_arg;
	WIN32_FIND_DATA FindFileData;
	HANDLE hFind = INVALID_HANDLE_VALUE;
	FILE *stream;
	FILE *outStream;
	DWORD dwError;

	DirSpec = (LPSTR)malloc(BUFSIZE);
	GetCurrentDirectory(BUFSIZE, currentDir);
	StringCbLength(currentDir, BUFSIZE, &length_of_arg);


	// Prepare string for use with FindFile functions.  First, 
	// copy the string to a buffer, then append '\*' to the 
	// directory name.
	// 
	// This scans for .c files in the *current* directory
	//
	StringCbCopyN(DirSpec, BUFSIZE, currentDir, length_of_arg + 1);
	StringCbCatN(DirSpec, BUFSIZE, "\\*.bmp", 6);
	printf("Target search %s.\n", DirSpec);

	// Find the first file in the directory.
	hFind = FindFirstFile(DirSpec, &FindFileData);

	if (hFind == INVALID_HANDLE_VALUE)
	{
		// No bitmaps found
		return;
	}
	else
	{
		// Process first file
		processFile(FindFileData.cFileName);


		// List all the other files in the directory.
		while (FindNextFile(hFind, &FindFileData) != 0)
		{

			if ((stream = fopen(FindFileData.cFileName, "r")) == NULL)
				printf("The file was not opened\n");
			else
				printf("The file was opened\n");

			// Process subsequent files
			processFile(FindFileData.cFileName);
			fclose(stream);
		}

		dwError = GetLastError();
		FindClose(hFind);

		if (dwError != ERROR_NO_MORE_FILES)
		{
			return;
		}
	}
	
}








//
// Main Entry Point
//
int main(int argc, char **argv)
{
	// Input file, Output file
	if (argc != 1)
	{
		usage();
	}
	else
	{
		// Process file
		//processFile(argv[1], argv[2]);
		scanFiles();
	}


	// Create common resource file
	// Add to header file
	ofile = fopen(HEADER_FILE_NAME, "w");

	fprintf(ofile, "// ** NOTE - THIS FILE IS AUTOMATICALLY GENERATED BY THE BMP TO C UTILITY\n\n\n");

	// Externs
	// Bitmap Info
	fprintf(ofile, "#pragma once\n");
	fprintf(ofile, "// Bitmap information\n");
	fprintf(ofile, "extern const unsigned char * zgBitmapLoc[];\n");
	fprintf(ofile, "extern const int zgBitXSize[];\n");
	fprintf(ofile, "extern const int zgBitYSize[];\n\n");

	fprintf(ofile, "// Extern for each bitmap resource\n");
	for (int i = 0; i < bmCount; i++)
	{
		fprintf(ofile, "extern const unsigned char BMP_%s[];\n", bmName[i]);
	}
	// Enums
	fprintf(ofile, "\n// Enum for each bitmap\n");
	fprintf(ofile, "typedef enum zgBitmapIndex {\n");
	for (int i = 0; i < bmCount; i++)
	{
		fprintf(ofile, "%s,\n", bmName[i]);
	}
	fprintf(ofile, "} zgBitmapIndex;\n\n");
	fclose(ofile);


	// Add to c resource  file
	ofile = fopen(RESOURCE_FILE_NAME, "w");
	fprintf(ofile, "// ** NOTE - THIS FILE IS AUTOMATICALLY GENERATED BY THE BMP TO C UTILITY\n\n");

	fprintf(ofile, "#include \"..\\resources\\zgResources.h\"\n\n");

	// Pointer to bitmap
	fprintf(ofile, "// Pointer to bitmap array\n");
	fprintf(ofile, "const unsigned char * zgBitmapLoc[] = {\n");
	for (int i = 0; i < bmCount; i++)
	{
		fprintf(ofile, "BMP_%s,\n", bmName[i]);
	}
	fprintf(ofile, "};\n\n");

	// X Size
	fprintf(ofile, "// Bitmap X Size\n");
	fprintf(ofile, "const int zgBitXSize[] = {\n");
	for (int i = 0; i < bmCount; i++)
	{
		fprintf(ofile, "%i,\n", bmXSize[i]);
	}
	fprintf(ofile, "};\n\n");

	// Y Size
	fprintf(ofile, "// Bitmap Y Size\n");
	fprintf(ofile, "const int zgBitYSize[] = {\n");
	for (int i = 0; i < bmCount; i++)
	{
		fprintf(ofile, "%i,\n", bmYSize[i]);
	}
	fprintf(ofile, "};\n\n");


	fclose(ofile);


	return 0;
}



