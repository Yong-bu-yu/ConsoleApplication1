#include<vector>
#include<map>
#include<iterator>
#include<iostream>
#include<algorithm>
int main()
{
	//用vector遍历删除数组
	std::vector<int>v(8);
	std::generate(v.begin(), v.end(), std::rand);
	std::cout << "after vector generate...\n";
	std::copy(v.begin(), v.end(), std::ostream_iterator<int>(std::cout,"\t"));
	for (auto x = v.begin(); x != v.end(); )
	{
		if (*x % 2)
			x = v.erase(x);
		else ++x;
	}
	std::cout << "\nafter vector erase...\n";
	std::copy(v.begin(), v.end(), std::ostream_iterator<int>(std::cout, "\t"));
	system("pause");
	return 0;
}
