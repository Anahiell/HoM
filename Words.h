#pragma once
#include<iostream>
#include<string>
#include<array>

using namespace std;
//������ �����
class Words
{
	string words[5];				//����� ����
public:
	Words(){}
	Words(int x)
	{
		if (x != 0)
		{
			words[0] = "PROGRAMMER";
			words[1] = "ORANG";
			words[2] = "CALIPSO";
			words[3] = "MONEY";
			words[4] = "HONEY";
		}
	}
	string Get_word()
	{
		return words[2];
		
	}
	~Words()
	{
		
	}
};
class Secure											//����� ��� ���������� ����� � �������
{
	
	fstream fout;
protected:
	string test = "Words.txt";								//���� � ������ �����
public:
	Secure()
	{
		Words base(1);
		fout.open(test,fstream::out);
		if (!fout.is_open())
		{
			cout << "\nerrorr open fail\n";
		}
		else
		{
			fout.write((char*)&base, sizeof(Words));
			fout.close();
		}
	}
	~Secure()
	{
		
	}

};
