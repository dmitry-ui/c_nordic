#include<iostream>
#include<Windows.h>

using namespace std;
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	/////////////�������������� �������� � �����������/////////////////////
	//1.���������, ���������	
	int i, *p;
	p = &i;
	*p= 100;
	cout << "i=" << i << endl;
	cout << "p=" << p<<endl;
	p++;
	cout << "����� ���������� p=" << p << endl;//����� ���������� �� 4, �.�. ������� ��� int - 4 �����
	p--;
	cout << "����� ���������� p=" << p << endl;//����� ���������� �� 4, �.�. ������� ��� int - 4 �����
	//�������� �������� � ������ ������ � ������� ���������� � ���������
	int num, *p1;
	p1 = &num;
	*p1 = 100;
	cout << "num=" << num<<endl;
	(*p1)++;
	cout << "����� ���������� num=" << num<<endl;
	(*p1)--;
	cout << "����� ���������� num=" << num << endl;
	///////////////////////////////////////////////////
	//2.� ��������� ����� ���������� ��� �������� ����� �����
	
	//������
	int m[10], *pm;
	double n[10], *pn;
	pm = m;
	pn = n;

	for (int k = 0; k<10; k++)
	{
		*(pm+k) = 2*k;//����������  �������� �� ���������
		*(pn+k) = 3*k;
		cout << "k=" << k << ", m[" << k << "]=" << m[k] << ",  n[" << k << "]=" << n[k] << endl;
	}
	for (int k = 0; k<10; k++)
	{
	//����������� ��������� �� ����� �����
		cout << pm + k << "     " << pn + k << endl;

	}

	//3.�� ������ ��������� ����� �������� ������ ���������, ����� ������ ���-�� ��������� ����� ���� (���������� ��������� ������ - ��� ������)
	//����� ���������� ��, �.�. ������- ������
	//������: ������������ ������
	char s[] = "��� ������ ���� �����������.";
	char *start, *end, t;
	int len;
	len = strlen(s);
	cout << "�������� ������: " << s << endl;
	//cout << "����� ������: " << len << endl;
	start = s;
	//end = s + len-1;
	//��������� ������ ����� � ���:
	end = &s[len - 1];
	//cout <<"Start= "<< *start << endl;
	//cout <<"End= "<<*end<< endl;
	while (start < end)
	{
		t = *start;
		*start = *end;
		*end = t;
		start++;
		end--;
	}
	cout << "��������������� ������: " << s << endl;
	return 0;
}