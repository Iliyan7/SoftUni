#include <iostream>
#include <iomanip>
#include <sstream>
using namespace std;

string * GetAvgHexColors(const string arr1[], const string arr2[])
{
	string * avgHexArr = new string[3];

	for (size_t i = 0; i < 3; i++)
	{
		istringstream firstHexStream(arr1[i]);
		istringstream secondHexStream(arr2[i]);

		int rgb1, rgb2;
		firstHexStream >> hex >> rgb1;
		secondHexStream >> hex >> rgb2;

		ostringstream avgHexStream;
		avgHexStream << setfill('0') << setw(2) << hex << ((rgb1 + rgb2) / 2);

		avgHexArr[i] = avgHexStream.str();
	}

	return avgHexArr;
}

int main()
{
	string firstHexColor, secondHexColor;
	cin >> firstHexColor >> secondHexColor;

	string firstHexArr[3], secondHexArr[3];

	for (size_t i = 1, j = 0; i < 7; i += 2, j++)
	{
		firstHexArr[j] = firstHexColor.substr(i, 2);
		secondHexArr[j] = secondHexColor.substr(i, 2);
	}

	string * avgHexArr = GetAvgHexColors(firstHexArr, secondHexArr);

	cout << "#";
	for (size_t i = 0; i < 3; i++)
	{
		cout << avgHexArr[i];
	}
	cout << endl;

	delete[] avgHexArr;

	return 0;
}