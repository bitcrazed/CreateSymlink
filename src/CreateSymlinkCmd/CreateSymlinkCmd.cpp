// CreateSymlinkCmd.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <Windows.h>
#include <iostream>
#include <string.h>

using namespace std;

int main()
{
	const wchar_t* fileName = L"C:\\Windows\\System32\\Drivers\\Etc\\Hosts";
	
	const wchar_t* linkPath = L"C:\\Temp\\";
	const size_t linkPathLength = wcslen((wchar_t*)linkPath);

	const wchar_t* link = L"hosts.txt";
	const size_t linkLength = wcslen((wchar_t*)link);

	int linkNameSize = linkPathLength + linkLength + sizeof(wchar_t);
	wchar_t* linkName = new wchar_t[linkNameSize];
	memset(linkName, 0, linkNameSize);
	wcscpy_s(linkName, linkNameSize, linkPath);
	wcsncat_s(linkName, linkNameSize, link, linkLength);

	// Create folder for link - ignore error if it already exists.
	CreateDirectory(linkPath, NULL);

	// Delete the link if it exists.
	DeleteFile(linkName);

	int result = CreateSymbolicLink(linkName, fileName, 0);

	if (result == 0)
	{
		
		wcout << "Error: Symlink creation failed!" << endl;
	}
	else
	{
		wcout << "Symlink Created: " << linkName << " <--> " << fileName << endl;
	}

    return result;
}

