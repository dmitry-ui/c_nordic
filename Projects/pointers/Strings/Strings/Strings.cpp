#include<iostream>
#include<Windows.h>
using namespace std;
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	char m[]="Hi black trinitron. ���� ��� � �������.";
	char *p;
	p = m;
	cout << p <<endl;


	return 0;
}