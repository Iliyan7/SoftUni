#include <iostream>
#include <string>
#include <vector>
using namespace std;

vector<string> GetWords(string &text)
{
	text.append(".");

	int startIndex = 0, count = 0;
	char separators[] = { '.', ',', ';', '!', '?', ' ' };
	vector<string> arr;

	for (size_t i = 0; i < text.length(); i++)
	{
		for (size_t j = 0; j < 6; j++)
		{
			if (text[i] == separators[j])
			{
				count = i - startIndex;
				arr.push_back(text.substr(startIndex, count));
				startIndex = i + 1;
			}
		}
	}

	return arr;
}

bool IsSameLen(const string w1, const string w2)
{
	if (w1.length() == w2.length())
		return true;

	return false;
}

bool StartWithSameLetter(const char c1, const char c2)
{
	if (c1 == c2)
		return true;

	return false;
}

bool MatchWithMinPercent(const string w1, const string w2, const int minPercent)
{
	int totalLetters = w1.length();
	int matchedLetters = 0;

	for (size_t i = 0; i < totalLetters; i++)
	{
		if (w1[i] == w2[i])
			matchedLetters++;
	}

	float matchedPercent = 100 / (totalLetters / (float)matchedLetters);

	if (matchedPercent >= minPercent)
		return true;

	return false;
}

int main()
{
	string text;
	getline(cin, text);

	vector<string> words = GetWords(text);

	string word;
	cin >> word;

	int percent;
	cin >> percent;

	int count = 0;

	for (size_t i = 0; i < words.size(); i++)
	{
		if (IsSameLen(word, words[i])
			&& StartWithSameLetter(word[0], words[i][0])
			&& MatchWithMinPercent(word, words[i], percent))
			count++;
	}

	cout << count << endl;;

	return 0;
}