///算法Perm(list,k,m)递归地产生所有前缀是list[0:k-1]，且
///后缀是list[k:m]的全排列的所有排列。
#include <iostream>
using namespace std;

template <class T>
inline void Swap(T &a, T &b)
{
	T temp = a;
	a = b;
	b = temp;
}
template <class T>
void Perm(T list[],int k,int m )
{
	if (k==m)
	{
		for (int i = 0; i <= m; i++)
			cout << list[i];
		cout << endl;
	}
	else
	{
		for (int i = k; i <= m; i++)
		{
			Swap(list[k], list[i]);
			Perm(list, k + 1, m);
			Swap(list[k], list[i]);
		}
	}
}
int main()
{

}