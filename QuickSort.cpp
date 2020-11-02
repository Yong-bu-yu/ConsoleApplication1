// QuickSort.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
// 快速排序
using namespace std;
#include <iostream>

template<class T>
int Partition(T a[], int p, int r)
{
	int i = p, j = r + 1;
	T x = a[p];
	//将小于x的元素交换到左边区域，将大于x的元素交换到右边区域
	while (true)
	{
		while (a[++i] < x&&i < r);
		while (a[--j] > x);
		if (i >= j)
			break;
		swap(a[i], a[j]);
	}
	a[p] = a[j];
	a[j] = x;
	return j;
}
template<class T>
void QuickSork(T a[], int p, int r)
{
	if (p < r)
	{
		int q = Partition(a, p, r);
		QuickSork(a, p, q - 1);// 对左半段排序
		QuickSork(a, q + 1, r);// 对右半段排序
	}
}

int main()
{
	int a[] = { 4,2,1,3 };
	QuickSork(a, 0, 3);
}

// 运行程序: Ctrl + F5 或调试 >“开始执行(不调试)”菜单
// 调试程序: F5 或调试 >“开始调试”菜单

// 入门使用技巧: 
//   1. 使用解决方案资源管理器窗口添加/管理文件
//   2. 使用团队资源管理器窗口连接到源代码管理
//   3. 使用输出窗口查看生成输出和其他消息
//   4. 使用错误列表窗口查看错误
//   5. 转到“项目”>“添加新项”以创建新的代码文件，或转到“项目”>“添加现有项”以将现有代码文件添加到项目
//   6. 将来，若要再次打开此项目，请转到“文件”>“打开”>“项目”并选择 .sln 文件
