#include<iostream>
#include<Windows.h>
#include<cctype> //дл€ сравнени€ символов
using namespace std;
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	//1.»зменим регистр букв в строке использу€ индексацию массива
	char str[]="Test test TEST tesT";
	
	
	cout << "»сходна€   строка: " << str << endl;
	for ( int i = 0; str[i]; i++)
	{
		if (islower(str[i]))
		{
			str[i] = toupper(str[i]);
		}
		else
			if (isupper(str[i]))
			{
				str[i] = tolower(str[i]);
			}
		  
	}
	cout << "»змененна€ строка: " << str << endl;

	//2.»зменим регистр букв в строке использу€ арифметику указателей
	char str1[] = "Test test TEST tesT StRiNg";
	char *p;
	p = str1;

	cout << "»сходна€   строка: " << str1 << endl;
	while (*p)
	{
		if (islower(*p))
		{
			*p = toupper(*p);
		}
		else
			if (isupper(*p))
			{
				*p = tolower(*p);
			}
		p++;
	}
	cout << "»змененна€ строка: " << str1 << endl;

	//3.»зменим регистр букв в строке использу€ индексацию  указателей
	char str2[] = "Test test TEST tesT StRiNg RuberoiD";
	char *ptr;
	ptr = str2;

	cout << "»сходна€   строка: " << str2 << endl;
	for (int i = 0; ptr[i]; i++)
	{
		if (islower(ptr[i]))
		{
			ptr[i] = toupper(ptr[i]);
		}
		else
			if (isupper(ptr[i]))
			{
				ptr[i] = tolower(ptr[i]);
			}

	}
	cout << "»змененна€ строка: " << str2 << endl;
	// можно и так:
	char str3[] = "Test test TEST tesT StRiNg RuberoiD OboRonA";
	char *ptr2;
	ptr2 = str3;

	cout << "»сходна€   строка: " << str3 << endl;
	for (int i = 0; *(ptr2+i); i++)
	{
		if (islower(*(ptr2 + i)))
		{
			*(ptr2 + i) = toupper(*(ptr2 + i));
		}
		else
			if (isupper(*(ptr2 + i)))
			{
				*(ptr2 + i) = tolower(*(ptr2 + i));
			}

	}
	cout << "»змененна€ строка: " << str3 << endl;




	return 0;
}