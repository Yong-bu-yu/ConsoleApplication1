// Tree.cpp : 定义控制台应用程序的入口点。
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
	 printf("请输入%c结点的左孩子结点：",t->data);
	 t->lchild=CreateBTree();
	 printf("请输入%c结点的右孩子结点:",t->data);
	 t->rchild=CreateBTree();
   }
   return  t;
}

void ShowBTree(BT *T)                     /*用广义表表示法显示二叉树*/
{   if (T!=NULL)                          /*当二叉树非空时*/
    {   printf("%c",T->data);             /*输入该结点数据域*/
        if(T->lchild!=NULL)               /*若其左子树非空*/
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
          if(T->rchild!=NULL)              /*二叉树左子树为空，右子树不为空时*/
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
	//先序遍历
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
	//中序遍历
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
	//后序遍历
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
	//层次遍历
	if(T==NULL)
		return;
	else
	{
		PostOrder(T->lchild);
		PostOrder(T->rchild);
		printf("%c",T->data);
	}
}

void  Leafnum(BT  *T)                       /*求二叉树叶子结点数*/
{   if(T)                                   /*若树不为空*/
	{                  /*递归统计T的右子树叶子结点数*/
		if(T->lchild==NULL&&T->rchild==NULL)
			count++;
		Leafnum(T->lchild);
		Leafnum(T->rchild);
	}
}

void  Nodenum(BT *T)
{	if(T)                                   /*若树不为空*/
	{
		count++;              /*递归统计T的右子树结点数*/
		Nodenum(T->lchild);
		Nodenum(T->rchild);
	}
}

int  TreeDepth(BT  *T)                      /*求二叉树深度*/
{   int  ldep=0,rdep=0;                     /*定义两个整型变量，用以存放左、右子树的深度*/
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

void  MenuTree()                                     /*显示菜单子函数*/
{
	printf("\n                  二叉树子系统");
    printf("\n =================================================");  
    printf("\n|               1——建立一个新二叉树            |");
    printf("\n|               2——广义表表示法显示            |");
	printf("\n|               3——先序遍历                    |");
	printf("\n|               4——中序遍历                    |");
	printf("\n|               5——后序遍历                    |");
	printf("\n|               6——层次遍历                    |");
    printf("\n|               7——求叶子结点数目              |");
    printf("\n|               8——求二叉树总结点数目          |");
    printf("\n|               9——求树深度                    |");
    printf("\n|               0——返回                        |");
    printf("\n ================================================="); 
    printf("\n请输入菜单号（0-9）:"); 	
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
             printf("请按先序序列输入二叉树的结点：\n");
             printf("说明：输入结点后按回车（'0'表示后继结点为空）：\n");
             printf("请输入根结点：");
             T=CreateBTree();
             printf("二叉树成功建立！");break;
         case  '2':
             printf("二叉树广义表表示法如下：");
             ShowBTree(T);break;
		 case '3':
			 printf("二叉树的先序遍历为：");
		     PreOrder(T);
			 break;
		 case '4':
			 printf("二叉树的中序遍历为：");
			 InOrder(T);
			 break;
		 case '5':
			 printf("二叉树的后序遍历为:");
			 PostOrder(T);
			 break;
		 case '6':
			 printf("二叉树的层次遍历为：");
			 LevelOrder(T);
			 break;
         case  '7':
             count=0;Leafnum(T);
             printf("该二叉树有%d个叶子。",count);break;
         case  '8':
             count=0;Nodenum(T);
             printf("该二叉树共有%d个结点。",count);break; 
         case  '9':
             printf("该二叉树的深度是%d。",TreeDepth(T));break; 
         case  '0':
             ch1='n';break;
         default:
             printf("输入有误，请输入0-9进行选择！");
   	  }
   	  if(ch2!='0')
   	  {   printf("\n按回车键继续，按任意键返回主菜单！\n");
   	  	  a=getchar();
   	  	  if(a!='\xA')
   	  	  {
   	  	  	 getchar();ch1='n';
   	  	  }
   	  }
   }
	return 0;
}

