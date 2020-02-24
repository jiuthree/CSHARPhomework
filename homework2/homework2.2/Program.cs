using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("请输入数组元素个数及相应的值：");
            n = System.Int32.Parse(Console.ReadLine());
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = System.Int32.Parse(Console.ReadLine());
            }
            int min, max, sum;
            double aver;
            min = max = a[0];
            sum = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i] < min) min = a[i];
            }
            for (int i = 0; i < n; i++)
            {
                if (a[i] > max) max = a[i];
            }
            for (int i = 0; i < n; i++)
            {
                sum = sum + a[i];
            }
            aver = sum * 1.00 / n;
            Console.WriteLine($"最大值：{max}");
            Console.WriteLine($"最小值：{min}");
            Console.WriteLine($"平均值：{aver}");
            Console.WriteLine($"和：{sum}");
        }
    }
}
