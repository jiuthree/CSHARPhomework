using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入数字：");
            int n;
            n = System.Int32.Parse(Console.ReadLine());
            int i = 1;//循环变量
            bool s;     //表示是否为素数
            for (; i < n; i++)
            {
                s = true;//假设当前的i为素数
                for (int j = 2; j < i; j++)
                {
                    //如果i能被它本身和1以外的数整除，那么他就不是素数
                    if (i % j == 0)
                        s = false;
                }
                //如果是素数则输出
                if (s)
                    Console.WriteLine(i.ToString());
            }


        }
    }
}
