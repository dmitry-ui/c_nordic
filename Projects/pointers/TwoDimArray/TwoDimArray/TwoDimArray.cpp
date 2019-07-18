#include<iostream>
#include<cstring>
#include<cstdio>
#include<Windows.h>
using namespace std;
int main()
{
	//телефонный справочник
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	int i;
	char name[80],quit;
	char numbers[8][80] =
	{
		"Дима"
		,"89852770992"
		,"Ната"
		,"89852771619"
		,"Паша"
		,"99999999999"
		,"Саша"
		,"66666666666"
	};
	
	
	cout << "Телефонный справочник\n"; 
	do
	{
		cout << "Введите имя: ";
		cin >> name;
		for (i = 0; i<8; i += 2)
		{
			if (!strcmp(numbers[i], name))
			{
				cout << "Телефон:  " << numbers[i + 1] << endl;
				break;
			}
		}
		if (i == 8) cout << "Не найдено.\n";
		cout << "Выйти (y/n)\n";
		cin >> quit;
	} while (quit!='y' or quit != 'Y');
	    

	/*
	int a[5] = { 1,2,3,4 };
	cout << a[0]<<a[1]<<a[2]<<a[3]<<a[4] <<endl;
	////////////////
	char Mych[7] = "Строка";
	cout << Mych << endl;
	////////////////
	char TowD[3][2] = {'q','w','e','r','t','y'};
	for(int i=0;i<3;++i)
		for(int j=0;j<2;++j)
		{ 
			cout << TowD[i][j];
		}
	cout << endl;
	///////////////
	char TowD1[3][2] = { {'a','s'},{'d','f'},{'g','h'}};
	for (int i = 0; i<3; ++i)
		for (int j = 0; j<2; ++j)
		{
			cout << TowD1[i][j];
		}
	cout << endl;
	*/
	///////////////
	//char a = 'a', s = 's', d = 'd', f = 'f', g = 'g', h = 'h';
	//char *TowD2[3][2] = { { &a,&s },{ &d, &f },{ &g, &h } };
	//char *TowD2[3][2] = {{"a","s"},{"d","f"},{"g","h"}};
	//char *TowD2[3][2] = {{"aa","ss"},{"dd","ff"},{"gg","hh"}};
	//char TowD2[3][2] = { { 'a','s' },{ 'd', 'f' },{ 'g', 'h' } };
	//cout << "Введите последний символ:\n";
	//gets_s(TowD2[2]);
	/*for (int i = 0; i<3; ++i)
		for (int j = 0; j<2; ++j)
		{
			cout << *TowD2[i][j];
		}
	cout << endl;
	*/





	return 0;
}