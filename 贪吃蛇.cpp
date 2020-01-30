#include <stdio.h>
#include <string.h>
#include <conio.h>
#include <Windows.h>

int main()
{
	int hX = 7, hY = 7, len = 4, i = 0, map[900] = { 0 };
	char c = 'd', c1 = 'd', deaw[1801] = { 0 };
	system("mode con: cols=60 lines=30");
	srand((unsigned)malloc(1));
	for (map[rand() % 900] = -1; 1; Sleep(100))
	{
		if(_kbhit()&&(c1=_getch()))
			switch (c1)
			{
				case 'a':case 'A':if (c != 'd')c = 'a'; break;
				case 'd':case 'D':if (c != 'a')c = 'd'; break;
				case 's':case 'S':if (c != 'w')c = 's'; break;
				case 'w':case 'W':if (c != 's')c = 'w'; break;
			}
		switch (c)
		{
			case 'a':hX -= hX > 0 ? 1 : -29; break;
			case 'd':hX += hX < 29 ? 1 : -29; break;
			case 's':hY += hY < 29 ? 1 : -29; break;
			case 'w':hY -= hY > 0 ? 1 : -29; break;
		}
		if (map[hY * 30 + hX] > 1)exit(!_getch());
		if (map[hY * 30 + hX] == -1)
		{
			len++;
			do i = rand() % 900;
			while (map[i]);
			map[i] = -1;
		}
		else for (i = 0; i < 900; i++)
			if (map[i] > 0)map[i] -= 1;
		map[hY * 30 + hX] = len;
		for ( i = 0; i < 1800; i++)
		{
			if (map[i / 2] == 0)deaw[i] = ' ';
			else if (map[i / 2] > 0)deaw[i] = (i % 2) ? ')' : '(';
			else deaw[i] = '0';
		}
	//	system("cls");
		printf(deaw);
	}
}
