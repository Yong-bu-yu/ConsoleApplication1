#include<stdio.h>//输入输出函数
#include<string.h>//字符串函数
#include<conio.h>//屏幕操作函数
#include<stdlib.h>//其他说明
#define MAXPV 20 //每人最大密码值为20
#define MAXNUM 30 //需要处理的最多人数为30
#define MAXFV 10 //初始查找的上限值为10

typedef int DataType;
typedef struct LinkList
{
	int data;
	int password;
	struct LinkList *next;
}LinkList;
//函数的声明
LinkList *CreatList();
void InitList(LinkList *, int);
int GetPassword();
int GetPersonNumber();
int GetFirstCountValue();
void GetOutputOrder(LinkList*, int, int, int*);
void printResult(int*, int);

//构建单链表函数
LinkList *CreatList()
{
	LinkList *L;
	L = (LinkList*)malloc(sizeof(LinkList));
	if (L==NULL)
	{
		printf("分配内存失败！");
		exit(1);
	}
	return L;
}

//初始化一个单循环链表函数
void InitList(LinkList *L, int personNumber)
{
	LinkList *p, *q;
	int i;
	p = L;
	p->data = 1;
	p->password = GetPassword();
	for ( i = 2; i <= personNumber; i++)
	{
		q = (LinkList*)malloc(sizeof(LinkList));
		if (q==NULL)
		{
			printf("分配内存空间失败！");
			exit(1);
		}
		q->password = GetPassword();
		q->data = i;
		p->next = q;
		p = q;
	}
	p->next = L;
}

//确定需要处理的人数函数
int GetPersonNumber()
{
	int personNumber;
	printf("请输入人数：");
	scanf_s("%d", &personNumber);
	while (personNumber>MAXNUM||personNumber<0)
	{
		printf("你输入的数字无效，请输入在0到%d的整数", MAXNUM);
		scanf_s("%d", &personNumber);
	}
	printf("本次求约瑟夫环的出列顺序人数为%d人：\n", personNumber);
	return personNumber;
}

//给每个人赋密码函数
int GetPassword()
{
	int password;
	static int count = 1;
	printf("请输入第%d人的密码：", count);
	scanf_s("%d", &password);
	while (password>MAXPV||password<0)
	{
		printf("您输入的数字无效，请输入在0到%d的整数：", MAXPV);
		scanf_s("%d", &password);
	}
	count++;
	return password;
}

//确定开始的上限值函数
int GetFirstValue()
{
	int firstValue;
	printf("请输入密码的上限值：");
	scanf_s("%d", &firstValue);
	while (firstValue>MAXFV||firstValue<0)
	{
		printf("\n你输入的密码数无效，请输入在0到%d的整数：", MAXFV);
		scanf_s("%d", &firstValue);
	}
	printf("最终的密码上限值为%d\n", firstValue);
	return firstValue;
}

//得到出队顺序
void GetOutputOrder(LinkList *L, int personNumber, int reportValue, int array[MAXNUM])
{
	LinkList *p, *q;
	int count = 1, i = 0;
	p = L;
	q = NULL;
	while (personNumber)
	{
		while (count!=reportValue)
		{
			q = p;
			p = p->next;
			count++;
		}
		array[i++] = p->data;
		reportValue = p->password;
		q->next = p->next;
		free(p);
		p = q->next;
		count = 1;
		personNumber--;
	}
}

//输出结果
void printResult(int array[], int personNumber)
{
	int i;
	printf("\n按每人持有的编号依次出列的顺序为：");
	for ( i = 0; i < personNumber; i++)
		printf("%-3d", array[i]);
	printf("\n");
}

int main()
{
	LinkList *L;
	int personNumber, reportValue;
	int array[MAXNUM];
	printf("约瑟夫环问题。\n");
	personNumber = GetPersonNumber();
	reportValue = GetFirstValue();
	L = CreatList();
	InitList(L, personNumber);
	GetOutputOrder(L, personNumber, reportValue, array);
	printResult(array, personNumber);
	system("pause");
	return 0;
}   
