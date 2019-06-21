#include<stdio.h>
int main()
{
    float rmb;
    printf("\t\t\t\t预投资金额:");
    fund:
    while(scanf("%f",&rmb)!=1||rmb<=0)
    {
        printf("\t\t\t\t请输入合理的金额:");
        while(getchar()!='\n');
    }
    if(getchar()!='\n'||rmb<=0)
    {
        scanf("%f",&rmb);
        goto fund;
    }
}
        
