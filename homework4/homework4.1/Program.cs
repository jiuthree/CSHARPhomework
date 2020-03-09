using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4._1
{   public class Node<T> {
public Node<T> Next { set; get; }
public T Data { set; get; }
public Node(T t) { Next = null;Data = t; }

    }

    public class GenericList<T> {
        private Node<T> head;
        private Node<T> tail;
        public GenericList() { tail = head = null; }
        public Node<T>Head{ get => head; }
       

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null) { head = tail = n; }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action) {
            Node<T> temp =head;
            if (temp == null) return;
            action(temp.Data);
            temp = temp.Next;
            while (temp!=tail) {
                action(temp.Data);
                temp = temp.Next;


            }
            action(temp.Data);
            temp = temp.Next;

        }

    }
    class Program
    {
        static void Main(string[] args)
        { Action<int> action = (m => Console.WriteLine(m));
            GenericList<int> list = new GenericList<int>();
            int sum=0;int max=0;int min=0;
            for (int x = 0; x < 10; x++)
            {
                list.Add(x);
            }        
            list.ForEach(action);
            list.ForEach(m=>sum += m);
            list.ForEach(m =>max=( max >m) ? max : m);
            list.ForEach(m => min = (min < m) ? min : m);
            Console.WriteLine(sum);
            Console.WriteLine(max);
            Console.WriteLine(min);
        }
    }
}
