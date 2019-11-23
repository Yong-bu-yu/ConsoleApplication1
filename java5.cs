using System;
using System.Collections;

namespace 实验
{
    class Program
    {
        class Point
        {
            private string point;
            public void setPoint(string point)
            {
                this.point = point;
            }
            public string getPoint()
            {
                return point;
            }
        }

        static void Main(string[] args)
        {
            ArrayList point = new ArrayList();
            Point[] points = new Point[100];
            bool flage = false, flage2 = false;
            int cout = 0;
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point();
                points[i].setPoint("x:" + i + "," + "y:" + i * i);
                point.Add(points[i]);
            }
            for (int i = 0; i < point.Count; i++)
            {
                flage = true;
                for (int j = 0; j < ((Point)point[i]).getPoint().Length; j++)
                {
                    char ch = ((Point)(point[i])).getPoint()[j];
                    if (char.IsNumber(ch))
                    {
                        if (flage)
                        {
                            if (j == 2)
                            {
                                cout++;
                                Console.Write("第{0}个点：", cout);
                                flage = false;
                            }
                        }
                        if (flage2) 
                                Console.Write(" ");
                            Console.Write(ch);
                        if (j == ((Point)point[i]).getPoint().Length - 1)
                        {
                            Console.WriteLine();
                        }
                        flage2 = false ;
                    }
                    if(ch.Equals(','))
                    flage2 = true;
                }
            }
        }
    }
}
