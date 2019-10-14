#include<stdio.h>
typedef int DataType;
typedef struct linknode
{
	DataType data;
	struct linknode *next;
}LinkList;

LinkList *InitList()
{
	LinkList *head;
	head = (LinkList*)malloc(sizeof(LinkList));
	head->next = NULL;
	return head;
}

void CreateListH(LinkList *head, int n)
{
	LinkList *s;
	int i;
	printf("请输入%d个整数：", n);
	for ( i = 0; i < n; i++)
	{
		s = (LinkList*)malloc(sizeof(LinkList));
		scanf_s("%d", &s->data);
		s->next = head->next;
		head->next = s;
	}
	printf("建立链表操作成功！");
}

void CreateListL(LinkList *head, int n)
{
	LinkList *s, *last;
	int i;
	last = head;
	printf("请输入%d个整数：", n);
	for ( i = 0; i < n; i++)
	{
		s = (LinkList*)malloc(sizeof(LinkList));
		scanf_s("%d", &s->data);
		s->next = NULL;
		last->next = s;
		last = s;
	}
	printf("建立链表操作成功！");
}

int LengthList(LinkList *head)
{
	LinkList *p = head->next;
	int j = 0;
	while (p!=NULL)
	{
		p = p->next;
		j++;
	}
	return j;
}

void Locate(LinkList *head, DataType x)
{
	int j = 1;
	LinkList *p;
	p = head->next;
	while (p!=NULL&&p->data!=x)
	{
		p = p->next;
		j++;
	}
	if (p != NULL)
		printf("在表的第%d位找到值为%d的结点！", j, x);
	else
		printf("未找到值为%d的结点！", x);
}

void SearchList(LinkList *head, int i)
{
	LinkList *p;
	int j = 0;
	p = head;
	if (i > LengthList(head))
		printf("位置错误，链表中没有该位置！");
	while (p->next!=NULL&&j<i)
	{
		p = p->next;
		j++;
	}
	if (j == i)
		printf("在第%d位上的元素值为%d！", i, p->data);
}

void InsList(LinkList *head, int i, DataType x)
{
	int j = 0;
	LinkList *p, *s;
	p = head;
	while (p->next!=NULL&&j<i-1)
	{
		p = p->next;
		j++;
	}
	if (p != NULL)
	{
		s = (LinkList*)malloc(sizeof(LinkList));
		s->data = x;
		s->next = p->next;
		p->next = s;
		printf("插入元素成功！");
	}
	else
		printf("插入元素失败");
}

void DelList(LinkList *head, int i)
{
	int j = 0;
	DataType x;
	LinkList *p = head, *s;
	while (p->next!=NULL&&j<i-1)
	{
		p = p->next;
		j++;
	}
	if (p->next != NULL&&j == i - 1)
	{
		s = p->next;
		x = s->data;
		p->next = s->next;
		free(s);
		printf("删除第%d位上的元素%d成功！", i, x);
	}
	else
		printf("删除结点位置错误，删除失败！");
}

void DispList(LinkList *head)
{
	LinkList *p;
	p = head->next;
	while (p!=NULL)
	{
		printf("%5d", p->data);
		p = p->next;
	}
}

void Menu()
{
	printf("\n\t\t\t\t单链表的各种操作");
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

int main()
{
	LinkList L;
	DataType x;
	int n, i, loc;
	char ch1, ch2, a;
	ch1 = 'y';
	while (ch1 == 'y' || ch1 == 'Y')
	{
		Menu();
		scanf_s("%c", &ch2);
		getchar();
		switch (ch2)
		{
		case '1':
			InitList();
			printf("请输入建立线性表的个数：");
			scanf_s("%d", &n);
			CreateListL(&L, n);
			printf("建立的线性表为：");
			DispList(&L);
			break;
		case '2':
			printf("请输入要插入的位置：");
			scanf_s("%d", &i);
			printf("请输入要插入的元素值：");
			scanf_s("%d", &x);
			InsList(&L, i, x);
				printf("已成功在第%d的位置上插入%d，插入后的线性表为：\n", i, x);
				DispList(&L);
			break;
		case '3':
			printf("请输入要删除元素的位置：");
			scanf_s("%d", &i);
			DelList(&L, i);
				DispList(&L);
			break;
		case '4':
			printf("请输入要查看表中元素位置（从1开始）：");
			scanf_s("%d", &i);
			SearchList(&L, i);
			break;
		case '5':
			printf("请输入要查找的元素值为：");
			scanf_s("%d", &x);
			Locate(&L, x);
			break;
		case '6':
			printf("长度为%d",LengthList(&L));
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
}
