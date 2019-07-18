#include <iostream>
#include <cstdio>
#include <Windows.h>

using namespace std;
int main()
{
	char m[80];
	char *p, *start, *end;
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	cout << "¬ведите строку:\n";
	gets_s(m);  //считываемв массив строку
	
	
	start= p = m;
	cout << m<<endl;
	end = strlen(p)+start-1;
	//cout << end<<endl;
	while (start < end)
	{
		char t;
		t = *start;
		*start = *end;
		*end = t;
		start++;
		end--;

	}
	cout << m << endl;
	return 0;
}