// Queue.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
typedef int DataType;
typedef struct qnode
{
	DataType data;
	struct qnode *next;
}LinkListQ;

typedef struct
{
	LinkListQ *front,*rear;
}LinkQueue;

LinkQueue *InitQueue()
{
	LinkQueue *Q;
	LinkListQ *p;
	Q=(LinkQueue*)malloc(sizeof(LinkQueue));
	p=(LinkListQ*)malloc(sizeof(LinkListQ));
	Q->front=p;
	Q->rear=p;
	return Q;
}

int EmptyQueue(LinkQueue *Q)
{
	if(Q->front==Q->rear)
		return 1;
	else 
		return 0;
}

void InQueue(LinkQueue *Q,DataType x)
{
	LinkListQ *p;
	p=(LinkListQ*)malloc(sizeof(LinkListQ));
	p->data=x;
	p->next=NULL;
	Q->rear->next=p;
	Q->rear=p;
}

int DeQueue(LinkQueue *Q,DataType *x)
{
	LinkListQ *p;
	if(EmptyQueue(Q))
	{
		printf("队空,不能出队");
		return 0;
	}
	else
	{
		p=Q->front->next;
		*x=p->data;
		Q->front->next=p->next;
		if(p->next==NULL)
			Q->rear=Q->front;
		free(p);
		return 1;
	}
}

int GetFront(LinkQueue *Q,DataType *x)
{
	if(EmptyQueue(Q))
	{
		printf("队空,无元素");
		return 0;
	}
	else
	{
		*x=Q->front->next->data;
		return 1;
	}
}

void ShowQueue(LinkQueue *Q)
{
	LinkListQ *p=Q->front->next;
	if(p==NULL)
		printf("无元素");
	else
	{
		printf("元素为：");
		while(p!=NULL)
		{
			printf("%5d",p->data);
			p=p->next;
		}
	}
}

void MenuQueue()
{
	printf("\n\t队列子系统");
	printf("\n\t=================================");
	printf("\n\t|\t1——初始化队列\t\t|");
	printf("\n\t|\t2——入队操作\t\t|");
	printf("\n\t|\t3——出队操作\t\t|");
	printf("\n\t|\t4——求队头元素\t\t|");
	printf("\n\t|\t5——显示队中所有元素\t|");
	printf("\n\t|\t0——返回\t\t|");
	printf("\n\t=================================");
	printf("\n请输入菜单号（0-5）：");
}

int _tmain(int argc, _TCHAR* argv[])
{
	int i,n,flag;
	LinkQueue *Q;
	DataType x;
	char ch1,ch2,a;
	ch1='y';
	while(ch1=='y'||ch1=='Y')
	{
		MenuQueue();
		scanf("%c",&ch2);
		getchar();
		switch(ch2)
		{
		case '1':
			Q=InitQueue();
			printf("队列的初始化完成！");
			break;
		case '2':
			printf("请输入要入队的元素个数：");
			scanf("%d",&n);
			printf("请输入元素：");
			for(i=0;i<n;i++)
			{
				scanf("%d",&x);
				InQueue(Q,x);
			}
			printf("操作完成");
			break;
		case '3':
			printf("请输入要出队的元素个数：");
			scanf("%d",&n);
			printf("出队的元素依次为：");
			for(i=0;i<n;i++)
			{
				flag=DeQueue(Q,&x);
				printf("%5d",x);
			}
			if(flag==1)
				printf("\n操作成功");
			else
				printf("\n操作失败");
			break;
		case '4':
			if(flag==GetFront(Q,&x))
				printf("当前的队头元素值为：%d",x);
			break;
		case '5':
			ShowQueue(Q);
			break;
		case '0':
			ch1='n';break;
		default:
			printf("输入有误，请重新输入");
		}
		if(ch2!='0')
		{
			printf("\n按回车键继续，按任意键退出");
			a=getchar();
			if(a!='\xA')
			{
				getchar();
				ch1='n';
			}
		}
	}
	return 0;
}

