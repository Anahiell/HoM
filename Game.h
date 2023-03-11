#pragma once
#include"Reader.h"
#include<Windows.h>
using namespace std;

class Game : protected Reader
{
    string word;                               
    string copyWord;                           
    string namedLetters;                      
    string guessedLetters;
    string next;                              
    int attempt{6};                                    
    int lengthWord;                                
public:
    Game()
    {
        choiceWord();                                       // �������� �����; 
        cout <<"����� - ";
        while (attempt)                                    
            bodyGame();                                     
    }

    void choiceWord()                                       // ����� ������ �����;
    {
        word = w.Get_word();                      // �������� ��������� ����� �� �������;
        lengthWord = word.length();                      // ���������� ������ ����� � ����������;
        for (auto letter : word)
        {
            guessedLetters += '_';                       
            copyWord += letter;                           
            copyWord += ' ';                              
        }
    }
    const void printWord()                                  // ����� ������ ������ � ������� �� �����;
    {
        for (auto letter : guessedLetters)
            cout << letter << ' ';                    // �������� ����� �������� ���������; 
        cout << "\n\n";
    }

    void bodyGame()                                         // ����� ���� ����;
    {
        int tim = 0;
        while (tim < 500)
        {
            Sleep(1000);    //�������� � 1000 ����������� (1 �������)
            tim++;
        }
        printWord();                                      
        cout << "��������" << next << "�����: ";
        char letter;                                    
        cin >> letter;                              

        letter = towupper(letter);                         
        string::size_type position;                  
        position =word.find(letter);                    

        if (position == string::npos)                // ���� ����� � ����� ��� - 
        {
            mistake(letter);                                     //  ��������� ��������� ����� ������;
        }
        else                                               // ���� ����� � ����� ����;
        {
            guessedLetters[position] = letter;           // ��������� ����� � ������ ������;   
                                  
            namedLetters += letter;                     
            --lengthWord;                                
            cout << "\n�����! - ";
            if (!lengthWord)                             // ���� ����� ���������� ���������;
            {
                printWord();                              
                cout << "\n�����������!!! �� ��������� ��������� �����!\n\n";
                attempt = 0;   // ��������� ���������� ��������� ������  
                cout << tim << " ������\n";
            }                                             
            next = " ��������� ";
        }
        namedLetters += letter;
    }

    void mistake(wchar_t letter)                                 // ��������� ��������� ������;
    {
        if (namedLetters.find(letter) == string::npos)  
        {
            --attempt;                                        
            cout << "\n�������! ����� ����� ���.\n";

            switch (attempt)                                  // ��������� ����� � ������������ �
            {                                                   //   ����������� �������� ������;   
            case 0:  
            {
                cout << "\n�� ���������.\n\n" << picture[0] <<       
                "\n���� ��������� ����� \n\n\t" <<
                copyWord << "\n\n";    
            return;
            }
            case 1:  
            {
                cout << "��� ������ ������ ���������!\n\n" <<
                picture[1];
                sentence();
                break;
            }
            case 2:
            {
                picture[2];
                sentence();
                break;
            }
            case 3:
            {
                picture[3];
                sentence();
                break;
            }
            case 4:
            {
                picture[4];
                sentence();
                break;
            }
            case 5:
            {
                picture[5];
                sentence();
                break;
            }
            case 6: 
            {
                picture[6];
                sentence();                            
            break;
            }
            default:
                cout << "�������... � ��������� �����... ";
                break;
            }
        }
        else
        {
            cout << "�� ��� �������� ��� ����� - � "           // ���� ����� ��� ����������;
                "������������� ����� ����� � ���.\n"
                "������� �� ���������, ���������� ��� ���.\n";
        }

        cout << "\n����� - ";
    }

     void sentence()                                   // ����� ������ �������� � ���������;
    {
        cout << '\n' << picture[attempt] << '\n';  
       cout << "�� ������ ��� " << attempt - 1;         
        if (attempt == 2 || attempt == 6)
            cout << " ���";
        else cout << " ����";
        cout << " ������� ������� �����!\n";
    }

     array<string, 7> picture                   // ������ � ��������������;
    {
         "\t___________________\n\t  ||     |     ||\n\t  ||     @     ||\n"
          "\t  ||    |O|    ||\n"
          "\t  ||     �     ||\n     _____||___________||_____\n",
         "\t___________________\n\t  ||     |     ||\n\t  ||     @     ||\n"
          "\t  ||    /O\\    ||\n"
          "\t  ||    _�_    ||\n     _____||_____�_____||_____\n",
         "\t___________________\n\t  ||     |     ||\n\t  ||     Q     ||\n"
          "\t  ||           ||\n"
          "\t  ||    ___    ||\n     _____||_____�_____||_____\n",
         "\t___________________\n\t  ||           ||\n\t  ||           ||\n"
          "\t  ||           ||\n"
          "\t  ||    ___    ||\n     _____||_____�_____||_____\n",
         "\t___________________\n\t  ||           ||\n\t  ||           ||\n"
          "\t  ||           ||\n"
          "\t  ||           ||\n     _____||___________||_____\n",
         "\t  ||           ||\n\t  ||           ||\n\t  ||           ||\n"
          "\t  ||           ||\n     _____||___________||_____\n",
         "\t  ||\n\t  ||\n\t  ||\n\t  ||\n     _____||__________________\n"
    };
};




