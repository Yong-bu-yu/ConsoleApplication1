// ChessBoard.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
using namespace std;

int Board[4][4];
//L型骨牌号
int tille = 0;
//分割棋盘
int s = 0;
//棋盘覆盖
//tr：棋盘左上角方格的行号    dc：特殊方格所在的列号
//tc：棋盘左上角方格的列号    size：size=2^k，棋盘规格为2^k*2^k
//dr：特殊方格所在的行号
void ChessBoard(int tr, int tc, int dr, int dc, int size)
{
	if (size == 1)
		return;
	int t = tille++;
	s = size / 2;
	//覆盖左上角棋盘
	//特殊棋盘中无特殊方格
	if (dr < tr + s && dc < tc + s)
		ChessBoard(tr, tc, dr, dc, s);
	//此棋盘中无特殊方格
	else
	{
		//用t号L型骨牌覆盖右下角
		Board[tr + s - 1][tc + s - 1] = t;
		//覆盖其余方格
		ChessBoard(tr, tc, tr + s - 1, tc + s - 1, s);
	}
	//覆盖右上角棋盘
	if (dr < tr + s && dc >= tc + s)
		ChessBoard(tr, tc + s, tr + s - 1, tc + s, s);
	else
	{
		Board[tr + s - 1][tc + s] = t;
		ChessBoard(tr, tc + s, tr + s - 1, tc + s, s);
	}
	//覆盖左下角
	if (dr >= tr + s && dc < tc + s)
		ChessBoard(tr + s, tc, dr, dc, s);
	else
	{
		Board[tr + s][tc + s - 1] = t;
		ChessBoard(tr + s, tc, tr + s, tc + s - 1, s);
	}
	if (dr >= tr + s && dc >= tc + s)
		ChessBoard(tr + s, tc + s, dr, dc, s);
	else
	{
		Board[tr + s][tc + s] = t;
		ChessBoard(tr + s, tc + s, tr + s, tc + s, s);
	}
}

int main()
{
	ChessBoard(0, 0, 0, 0, 16);
	return 0;
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
