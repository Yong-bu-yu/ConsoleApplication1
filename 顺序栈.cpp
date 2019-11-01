#include<stdio.h>//输入输出函数
#include<string.h>//字符串函数
#include<conio.h>//屏幕操作函数
#include<stdlib.h>//其他说明

//顺序栈存储空间的总分配量
#define MAXLEN 100
//定义DataType为int类型
#define DataType int
typedef struct
{
	//存放顺序栈的数组
	DataType data[MAXLEN];
	//记录栈顶元素位置的变量
	int top;
}
//顺序栈存储类型
SeqStack;

//初始化栈函数
void InitStack(SeqStack *S)
{
	//初始化的顺序栈为空
	S->top = -1;
}

//判断栈空函数
int EmptyStack(SeqStack *S)
{
	//栈为空
	if (S->top == -1)
		return 1;
	else
		return 0;
}

//判断栈满函数
int FullStack(SeqStack *S)
{
	//栈为空
	if (S->top == MAXLEN - 1)
		return 1;
	else
		return 0;
}

//进栈操作函数
int Push(SeqStack *S, DataType x)
{
	//调用判断函数FullStack(S)，判断是否为满
	if (FullStack(S))
	{
		printf("栈满，不能进栈！");
		return 0;//栈满不能进栈
	}
	else
	{
		S->top++;
		S->data[S->top] = x;
		return 1;
	}
}

//出栈操作函数
int Pop(SeqStack *S, DataType *x)
{
	//调用判空函数EmptyStack(S)，判断是否为空
	if (EmptyStack(S))
	{
		printf("栈空，不能出栈！");
		return 0;//栈空不能出栈
	}
	else
	{
		*x = S->data[S->top];
		S->top--;
		return 1;
	}
}

//取栈顶元素函数
int GetTop(SeqStack *S, DataType *x)
{
	//调用判空函数EmptyStack(S)，判断栈是否为空
	if (EmptyStack(S))
	{
		printf("栈空，取栈顶元素失败！");
		return 0;
	}
	else//栈不为空
	{
		*x = S->data[S->top];
		return 1;
	}
}

void PrintSeqStack(SeqStack *S)
{
	if (EmptyStack(S))
	{
		printf("栈空！");
	}
	else
	{
		printf("栈元素依次为：");
		for (auto i = 0; i <= S->top; i++)
		{
			printf("%5d", S->data[i]);
		}
	}
}

void Menu()

{

	printf("\n\t\t\t\t顺序栈的各种操作");
	printf("\n\t\t=================================================");
	printf("\n\t\t|\t\t1——初始化栈\t\t\t|");
	printf("\n\t\t|\t\t2——入栈操作\t\t\t|");
	printf("\n\t\t|\t\t3——出栈操作\t\t\t|");
	printf("\n\t\t|\t\t4——求栈顶元素\t\t\t|");
	printf("\n\t\t|\t\t5——输出栈元素\t\t\t|");
	printf("\n\t\t|\t\t0——返回\t\t\t|");
	printf("\n\t\t=================================================\n");
	printf("\t\t请输入菜单号（0-5）：");
}

int main()
{
	int i, n, flag;
	SeqStack S;
	DataType x;
	char ch1, ch2, a;
	ch1 = 'y';
	while (ch1=='y'||ch1=='Y')
	{
		Menu();
		scanf_s("%c", &ch2);
		getchar();
		switch (ch2)
		{
		case '1':
			InitStack(&S);
			printf("栈的初始化完成！");
			break;
		case '2':
			printf("请输入要入栈的元素个数：");
			scanf_s("%d", &n);
			printf("请输入%d个入栈的整数：", n);
			for ( i = 0; i < n; i++)
			{
				scanf_s("%d", &x);
				flag = Push(&S, x);
			}
			if (flag == 1)
				printf("入栈成功！");
			break;
		case '3':
			printf("请输入要出栈的元素个数：");
			scanf_s("%d", &n);
			printf("出栈的元素为：");
			for ( i = 0; i < n; i++)
			{
				flag = Pop(&S, &x);
				printf("%5d", x);
			}
			if (flag == 1)
				printf("\n出栈成功！");
			else
				printf("出栈失败！");
			break;
		case '4':
			if (flag == GetTop(&S, &x))
				printf("当前的栈顶元素值为：%d", x);
			break;
		case '5':
			PrintSeqStack(&S);
			break;
		case '0':
			ch1 = 'n';
			break;
		default:
			printf("输入有误，请输入0-5进行选择！");
			break;
		}
		if (ch2!='0')
		{
			printf("\n按回车键继续，按任意键返回主菜单！\n");
			a = getchar();
			if (a != '\xA')
			{
				getchar();
				ch1 = 'n';
			}
		}
	}
	system("pause");
	return 0;
}   
