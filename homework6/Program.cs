using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            OrderService service = new OrderService();
            for (int i = 0; i < 3; i++) {
                Order order=new Order();
                order.OrderID = i+100;
                order.Customername = "客户" + i;
                for (int j = 0; j < 3; j++) {
                    OrderItem item = new OrderItem();
                    item.Amount = random.Next(9) + 1;
                    item.Price = random.Next(100) + 9;
                    item.Itemname = "商品" + j;
                    item.ItemID = 100 + j;
                    order.AddOrderItem(item);

                }

                order.CountTotal();   
                service.Add(order);

            }
            service.ShowOrderLists();
            service.Export();
            service.Import("D:/s.xml");
        }
    }
    [Serializable]
   public class Order {
        public int OrderID { set; get; }
        public string Customername { set; get; }
        
        public List<OrderItem> orderlist= new List<OrderItem> { };
        public void AddOrderItem(OrderItem oi) { orderlist.Add(oi);   }
        public void RemoveOrderItem(OrderItem oi) { orderlist.Remove(oi); }
        public void RemoveAll() { orderlist.Clear(); }
        public override string ToString()
        {
            return "订单号： " + OrderID + "客户名： " + Customername + "总价： " + Total;
        }
        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null &&
                   OrderID == order.OrderID &&
                   Customername == order.Customername;
        }

        public override int GetHashCode()
        {
            var hashCode = 1903320604;
            hashCode = hashCode * -1521134295 + OrderID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Customername);
            return hashCode;
        }
        
        public int Total { get; set; }
        public void CountTotal() {
            foreach (var item in orderlist)
            {
                Total += item.Price * item.Amount;
            }
        }

    }
  public class OrderItem {
        public int ItemID { set; get; }
        public int Amount { set; get; }
        public string Itemname { set; get; }
        public int Price { set; get; }

        public override bool Equals(object obj)
        {
            var item = obj as OrderItem;
            return item != null &&
                   ItemID == item.ItemID &&
                   Amount == item.Amount &&
                   Itemname == item.Itemname &&
                   Price == item.Price;
        }

        public override int GetHashCode()
        {
            var hashCode = 2036580019;
            hashCode = hashCode * -1521134295 + ItemID.GetHashCode();
            hashCode = hashCode * -1521134295 + Amount.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Itemname);
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            return hashCode;
        }
        public override string ToString()
        {
            return "商品号：" + ItemID + "商品名：" + Itemname + "单价：" + Price + "数量：" + Amount;
        }
    }
  public  class OrderService {
        public List<Order> lists=new List<Order> { };
        public void Export() {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(@"D:/s.xml", FileMode.Create)) {
                xmlSerializer.Serialize(fs, lists);
            }
            Console.WriteLine(File.ReadAllText(@"D:/s.xml"));
        }
        public void Import(string path) {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(@path, FileMode.Open)) {
                List<Order> lists1 = (List<Order>)xmlSerializer.Deserialize(fs);
                lists = lists1;
                ShowOrderLists();

            } }
        public void Add(Order od) { lists.Add(od); }
        public void Remove(Order od) {
            od.RemoveAll();
            lists.Remove(od); }
        public Boolean ShowOrderLists()
        {
            foreach (var order in lists)
            {
                Console.WriteLine(order.ToString());
                foreach (var oi in order.orderlist)
                {
                    Console.WriteLine(oi.ToString());

                }
            }
            return true;
        }
        public Boolean Sort() { lists.Sort((o1, o2) => o1.OrderID - o2.OrderID);return true; }
        public Boolean QuerybyorderID(int n1,int n2) {
            var query =from order in lists
                       where order.OrderID <= n2 && order.OrderID >= n1
                       orderby order.Total
                       select order;
            List<Order> list = query.ToList();
            foreach (var order in list)
            {
                Console.WriteLine(order.ToString());
                foreach (var oi in order.orderlist)
                {
                    Console.WriteLine(oi.ToString());

                }
            }
            return true;
        }
        public Boolean QuerybyCustomername(string name) {
            var query = from order in lists
                        where order.Customername == name
                        orderby order.Total
                        select order;
            List<Order> list = query.ToList();
            foreach (var order in list)
            {
                Console.WriteLine(order.ToString());
                foreach (var oi in order.orderlist)
                {
                    Console.WriteLine(oi.ToString());

                }
            }
            return true;
        }
        public Boolean ModifyOrder(int orderid,Order od) {
            for (int i=0;i<lists.Count;i++) {
                if (lists[i].OrderID == orderid) { lists.Remove(lists[i]);lists.Add(od); }
            }
            return true;
        }
        
    }
   
}
