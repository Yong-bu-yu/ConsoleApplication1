// Tree.cpp : �������̨Ӧ�ó������ڵ㡣
//

#include "stdafx.h"
#include <malloc.h>
#define  MAX  100
int  count=0;      
typedef  struct  tnode
{ 
   char data;
   struct tnode *lchild,*rchild;
}BT;

BT  *CreateBTree()
{
   BT  *t;
   char  ch;
   scanf("%c",&ch);
   getchar();
   if(ch=='0')
      t=NULL;
   else
   {
   	 t=(BT*)malloc(sizeof(BT));
	 t->data=ch;
	 printf("������%c�������ӽ�㣺",t->data);
	 t->lchild=CreateBTree();
	 printf("������%c�����Һ��ӽ��:",t->data);
	 t->rchild=CreateBTree();
   }
   return  t;
}

void ShowBTree(BT *T)                     /*�ù�����ʾ����ʾ������*/
{   if (T!=NULL)                          /*���������ǿ�ʱ*/
    {   printf("%c",T->data);             /*����ý��������*/
        if(T->lchild!=NULL)               /*�����������ǿ�*/
        {
			printf("%c",T->data);
			if(T->lchild!=NULL)
			{
				printf("(");
				ShowBTree(T->lchild);
				if(T->rchild!=NULL)
				{
					printf(",");
					ShowBTree(T->rchild);
				}
				printf(")");
			}
        }
        else
          if(T->rchild!=NULL)              /*������������Ϊ�գ���������Ϊ��ʱ*/
          {
        	printf("(");
			ShowBTree(T->lchild);
			if(T->rchild!=NULL)
			{
				printf(",");
				ShowBTree(T->rchild);
			}
			printf(")");
          }
    }
}

void PreOrder(BT *T)
{
	//�������
	if(T==NULL)
		return;
	else
	{
		printf("%c",T->data);
		PreOrder(T->lchild);
		PreOrder(T->rchild);
	}
}

void InOrder(BT *T)
{
	//�������
	if(T==NULL)
		return;
	else
	{
		InOrder(T->lchild);
		printf("%c",T->data);
		InOrder(T->rchild);
	}
}
 
void PostOrder(BT *T)
{
	//�������
	if(T==NULL)
		return;
	else
	{
		PostOrder(T->lchild);
		PostOrder(T->rchild);
		printf("%c",T->data);
	}
}

void LevelOrder(BT *T)
{
	//��α���
	if(T==NULL)
		return;
	else
	{
		PostOrder(T->lchild);
		PostOrder(T->rchild);
		printf("%c",T->data);
	}
}

void  Leafnum(BT  *T)                       /*�������Ҷ�ӽ����*/
{   if(T)                                   /*������Ϊ��*/
	{                  /*�ݹ�ͳ��T��������Ҷ�ӽ����*/
		if(T->lchild==NULL&&T->rchild==NULL)
			count++;
		Leafnum(T->lchild);
		Leafnum(T->rchild);
	}
}

void  Nodenum(BT *T)
{	if(T)                                   /*������Ϊ��*/
	{
		count++;              /*�ݹ�ͳ��T�������������*/
		Nodenum(T->lchild);
		Nodenum(T->rchild);
	}
}

int  TreeDepth(BT  *T)                      /*����������*/
{   int  ldep=0,rdep=0;                     /*�����������ͱ��������Դ���������������*/
	if(T==NULL)
	   return  0;
	else
	{   
		ldep=TreeDepth(T->lchild);
		rdep=TreeDepth(T->rchild);
		if(ldep>rdep)
			return ldep+1;
		else
			return rdep+1;
	}
}

void  MenuTree()                                     /*��ʾ�˵��Ӻ���*/
{
	printf("\n                  ��������ϵͳ");
    printf("\n =================================================");  
    printf("\n|               1��������һ���¶�����            |");
    printf("\n|               2����������ʾ����ʾ            |");
	printf("\n|               3�����������                    |");
	printf("\n|               4�����������                    |");
	printf("\n|               5�����������                    |");
	printf("\n|               6������α���                    |");
    printf("\n|               7������Ҷ�ӽ����Ŀ              |");
    printf("\n|               8������������ܽ����Ŀ          |");
    printf("\n|               9�����������                    |");
    printf("\n|               0��������                        |");
    printf("\n ================================================="); 
    printf("\n������˵��ţ�0-9��:"); 	
}

int _tmain(int argc, _TCHAR* argv[])
{
	   BT  *T=NULL; 
   char  ch1,ch2,a;
   ch1='y';
   while(ch1=='y'||ch1=='Y') 
   {  MenuTree();
   	  scanf("%c",&ch2);
   	  getchar();
   	  switch(ch2)
   	  {
   	  	 case  '1':   	  	 
             printf("�밴������������������Ľ�㣺\n");
             printf("˵����������󰴻س���'0'��ʾ��̽��Ϊ�գ���\n");
             printf("���������㣺");
             T=CreateBTree();
             printf("�������ɹ�������");break;
         case  '2':
             printf("������������ʾ�����£�");
             ShowBTree(T);break;
		 case '3':
			 printf("���������������Ϊ��");
		     PreOrder(T);
			 break;
		 case '4':
			 printf("���������������Ϊ��");
			 InOrder(T);
			 break;
		 case '5':
			 printf("�������ĺ������Ϊ:");
			 PostOrder(T);
			 break;
		 case '6':
			 printf("�������Ĳ�α���Ϊ��");
			 LevelOrder(T);
			 break;
         case  '7':
             count=0;Leafnum(T);
             printf("�ö�������%d��Ҷ�ӡ�",count);break;
         case  '8':
             count=0;Nodenum(T);
             printf("�ö���������%d����㡣",count);break; 
         case  '9':
             printf("�ö������������%d��",TreeDepth(T));break; 
         case  '0':
             ch1='n';break;
         default:
             printf("��������������0-9����ѡ��");
   	  }
   	  if(ch2!='0')
   	  {   printf("\n���س�����������������������˵���\n");
   	  	  a=getchar();
   	  	  if(a!='\xA')
   	  	  {
   	  	  	 getchar();ch1='n';
   	  	  }
   	  }
   }
	return 0;
}

