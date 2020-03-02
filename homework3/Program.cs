using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAPE
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            { if (random.Next(3)== 0) { Square sq = new Square(random.Next(100));
                 
                  if(sq.IsLegal()==true) sq.CalArea();
                }
              if (random.Next(3) == 1) {
                    Rectangle re = new Rectangle(random.Next(100), random.Next(100));
                 
                   if(re.IsLegal()==true) re.CalArea(); }
                if (random.Next(3) == 2) { Triangle tr = new Triangle(random.Next(100), random.Next(100), random.Next(100));
                 
                    if(tr.IsLegal()==true)tr.CalArea();
                }
            }
        }
    }
  public interface IShape {
        void CalArea();
        bool IsLegal();
    }
  abstract  class Shape {
     protected  int[] length;
        int num;
  
    }
    class Square : Shape, IShape
    {
    public void CalArea(){ Console.WriteLine( length[0] * length[0]);     }
      readonly int num=1;
      new int[] length=new int[] { 0};
     public   Square(int length1) {
           length[0] = length1;
           
        }
     public   bool IsLegal(){
            if (length[0] > 0 )
            {
                Console.WriteLine("Square Legal");
                return true;
            }
            else { Console.WriteLine("Not Legal"); return false; }
        }
    }
    class Rectangle : Shape, IShape
    {
     public   void CalArea() { Console.WriteLine(length[0] * length[1]); }
        readonly int num = 2;
        new int[] length=new int[] { 0,0};
        public   Rectangle(int length1, int length2)
        {
            length[0] = length1;
            length[1] = length2;
        }
      public  bool IsLegal()
        {
            if (length[0] > 0 && length[1] > 0)
            {
                Console.WriteLine("Rectangle  Legal");
                return true;

            }
            else { Console.WriteLine("Not Legal"); return false; }
        }
    }
    class Triangle : Shape, IShape
    {
       public void CalArea() {
            double p = (length[0] + length[1] + length[2]) / 2;
            double area = Math.Sqrt(p * (p - length[0]) * (p - length[1]) * (p - length[2]));
            string str1 = String.Format("{0:F}", area);
            Console.WriteLine(str1); }
        readonly int num = 3;
        new int[] length=new int[] { 0,0,0};
        public  Triangle(int length1, int length2,int length3)
        {
            length[0] = length1;
            length[1] = length2;
            length[2] = length3;
        }
     public   bool IsLegal()
        {
            if (length[0] > 0 && length[1] > 0&& length[2]>0&&(length[0]+length[1]>length[2])&& (length[1] + length[2] > length[0])&& (length[0] + length[2] > length[1]))
            {
                Console.WriteLine("Triangle Legal");
                return true;
            }
            else { Console.WriteLine("Not Legal");
                return false;
            }
        }
    }



}
