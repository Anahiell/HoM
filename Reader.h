#pragma once
#include<iostream>
#include<fstream>
#include"Words.h"
using namespace std;
//����� ��� ���������� ������������� ������
class Reader: protected Secure			//��������� ����� �����
{
	fstream fin;
protected:
	Words w;						//������ � ������� �������� � �����
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

