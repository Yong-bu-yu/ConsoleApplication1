// ConsoleApplication1.cpp : �������̨Ӧ�ó������ڵ㡣
//

#include "stdafx.h"
#include <malloc.h>
#define MAX 100		//��󶥵���
typedef char VertexType;
int visited[MAX];
typedef struct node
{
	int adjvex;	//�ڽӵ���
	struct node *next;//ָ����һ�ڽӵ��ָ����
}
//����߱���
EdgeNode;

typedef struct vexnode
{
	VertexType data;	//������
	EdgeNode *firstedge;	//ָ���һ���߽��
}
//���嶥����
VHeadNode;

typedef struct
{
	VHeadNode adjlist[MAX];	//�ڽӱ�ͷ�������
	int n, e;	//������������
}
//ͼ���ڽӱ�����
AdjList;

//��������ͼ���ڽӱ���
void CreateAGraph(AdjList *g, int flag)
{
	int i, j, k;
	EdgeNode *p;
	if (flag == 0)
		printf("\n������һ������ͼ��\n");
	else
		printf("\n������һ������ͼ��\n");
	printf("������ͼ�Ķ�������");
	scanf_s("%d", &g->n);
	printf("������ͼ�ı�����");
	scanf_s("%d", &g->e);
	printf("\n������ͼ�ĸ�������Ϣ��\n");
	for ( i = 0; i < g->n; i++)	//������n�������˶����
	{
		printf("��%d��������Ϣ��", i + 1);
		scanf_s("\n%c", &(g->adjlist[i].data),100);	//���붥����Ϣ
		g->adjlist[i].firstedge = NULL;	//��ı߱�ͷָ����Ϊ��
	}
	printf("\n������ߵ���Ϣ�������ʽΪ�����1�����2���������Ϊ0��1��2...����\n");
	for ( k = 0; k < g->e; k++)
	{
		printf("�������%d���ߣ�", k);
		scanf_s("\n%d,%d", &i, &j);
		//�����Ϊi�Ľ����ӵ��ڽӱ���
		p = (EdgeNode*)malloc(sizeof(EdgeNode));
		p->adjvex = j;
		p->next = g->adjlist[i].firstedge;
		g->adjlist[i].firstedge = p;
		//�����Ϊj�Ľ����ӵ��ڽӱ��У�����ͼ������Ӹý�㣬ȥ������if���
		if (flag==0)
		{
			p = (EdgeNode*)malloc(sizeof(EdgeNode));
			p->adjvex = i;	//�ڽӵ����Ϊi
			p->next = g->adjlist[i].firstedge;	//���½��p�嵽����vi�߱�ͷ
			g->adjlist[i].firstedge = p;
		}
	}	
}

//���ͼ���ڽӱ���
void DispAGraph(AdjList *g)
{
	int i;
	EdgeNode *p;
	printf("\nͼ���ڽӱ��ʾ���£�\n");
	for ( i = 0; i < g->n; i++)
	{
		printf("%2d [%c]", i, g->adjlist[i].data);
		p = g->adjlist[i].firstedge;
		while (p!=NULL)
		{
			printf("-->[%d]", p->adjvex);
			p = p->next;
		}
		printf("\n");
	}
}

//���ڽӱ�洢��ͼ�Զ���vi��ʼ������ȱ�������
void DFS(AdjList *g, int vi)
{
	EdgeNode *p;
	printf("(%d", vi);
	printf("%c)", g->adjlist[vi].data);
	visited[vi] = 1;
	p = g->adjlist[vi].firstedge;
	while (p!=NULL)
	{
		if (visited[p->adjvex] == 0)
			DFS(g, p->adjvex);
		p = p->next;
	}
}

//���ڽӱ�洢��ͼ�Զ���vi��ʼ������ȱ�������
void BFS(AdjList *g, int vi)
{
	int i, v, visited[MAX];
	int qu[MAX], front = 0, rear = 0;	//����ѭ������
	EdgeNode *p;
	for (i = 0; i < g->n; i++)	//�����ķ������鸳��ֵ
		visited[i] = 0;
	printf("(%d", vi);
	printf("%c)", g->adjlist[vi].data);
	visited[vi] = 1;
	rear = (rear + 1) % MAX;	//��βָ�����
	qu[rear] = vi;	//��vi���
	while (front!=rear)	//���Ӳ���ʱ
	{
		front = (front + 1) % MAX;
		v = qu[front];	//����ͷԪ�س��ӣ���������v
		p = g->adjlist[v].firstedge;	//������v����һ���ڽӱ߶���ָ�븳��p
		while (p!=NULL)
		{
			if (visited[p->adjvex]==0)	//��δ���ʹ�
			{
				visited[p->adjvex] = 1;	//���������Ԫ����1���ѷ���
				printf("(%d,", p->adjvex);	//����ö�����
				printf("%c)", g->adjlist[p->adjvex].data);	//����ö�����Ϣ
				rear = (rear + 1) % MAX;	//��βָ�����
				qu[rear] = p->adjvex;	//��p��ָ�Ķ������
			}
			p = p->next;
		}
	}
}

//��ʾ�˵��Ӻ���
void MenuGraph()
{
	printf("\n\t     ͼ��ϵͳ");
	printf("\n=================================");
	printf("\n|\t1���������ڽӱ�\t\t|");
	printf("\n|\t2����������ȱ���\t|");
	printf("\n|\t3����������ȱ���\t|");
	printf("\n|\t0��������\t\t|");
	printf("\n=================================");
	printf("\n������˵��ţ�0-3����");
}

int main(int argc, _TCHAR* argv[])
{
	int i, f;
	char ch1, ch2, a;
	AdjList g;
	ch1 = 'y';
	while (ch1=='y'||ch1=='Y')
	{
		MenuGraph();
		scanf_s("%c", &ch2, 1);
		getchar();
		switch (ch2)
		{
		case '1':
			printf("Ҫ������������ͼ(1)��������ͼ(0)����ѡ��(����1��0)��");
			scanf_s("%d", &f);
			CreateAGraph(&g, f);
			DispAGraph(&g);
			break;
		case '2':
			printf("�����뿪ʼ����������ȱ����Ķ������(��Ŵ�0��ʼ���)��");
			scanf_s("%d", &f);
			printf("\n�Ӷ���%d��ʼ��������ȱ�������Ϊ��", f);
			for (i = 0; i < g.n; i++)
				visited[i] = 0;
			DFS(&g, f);
			break;
		case '3':
			printf("�����뿪ʼ���й�����ȱ����Ķ������(��Ŵ�0��ʼ)��");
			scanf_s("%d", &i);
			printf("\n�Ӷ���%d��ʼ�Ĺ�����ȱ�������Ϊ��",i);
			BFS(&g, f);
			break;
		case '0':
			ch1 = 'n';
			break;
		default:
			printf("�����������������0-3����ѡ��");
		}
		if (ch2!='0')
		{
			printf("\n���س�����������������������˵���\n");
			a = getchar();
			if (a!='\xA')
			{
				getchar();
				ch1 = 'n';
			}
		}
	}
}