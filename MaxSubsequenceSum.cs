using System;

namespace projectapp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxSubsequenceSum(new int[]{ 4,-3, 5, -2,-1, 2, 6, -2 },0,7));
        }
        static int MaxSubsequenceSum(int []array, int left, int right)   
        {
            if (left == right)          // 设置基准，即递归终止条件
                return array[left];

            int middle = (left + right) / 2;

            int leftMaxSubsequenceSum = MaxSubsequenceSum(array, left, middle);     // 求左半部分最大子序列和
            int rightMaxSubsquenceSum = MaxSubsequenceSum(array, middle + 1, right);    // 求右半部分最大子序列和

            // 处理左右边界问题：最大子序列跨越中间，包含左半部分最右一个数，同时包含右半部分最左一个数
            int maxLeftBorderSum = 0;   
            int maxRightBorderSum = 0;  
            int tempSum = 0;        // 临时求和变量
            for (int i = middle;i >= left;i--)
            {
                tempSum += array[i];
                if (tempSum > maxLeftBorderSum)
                    maxLeftBorderSum = tempSum;     // 左边包含边界最大序列和
            }
            tempSum = 0;
            for (int i = middle + 1;i < right;i++)
            {
                tempSum += array[i];
                if (tempSum > maxRightBorderSum)
                    maxRightBorderSum = tempSum;    // 右边包含边界最大序列和
            }

            int maxBorderSum = maxRightBorderSum + maxLeftBorderSum;        // 最大边界子序列和等于两部分边界之和
            return max3(leftMaxSubsequenceSum, maxBorderSum, rightMaxSubsquenceSum);         // 返回三个部分的最大子序列和
        }
        static int max3(int a, int b, int c)           // 求三个数的最大值
        {
            int max = a;
            if (b > max)
                max = b;
            if (c > max)
                max = c;
            return max;
        }
    }
}