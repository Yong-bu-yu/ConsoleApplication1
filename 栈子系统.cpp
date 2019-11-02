#include<stdio.h>//输入输出函数
#include<string.h>//字符串函数
#include<conio.h>//屏幕操作函数
#include<stdlib.h>//其他说明

//数组最大长度为100
#define MAXSIZE 100
//定义DataType为int类型
typedef int DataType;
//链栈存储类型
typedef struct stacknode
{
	//定义结点的数据域
	DataType data;
	//定义结点的指针域
	struct stacknode *next;
}
//链栈存储类型
LinkStack;

//初始化链栈函数
LinkStack *InitStack()
{
	LinkStack *S;
	S = NULL;
	return S;//初始化栈为空
}

//判断栈空函数
int EmptyStack(LinkStack *S)
{
	if (S == NULL)
		return 1;
	else
		return 0;
}

//进栈函数
LinkStack *Push(LinkStack *S, DataType x)
{
	LinkStack *p;
	p = (LinkStack*)malloc(sizeof(LinkStack));//生成新结点
	p->data = x;//将x放入新结点的数据域
	p->next = S;//将新结点插入链表表头之前
	S = p;//新结点作为栈顶
	return S;
}

//出栈函数
LinkStack *Pop(LinkStack *S, DataType *x)
{
	LinkStack *p;
	if (EmptyStack(S))//调用判空函数EmptyStack(S)，判断栈是否为空
	{
		printf("\t栈空，不能出栈！");
		return NULL;//栈空不能出栈
	}
	else//栈不为空
	{
		*x = S->data;//栈顶元素取出赋给x
		p = S;//p结点指向原栈顶S
		S=S->next;//原栈顶S指向其下一个结点
		free(p);//释放原栈顶空间
		return S;//返回栈顶S
	}
}

//获取栈顶元素函数
int GetTop(LinkStack *S, DataType *x)
{
	if (EmptyStack(S))
	{
		printf("栈空！");
		return 0;
	}
	else
	{
		*x = S->data;
		return 1;
	}
}

//显示栈元素
void ShowStack(LinkStack *S)
{
	LinkStack *p = S;
	if (p == NULL)
		printf("\t栈空！");
	else
	{
		printf("从栈顶元素起栈中各元素为：");
		while (p!=NULL)
		{
			printf("%d ", p->data);
			p = p->next;
		}
	}
}

//十、二进制转换
void D_B(LinkStack *S, DataType x)
{
	while (x)
	{
		S = Push(S, x % 2);//余数入栈
		x /= 2;
	}
	printf("转换后的二进制为：");
	while (!EmptyStack(S))
	{
		S = Pop(S, &x);
		printf("%d", x);
	}
}

//将中缀表达式转换成后缀表达式函数
void trans(char *exp, char *postexp)
{
	struct
	{
		char data[MAXSIZE];
		int top;
	}op;//运算符栈
	int i = 0;
	op.top = -1;
	while (*exp!='#')//当表达式没有结束时
	{
		switch (*exp)
		{
		case '('://当字符为'('时
			op.top++;
			op.data[op.top] = *exp;//栈顶指针增1，运算符入栈
			exp++;//中缀表达式指针增1
			break;
		case ')':
			while (op.data[op.top]!='(')//只要运算符栈顶元素不是'('时
			{
				postexp[i++] = op.data[op.top];//栈顶运算符写入后缀数组中
				op.top--;//栈顶指针减1
			}
			op.top--;
			exp++;
			break;
		case '+':
		case '-':
			while (op.top!=-1&&op.data[op.top]!='(')
			{
				postexp[i++] = op.data[op.top];
				op.top--;
			}
			op.top++;
			op.data[op.top] = *exp;
			exp++;
			break;
		case '*':
		case '/':
			while (op.data[op.top]=='*'||op.data[op.top]=='/')
			{
				postexp[i++] = op.data[op.top];
				op.top--;
			}
			op.top++;
			op.data[op.top] = *exp;
			exp++;
			break;
		case ' ':
			break;
		default:
			while (*exp>='0'&&*exp<='9')
			{
				postexp[i++] = *exp;
				exp++;
			}
			postexp[i++] = '#';
			break;
		}
	}
	while (op.top!=-1)
	{
		postexp[i++] = op.data[op.top];
		op.top--;
	}
	postexp[i] = '\0';
}

//根据后缀表达式求值函数
float compvalue(char *postextp)
{
	struct
	{
		float data[MAXSIZE];
		int top;
	}st;//数栈结点类型
	float a, b, c, d;
	st.top = -1;
	while (*postextp!='\0')
	{
		switch (*postextp)
		{
		case '+':
			a = st.data[st.top];//数栈顶元素赋给变量a
			st.top--;
			b = st.data[st.top];
			st.top--;
			c = b + a;
			st.top++;
			st.data[st.top] = c;
			break;
		case '-':
			a = st.data[st.top];
			st.top--;
			b = st.data[st.top];
			st.top--;
			c = b - a;
			st.top++;
			st.data[st.top] = c;
		case '*':
			a = st.data[st.top];
			st.top--;
			b = st.data[st.top];
			st.top--;
			c = b * a;
			st.top++;
			st.data[st.top] = c;
			break;
		case '/':
			a = st.data[st.top];
			st.top--;
			b = st.data[st.top];
			st.top--;
			if (a != 0)
			{
				c = b / a;
				st.top++;
				st.data[st.top] = c;
			}
			else
				printf("\n\t除零错误！\n");
			break;
		default://后缀表达式的字符是数字字符时，将其转换为整数
			d = 0;
			while (*postextp>='0'&&*postextp<='9')
			{
				d = 10 * d + *postextp - '0';
				postextp++;
			}
			st.top++;
			st.data[st.top] = d;//将转换之后的整数入栈
			break;
			break;
		}
		postextp++;
	}
	return st.data[st.top];
}

//菜单函数
void Menu()
{

	printf("\n\t\t\t\t栈子系统");
	printf("\n\t\t=================================================");
	printf("\n\t\t|\t\t1——初始化栈\t\t\t|");
	printf("\n\t\t|\t\t2——入栈操作\t\t\t|");
	printf("\n\t\t|\t\t3——出栈操作\t\t\t|");
	printf("\n\t\t|\t\t4——求栈顶元素\t\t\t|");
	printf("\n\t\t|\t\t5——显示栈中元素\t\t|");
	printf("\n\t\t|\t\t6——十、二进制数转换\t\t|");
	printf("\n\t\t|\t\t7——表达式转换并求值\t\t|");
	printf("\n\t\t|\t\t0——返回\t\t\t|");
	printf("\n\t\t=================================================\n");
	printf("\t\t请输入菜单号（0-7）：");
}

int main()
{
	int i, n, flag = 1;
	LinkStack *S=NULL;
	DataType x;
	char ch1, ch2, a;
	char exp[MAXSIZE], postexp[MAXSIZE];//求表达式值的两个数组
	ch1 = 'y';
	while (ch1=='y'||ch1=='Y')
	{
		Menu();
		scanf_s("%c", &ch2);
		getchar();
		switch (ch2)
		{
		case '1':
			S = InitStack();
			printf("栈的初始化完成！");
			break;
		case '2':
			printf("请输入要入栈的元素个数：");
			scanf_s("%d", &n);
			printf("请输入%d个整数进行入栈：", n);
			for ( i = 0; i < n; i++)
			{
				scanf_s("%d", &x);
				S = Push(S, x);
			}
			printf("入栈成功！");
			break;
		case '3':
			printf("请输入要出栈的元素个数：");
			scanf_s("%d", &n);
			printf("出栈的元素为：");
			for ( i = 0; i < n; i++)
			{
				S = Pop(S, &x);
				if (S != NULL)
					printf("%5d", x);
			}
			break;
		case '4':
			if (flag == GetTop(S, &x))
				printf("当前的栈顶的元素值为：%d", x);
			break;
		case '5':
			ShowStack(S);
			break;
		case '6':
			S = InitStack();
			printf("请输入十进制正整数：");
			scanf_s("%d", &x);
			D_B(S, x);
			break;
		case '7':
			printf("请输入算术表达式（只有+、-、*、/四种运算符），以'#'结束：");
			scanf_s("%s", &exp,100);
			trans(exp, postexp);
			printf("则该表达式的中缀表达式为：%s\n", exp);
			printf("转换之后的后缀表达式为（每个操作数用'#'分隔）：%s\n", postexp);
			printf("表达式的值为：%f\n", compvalue(postexp));
			break;
		case '0':
			ch1 = 'n';
				break;
		default:
			printf("输入有误，请输入0-7进行选择！");
			break;
		}
		if (ch2 != '0')
		{
			printf("\n按回车键继续，按任意键返回主菜单！\n");
			a = getchar();
			if (a!='\xA')
			{
				getchar();
				ch1 = 'n';
			}
		}
	}
	system("pause");
	return 0;
}   
