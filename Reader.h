#pragma once
#include<iostream>
#include<fstream>
#include"Words.h"
using namespace std;
//класс для считывания зашифрованных данных
class Reader: protected Secure			//наследуем адрес файла
{
	fstream fin;
protected:
	Words w;						//обьект в который копирует с файла
public:
	Reader()
	{
		fin.open(test,fstream::in);
		if (!fin.is_open())
		{
			cout << "\nerrorr open fail\n";
		}
		else
		{
			fin.read((char*)&w, sizeof(Words));
		}
	}
	~Reader()
	{
		fin.close();
	}
};

