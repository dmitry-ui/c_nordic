#include<iostream>
#include<Windows.h>
#include<cctype> //��� ��������� ��������
using namespace std;
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	//1.������� ������� ���� � ������ ��������� ���������� �������
	char str[]="Test test TEST tesT";
	
	
	cout << "��������   ������: " << str << endl;
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
	cout << "���������� ������: " << str << endl;

	//2.������� ������� ���� � ������ ��������� ���������� ����������
	char str1[] = "Test test TEST tesT StRiNg";
	char *p;
	p = str1;

	cout << "��������   ������: " << str1 << endl;
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
	cout << "���������� ������: " << str1 << endl;

	//3.������� ������� ���� � ������ ��������� ����������  ����������
	char str2[] = "Test test TEST tesT StRiNg RuberoiD";
	char *ptr;
	ptr = str2;

	cout << "��������   ������: " << str2 << endl;
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
	cout << "���������� ������: " << str2 << endl;
	// ����� � ���:
	char str3[] = "Test test TEST tesT StRiNg RuberoiD OboRonA";
	char *ptr2;
	ptr2 = str3;

	cout << "��������   ������: " << str3 << endl;
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
	cout << "���������� ������: " << str3 << endl;




	return 0;
}