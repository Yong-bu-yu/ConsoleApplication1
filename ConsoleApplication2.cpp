// ConsoleApplication1.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include "pch.h"
#include <stdio.h>
#include <conio.h>
#include <string.h>
#include <Windows.h>
#include <tchar.h>
#include <stdlib.h>

typedef struct person                               //定义结构体  
{
	char kecheng[20];
	char laoshi[20];
	char num[20];
	char num2[20];
	char Name[20];
	char password[20];
}men;
men per[6];

void setxy(int x, int y)  //设置输入，输出的位置，也就是当前光标位置
{
	COORD coord = { x , y };
	SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coord);
}

int x()
{
	FILE *fp;
	errno_t err;
	err = fopen_s(&fp, "e:\\学生个人课表.txt", "r");
	if (fp == NULL)
		return 0;
	else
	{
		fclose(fp);
		return 1;
	}
}

void getxy(int* x, int* y) //获取当前光标位置,调用：getxy(&x,&y);
{
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
	COORD coordScreen = { 0, 0 };
	CONSOLE_SCREEN_BUFFER_INFO csbi;
	if (GetConsoleScreenBufferInfo(hConsole, &csbi))
	{
		*x = csbi.dwCursorPosition.X;
		*y = csbi.dwCursorPosition.Y;
	}
}
//要加头文件 #include "windows.h"

char *User(char a[])  //获取用户名
{
	char *str = a;
	int n;
	for (n = 0;; n++)
	{
		a[n] = getchar();
		if (a[n] == '\n')break;
	}
	a[n] = '\0';
	//	printf("%s\n", a);
	return str;
}

char *Password(char s[])   //获取密码，并使密码变成●号
{
	char *str = s;
	int n;
	for (n = 0;; n++)
	{
		s[n] = _getch();
		printf("●");
		if (s[n] == '\r')break;
	}
	s[n] = '\0';
	return str;
}

void *Change_Password(char a[])
{
	char s[20];
	FILE *fp, *fp1;
	errno_t err;
	err = fopen_s(&fp, "e\\学生信息表.txt", "r+");
	while (!feof(fp))
	{
		for (int i = 0; i < 6; i++)
			fscanf_s(fp, "%s%s", per[i].Name, 20, per[i].password, 20);
	}
	for (int i = 0; i < 6; i++)
		printf("%s %s\n\n", per[i].Name, per[i].password);
	scanf_s("%s", s, 20);
	for (int i = 0; i < 6; i++)
		if (strcmp(a, per[i].Name) == 0)
		{
			//		scanf_s("%s", s, 20);
			strcpy_s(per[i].password, s);
		}
	for (int i = 0; i < 6; i++)
		printf("\n%s %s\n", per[i].Name, per[i].password);
	fclose(fp);
	err = fopen_s(&fp1, "c:\\e\\学生信息表.txt", "w+");
	for (int i = 0; i < 6; i++)
		fprintf(fp, "%s %s\n", per[i].Name, per[i].password);
	fclose(fp1);
	return 0;
}

void UI3()  //让窗口只有叉
{
	HWND hWnd = GetConsoleWindow(); //获得cmd窗口句柄
	RECT rc;
	GetWindowRect(hWnd, &rc); //获得cmd窗口对应矩形

	//改变cmd窗口风格
	SetWindowLongPtr(hWnd,
		GWL_STYLE, GetWindowLong(hWnd, GWL_STYLE) & ~WS_THICKFRAME & ~WS_MAXIMIZEBOX & ~WS_MINIMIZEBOX);
	//因为风格涉及到边框改变，必须调用SetWindowPos，否则无效果
	SetWindowPos(hWnd,
		NULL,
		rc.left,
		rc.top,
		rc.right - rc.left, rc.bottom - rc.top,
		NULL);
}

void UI1()   //登录界面绘制
{
	char u;
	system("cls");
	setxy(50, 0);
	printf("学生选课系统");
	setxy(20, 10);
	printf("登录(S)");
	setxy(90, 10);
	printf("退出(E)\n\n\n");
	u = _getch();
	if (u == 'S' || u == 's')system("cls");
	else exit(0);
}

void UI2()   //绘制界面2
{
	system("cls");
	char c;
	void DengLu();
	void Bixiu();
	void XuanXiu();
	setxy(50, 0);
	printf("学生选课系统");
	setxy(20, 3);
	printf("返回登录界面(B)");
	setxy(40, 3);
	printf("网上选课(O)");
	setxy(60, 3);
	printf("活动报名(R)");
	setxy(80, 3);
	printf("教学质量评价(T)");
	setxy(20, 9);
	printf("信息维护(I)");
	setxy(40, 9);
	printf("信息查询(Q)");
	setxy(60, 9);
	printf("毕业论文(D)");
	setxy(80, 9);
	printf("公用信息(P)");
	printf("\n\n\n");
	c = _getch();
	switch (c)
	{
	case 'B':
	case 'b':DengLu(); break;
	case 'O':
	case 'o':
	{
		setxy(40, 5); printf("选修课(E)");
		setxy(40, 6); printf("必修课(R)");
		c = _getch();
		switch (c)
		{
		case 'E':
		case 'e':system("cls"); XuanXiu(); break;
		case 'R':
		case 'r':system("cls"); Bixiu(); break;
		default:
			break;
		}
	}break;
	case 'R':
	case 'r':
		setxy(60, 5);
		printf("暂时没有活动");
		setxy(60, 6);
		printf("返回登录界面请按M键");
		c = _getch();
		if (c == 'M' || c == 'm')
			DengLu();
		break;
	case 'T':
	case 't':
		setxy(80, 5);
		printf("暂时没有教学质量评价");
		setxy(80, 6);
		printf("返回登录界面请按M键");
		c = _getch();
		if (c == 'M' || c == 'm')
			DengLu();
		break;
	case 'I':
	case 'i':
		setxy(20, 11); printf("个人信息(P)");
		setxy(20, 12); printf("密码修改(X)");
		c = _getch();
		switch (c)
		{
		case 'P':
		case 'p':system("cls"); break;
		case 'X':
		case 'x':system("cls"); break;
		default:
			break;
		}break;
	case 'Q':
	case 'q':
		setxy(40, 11); printf("学生个人课表(S)");
		setxy(40, 12); printf("成绩查询(C)");
		c = _getch();
		switch (c)
		{
		case 'S':
		case 's':system("cls"); break;
		case 'C':
		case 'c':system("cls"); break;
		default:
			break;
		}break;
	case 'D':
	case 'd':
		setxy(60, 11);
		printf("毕业论文模板请到学校官网下载");
		setxy(60, 12);
		printf("返回登录界面请按M键");
		c = _getch();
		if (c == 'M' || c == 'm')
			DengLu();
		break;
	case 'P':
	case 'p':
		setxy(80, 10);
		printf("暂无信息");
		setxy(80, 12);
		printf("返回登录界面请按M键");
		c = _getch();
		if (c == 'M' || c == 'm')
			DengLu();
		break;
	default:
		break;
	}
	printf("\n");
	//	system("pause");
}

void Bixiu()    //必修课
{
	FILE *fp1, *fp2, *fp3;
	int i;
	errno_t err;
	err = fopen_s(&fp1, "e:\\必修课.txt", "r");
	err = fopen_s(&fp2, "e:\\教师表.txt", "r");
	err = fopen_s(&fp3, "e:\\编号.txt", "r");
	if (fp1 == NULL)
	{
		printf("请将必修课.txt放在E盘根目录下。\n"); exit(0);
	}
	else if (fp2 == NULL)
	{
		printf("请将教师表.txt放在E盘根目录下。\n"); exit(0);
	}
	else if (fp3 == NULL)
	{
		printf("编号其实手打出来也行，但考虑到后面还要用到，所以还是乖乖建文件吧，编号.txt。\n"); exit(0);
	}
	while (!feof(fp1))
	{
		for (i = 0; i < 6; i++)
			fscanf_s(fp1, "%s", per[i].kecheng, 20);
	}
	setxy(50, 1);
	printf("必修课课表");
	setxy(48, 3);
	printf("科目");
	for (i = 0; i < 6; i++)
	{
		printf("\n\n\n\t\t\t\t\t\t%s", per[i].kecheng);
	}
	while (!feof(fp2))
	{
		for (i = 0; i < 6; i++)
			fscanf_s(fp2, "%s", per[i].laoshi, 20);
	}
	setxy(72, 3);
	printf("任教老师");
	for (i = 0; i < 6; i++)
	{
		printf("\n\n\n\t\t\t\t\t\t\t\t\t%s", per[i].laoshi);
	}
	while (!feof(fp3))
	{
		for (i = 0; i < 6; i++)
			fscanf_s(fp3, "%s", per[i].num, 20);
	}
	setxy(24, 3);
	printf("编号");
	for (i = 0; i < 6; i++)
	{
		printf("\n\n\n\t\t\t%s", per[i].num);
	}
	printf("\n\n\n\n");
	setxy(32, 24);
	printf("当前课表不可修改，返回上级菜单，请按任意键");
	_getch();
	UI2();
	fclose(fp1);
	fclose(fp2);
	fclose(fp3);
}

void XuanXiu()
{
	void DengLu();
	FILE *fp1, *fp2, *fp3, *fp4;
	int i, a;
	char c;
	errno_t err;
	err = fopen_s(&fp1, "e:\\选修课.txt", "r");
	err = fopen_s(&fp2, "e:\\教师表.txt", "r");
	err = fopen_s(&fp3, "e:\\编号.txt", "r");
	err = fopen_s(&fp4, "e:\\学生个人课表.txt", "a+");
	if (fp1 == NULL)
	{
		printf("请将选修课.txt放在E盘根目录下。\n"); exit(0);
	}
	else if (fp2 == NULL)
	{
		printf("请将教师表.txt放在E盘根目录下。\n"); exit(0);
	}
	else if (fp3 == NULL)
	{
		printf("编号其实手打出来也行，但考虑到后面还要用到，所以还是乖乖建文件吧，编号.txt。\n"); exit(0);
	}
	while (!feof(fp1))
	{
		for (i = 6; i < 12; i++)
			fscanf_s(fp1, "%s", per[i].kecheng, 20);
	}
	setxy(50, 1);
	printf("选修课课表");
	setxy(48, 3);
	printf("科目");
	for (i = 6; i < 12; i++)
	{
		printf("\n\n\n\t\t\t\t\t\t%s", per[i].kecheng);
	}
	while (!feof(fp2))
	{
		for (i = 0; i < 6; i++)
			fscanf_s(fp2, "%s", per[i].laoshi, 20);
	}
	setxy(72, 3);
	printf("任教老师");
	for (i = 0; i < 6; i++)
	{
		printf("\n\n\n\t\t\t\t\t\t\t\t\t%s", per[i].laoshi);
	}
	while (!feof(fp3))
	{
		for (i = 6; i < 12; i++)
			fscanf_s(fp3, "%s", per[i].num, 20);
	}
	setxy(24, 3);
	printf("编号");
	for (i = 6; i < 12; i++)
	{
		printf("\n\n\n\t\t\t%s", per[i].num);
	}
	printf("\n\n\n\n");
	setxy(24, 25);
	printf("你要修几门课呢？\n");
	setxy(24, 26);
	scanf_s("%d", &a);
	if (a <= 0)
	{
		setxy(24, 27);
		printf("最少修1门，重新选课请按任键，退出请按E，返回登录界面请按M");
		c = _getch();
		if (c == 'E' || c == 'e')exit(0);
		else if (c == 'M' || c == 'm')DengLu();
		else
		{
			system("cls");
			XuanXiu();
		}
	}
	else
	{
		setxy(24, 27);
		printf("如要选课，请输入编号：");
		for (i = 0; i < a; i++)
		{
			scanf_s("%s", per[i].num2, 20);
		}
		int j;
		setxy(24, 28);
		printf("你选择课程有 ");
		for (i = 0; i < 6; i++)
		{
			for (j = 6; j < 12; j++)
			{
				_strupr_s(per[i].num2);
				if (strcmp(per[j].num, per[i].num2) == 0)
				{
					printf("\n\t\t\t%s ", per[j].kecheng);
					fprintf(fp4, "%s\n", per[j].kecheng);
				}
			}
		}
	}
	fclose(fp1);
	fclose(fp2);
	fclose(fp3);
	fclose(fp4);
}

void *duqu(char a[], char s[])   //实现登录功能
{
	system("cls");
	void DengLu();
	FILE *fp1, *fp2;
	errno_t err;
	int i;
	char q[20], u[20];
	err = fopen_s(&fp1, "e:\\学生信息表.txt", "r");
//	err = fopen_s(&fp2, "e:\\学生个人课表.txt", "r");
	strcpy_s(q, a);
	strcpy_s(u, s);
	if (fp1 == NULL)
	{
		printf("\n请将学生信息表.txt放在E盘根目录下。\n"); exit(0);
	}
	while (!feof(fp1))
	{
		fscanf_s(fp1, "%s%s", a, 20, s, 20);
		while (strcmp(a, q) == 0)
		{
			if (strcmp(a, q) == 0 && strcmp(s, u) == 0)
			{
				setxy(50, 20);
				printf("登录成功！");
				Sleep(600);
				system("cls");
				if (x() == 0)
				{
					err = fopen_s(&fp2, "e:\\学生个人课表.txt", "w+");
					x();
				}
				else
				{
					err = fopen_s(&fp2, "e:\\学生个人课表.txt", "r");
					if (fgetc(fp2) == 0)
					{
						fclose(fp2);
						err = fopen_s(&fp2, "e:\\学生个人课表.txt", "a");
						printf("文件为空。\n");
						fprintf(fp2, "%s\n", a);
						UI2();
					}
					else
					{
						while (!feof(fp2))
						{
							for(i=0;i<6;i++)
							fscanf_s(fp2,"e:\\学生个人课表.txt",per[i].Name);
							fclose(fp2);
						}
						if (strcmp(per[i].Name, a) == 0)
						{
							err = fopen_s(&fp2, "e:\\学生个人课表.txt", "r");
							fclose(fp2);
							for (i = 0; i < 6; i++)
								fprintf(fp2, "%s\n", per[i].Name);
							UI2();
						}
					}
				}
//				UI2();
				exit(0);
			}
			else
			{
				setxy(50, 20);
				printf("登录失败，请重新登录！");
				printf("\n");
				Sleep(600);
				DengLu();
				exit(0);
			}
		}
	}
	setxy(50, 20);
	printf("登录失败，请重新登录！");
	Sleep(600);
	DengLu();
	fclose(fp1);
	return 0;
}

void DengLu()  //实现登录
{
	char a[20], s[20];
	FILE *fp;
	errno_t err;
	err = fopen_s(&fp, "e:\\学生登录情况记录.txt", "a");
	UI1();
	setxy(50, 0);
	printf("用户名：");
	User(a);
	setxy(50, 10);
	printf("密码：");
	Password(s);
	fprintf(fp, "%s\n%s\n", a, s);
	fclose(fp);
	duqu(a, s);
}

int main()
{
	DengLu();
	//	Bixiu();
	//	XuanXiu();
}

// 运行程序: Ctrl + F5 或调试 >“开始执行(不调试)”菜单
// 调试程序: F5 或调试 >“开始调试”菜单

// 入门提示: 
//   1. 使用解决方案资源管理器窗口添加/管理文件·1 
//   2. 使用团队资源管理器窗口连接到源代码管理
//   3. 使用输出窗口查看生成输出和其他消息
//   4. 使用错误列表窗口查看错误
//   5. 转到“项目”>“添加新项”以创建新的代码文件，或转到“项目”>“添加现有项”以将现有代码文件添加到项目
//   6. 将来，若要再次打开此项目，请转到“文件”>“打开”>“项目”并选择 .sln 文件
