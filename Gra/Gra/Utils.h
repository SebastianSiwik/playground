#pragma once
#include <string>
#include <vector>
#include <algorithm>

class Utils {

public:
	/*
	split a string and store substrings in strings vector
	returns the size of the vector
	*/
	static unsigned int split(const std::string &txt, std::vector<std::string> &strings, char ch) {
		int pos = txt.find(ch);
		int initPos = 0;
		strings.clear();
		while (pos != std::string::npos) {
			strings.push_back(txt.substr(initPos, pos - initPos + 1));
			initPos = pos + 1;

			pos = txt.find(ch, initPos);
		}
		//adds the last one
		strings.push_back(txt.substr(initPos, std::min<int>(pos, txt.size() - (initPos + 1))));

		return strings.size();
	}

};