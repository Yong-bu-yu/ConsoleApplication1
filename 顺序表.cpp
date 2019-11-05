// one.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include<list>

void Menu()
{
	printf("\n\t\t\t\t顺序表的各种操作");
	printf("\n\t\t=================================================");
	printf("\n\t\t|\t\t1——建立顺序表\t\t\t|");
	printf("\n\t\t|\t\t2——插入元素\t\t\t|");
	printf("\n\t\t|\t\t3——删除元素\t\t\t|");
	printf("\n\t\t|\t\t4——按位置查找元素\t\t|");
	printf("\n\t\t|\t\t5——按元素值查找其在表中位置\t|");
	printf("\n\t\t|\t\t6——求顺序表的长度\t\t|");
	printf("\n\t\t|\t\t0——返回\t\t\t|");
	printf("\n\t\t=================================================\n");
	printf("\t\t请输入菜单号（0-6）：");
}
int _tmain(int argc, _TCHAR* argv[])
{
	std::list<int>List;
	std::list<int>::iterator j;
	int n, i, loc=0, x;
	char ch1, ch2, a;
	ch1 = 'y';
	while(ch1=='y'||ch1=='Y')
	{
		Menu();
		scanf_s("%c", &ch2);
		getchar();
		switch(ch2)
		{
			case '1':
			printf("请输入建立线性表的个数：");
			scanf_s("%d", &n);
			printf("请输入元素：");
			for(int k=0;k<n;k++)
			{
				scanf_s("%d",&i);
				List.push_back(i);
			}
			printf("建立的线性表为：");
			for(j=List.begin();j!=List.end();j++)
				printf("%d ",*j);
			break;
			case '2':
			printf("请输入要插入的位置：");
			scanf_s("%d", &i);
			printf("请输入要插入的元素值：");
			scanf_s("%d", &x);
			for(int k=0;k<=i;k++)
			{
				j=List.begin();
				j++;
			}
			List.insert(j,1,x);
			printf("已成功在第%d的位置上插入%d，插入后的线性表为：\n", i, x);
			for(j=List.begin();j!=List.end();j++)
				printf("%d ",*j);
			break;
			case '3':
				printf("请输入要删除的元素：");
			scanf_s("%d", &i);
			List.remove(i);
			printf("已成功删除，删除后的线性表为：\n");
				for(j=List.begin();j!=List.end();j++)
				printf("%d ",*j);
						break;
			case '4':
				printf("请输入要查找元素的位置：");
				scanf_s("%d", &i);
				for(int k=0;k<i;k++)
				{
					j=List.begin();
					j++;
				}
				printf("查找元素值为%d的位置为：%d",i,*j);
				break;
			case '5':
				printf("请输入要查找的元素：");
				scanf_s("%d", &i);
			for(j=List.begin();j!=List.end();j++,loc++)
				if(*j==i)
					printf("当前线性表%d元素在%d上", i, loc);
				break;
			case '6':
				printf("当前线性表的长度为%d", List.size());
				break;
				case '0':
			ch1 = 'n';
			break;
		default:
			printf("输入有误，请输入0-6进行选择");
			break;
		}
		if (ch2 != '0')
		{
			printf("\n按回车键继续，按任意键返回主菜单\n");
			a = getchar();
			if (a != '\xA')
			{
				getchar();
				ch1 = 'n';
			}
		}
	}
	return 0;
}

