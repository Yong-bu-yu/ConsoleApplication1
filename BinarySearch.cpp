// BinarySearch 二分搜索技术
// 给定已排好序的个元素a[0:n-1]，在这个n个元素中找出一特定元素x

#include <iostream>
using namespace std;
template<class T>
int BinarySearch(T a[], const T &x, int n)
{
	//找到x时返回其在数组中的位置，否则返回-1
	int left = 0;
	int right = n - 1;
	while (left<=right)
	{
		int middle = (left + right) / 2;
		if (x == a[middle])
			return middle;
		if (x > a[middle])
			left = middle + 1;
		else
			right = middle - 1;
	}
	return -1;
}
int main()
{
	int list[] = { 1,2,3,4,5,6 };
	cout<<BinarySearch(list, 3, 3);
	return 0;
}
