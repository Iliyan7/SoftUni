#include<iostream>
using namespace std;

void Delete2DArray(char **arr, const int len)
{
	for (size_t i = 0; i < len; i++)
	{
		delete[] arr[i];
	}

	delete[] arr;
}

int main()
{
	int r, c;
	cin >> r >> c;

	const int a = 10;

	char ** matrix = new char * [r];
	for (size_t i = 0; i < r; i++)
	{
		matrix[i] = new char[c];
	}

	for (size_t i = 0; i < r; i++)
	{
		for (size_t j = 0; j < c; j++)
		{
			cin >> matrix[i][j];
		}
	}

	char fillChar;
	cin >> fillChar;

	int startRow, startCol;
	cin >> startRow >> startCol;

	// fill matrix code
	char startChar = matrix[startRow][startCol];

	/*for (size_t i = 0; i < r; i++)
	{
		for (size_t j = 0; j < c; j++)
		{
			if (startChar == matrix[i][j])
			{
				cout << fillChar;
			}
			else
			{
				cout << matrix[i][j];
			}
		}
		cout << endl;
	}*/
	
	/*int i = startRow, j = startCol;
	while (true)
	{
		if (matrix[i][j] == startChar)
		{

		}
	}*/

	return 0;
}