using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4._2
{
    public delegate void ClockHander(object sender, Clock args);
    public class Clock {public int Time { set; get; }

    }
    public class Handevent
    {
        public event ClockHander Tick;
        public event ClockHander Alarm;
        public void Clocks(int t)
        {
            for (int i = 0; i < 20; i++)
            {


                Clock args = new Clock() { Time = t };
                Tick(this, args);
                Console.WriteLine($"时间是{t}秒");
            if (t % 5 == 0) { Alarm(this, args); };
                t++;
           
            }

        }
    }
        public class Control
        {
            public Handevent hand1 = new Handevent();
            public Control()
            {
                hand1.Tick += new ClockHander(Tick1);
                hand1.Alarm += new ClockHander(Alarm1);
                void Alarm1(object sender, Clock args)
            { Console.WriteLine("Alarm"); }
                void Tick1(object sender, Clock args)
                {


                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("Tick发生");


                }

            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Control con = new Control();
                con.hand1.Clocks(1);

            }
        }
    }        
