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
        choiceWord();                                       // Выбираем слово; 
        cout <<"Слово - ";
        while (attempt)                                    
            bodyGame();                                     
    }

    void choiceWord()                                       // Метод выбора слова;
    {
        word = w.Get_word();                      // Выбираем случайное слово из массива;
        lengthWord = word.length();                      // Записываем длинну слова в переменную;
        for (auto letter : word)
        {
            guessedLetters += '_';                       
            copyWord += letter;                           
            copyWord += ' ';                              
        }
    }
    const void printWord()                                  // Метод вывода строки с буквами на экран;
    {
        for (auto letter : guessedLetters)
            cout << letter << ' ';                    // Печатаем знаки разделяя пробелами; 
        cout << "\n\n";
    }

    void bodyGame()                                         // Метод тела игры;
    {
        int tim = 0;
        while (tim < 500)
        {
            Sleep(1000);    //задержка в 1000 миллисекунд (1 секунда)
            tim++;
        }
        printWord();                                      
        cout << "Угадайте" << next << "букву: ";
        char letter;                                    
        cin >> letter;                              

        letter = towupper(letter);                         
        string::size_type position;                  
        position =word.find(letter);                    

        if (position == string::npos)                // Если буквы в слове нет - 
        {
            mistake(letter);                                     //  запускаем обработку этого случая;
        }
        else                                               // Если буква в слове есть;
        {
            guessedLetters[position] = letter;           // Добавляем букву в строку вывода;   
                                  
            namedLetters += letter;                     
            --lengthWord;                                
            cout << "\nВерно! - ";
            if (!lengthWord)                             // Если слово разгаданно полностью;
            {
                printWord();                              
                cout << "\nПОЗДРАВЛЯЕМ!!! Вы полностью разгадали слово!\n\n";
                attempt = 0;   // Уменьшаем количество возможных ошибок  
                cout << tim << " секунд\n";
            }                                             
            next = " следующую ";
        }
        namedLetters += letter;
    }

    void mistake(wchar_t letter)                                 // Обработке неверного ответа;
    {
        if (namedLetters.find(letter) == string::npos)  
        {
            --attempt;                                        
            cout << "\nНеверно! Такой буквы нет.\n";

            switch (attempt)                                  // Формируем вывод в соответствии с
            {                                                   //   количеством воможных ошибок;   
            case 0:  
            {
                cout << "\nВы проиграли.\n\n" << picture[0] <<       
                "\nБыло загаданно слово \n\n\t" <<
                copyWord << "\n\n";    
            return;
            }
            case 1:  
            {
                cout << "Вам больше нельзя ошибаться!\n\n" <<
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
                cout << "Наверно... В следующей жизни... ";
                break;
            }
        }
        else
        {
            cout << "Вы уже называли эту букву - в "           // Если буква уже называлась;
                "неразгаданной части слова её нет.\n"
                "Попытка не засчитана, попробуйте ещё раз.\n";
        }

        cout << "\nСлово - ";
    }

     void sentence()                                   // Метод вывода картинки и сообщения;
    {
        cout << '\n' << picture[attempt] << '\n';  
       cout << "Вы можете ещё " << attempt - 1;         
        if (attempt == 2 || attempt == 6)
            cout << " раз";
        else cout << " раза";
        cout << " неверно назвать букву!\n";
    }

     array<string, 7> picture                   // Массив с псевдографикой;
    {
         "\t___________________\n\t  ||     |     ||\n\t  ||     @     ||\n"
          "\t  ||    |O|    ||\n"
          "\t  ||     П     ||\n     _____||___________||_____\n",
         "\t___________________\n\t  ||     |     ||\n\t  ||     @     ||\n"
          "\t  ||    /O\\    ||\n"
          "\t  ||    _Л_    ||\n     _____||_____П_____||_____\n",
         "\t___________________\n\t  ||     |     ||\n\t  ||     Q     ||\n"
          "\t  ||           ||\n"
          "\t  ||    ___    ||\n     _____||_____П_____||_____\n",
         "\t___________________\n\t  ||           ||\n\t  ||           ||\n"
          "\t  ||           ||\n"
          "\t  ||    ___    ||\n     _____||_____П_____||_____\n",
         "\t___________________\n\t  ||           ||\n\t  ||           ||\n"
          "\t  ||           ||\n"
          "\t  ||           ||\n     _____||___________||_____\n",
         "\t  ||           ||\n\t  ||           ||\n\t  ||           ||\n"
          "\t  ||           ||\n     _____||___________||_____\n",
         "\t  ||\n\t  ||\n\t  ||\n\t  ||\n     _____||__________________\n"
    };
};




