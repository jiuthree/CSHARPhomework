using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MySql.Data.MySqlClient;
namespace homework11
{




    public class SQL
    {
        public MySqlCommand cmd = null;
        public MySqlConnection conn = null;
        public string[] tables = { };
        public SQL()
        {
            String connstring = "Server=localhost;Database =orderdatabase;Uid=root;Pwd=123456;charset=utf8";

            conn = new MySqlConnection(connstring);
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            OrderItem orderItem1 = new OrderItem {  Amount = 4, Price = 9, Itemname = "铅笔" };
            orderService.AddOrderItem(orderItem1);
            Order order1 = new Order();
            order1.OrderID = 5;
            order1.Customername = "张三";
            order1.orderitemlist = 1;
           orderService.AddOrder(order1);
            orderService.Orderadditem(1, 2);
            orderService.ShowOrder(1);

        }
    }
    [Serializable]
    public class Order
    {

        public int OrderID { set; get; }

        public string Customername { set; get; }
        public List<OrderItem> Orderitemlists
        {
            get { return orderlist; }
            set { orderlist = value; }
        }
        public int orderitemlist { get; set; }
        public List<OrderItem> orderlist = new List<OrderItem> { };
        public void AddOrderItem(OrderItem oi) { orderlist.Add(oi); }
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
         
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Customername);
            return hashCode;
        }

        public int Total { get; set; }
        public void CountTotal()
        {
            foreach (var item in orderlist)
            {
                Total += item.Price * item.Amount;
            }
        }

    }
    public class OrderItem
    {
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
    public class OrderService
    {
        private SQL sql;
        public void ShowOrder(int orderid) {
            sql = new SQL();
            sql.conn.Open();    //②打开数据库连接
            MySqlCommand mysqlCommand = sql.conn.CreateCommand();
            mysqlCommand.CommandText = "select oi.orderitemid,oi.amount,oi.itemname,oi.price from link l,orderitem oi,ordertable ot where ot.orderid=@orderid and ot.orderitemlist=l.orderitemlist and oi.orderitemid=l.orderitemid";
            mysqlCommand.Parameters.AddWithValue("@orderid", orderid);
            MySqlDataAdapter mysda = new MySqlDataAdapter(mysqlCommand);
            DataSet dataset = new DataSet();
            mysda.Fill(dataset, "orderitem");
            foreach (DataRow row in dataset.Tables["orderitem"].Rows) {
                foreach (object field in row.ItemArray) {
                    Console.Write(field + "\t");
                }
                Console.WriteLine();
            }
        }
        public void DeleteOrder(int id)
        {
            sql = new SQL();
            sql.conn.Open();    //②打开数据库连接
            MySqlCommand mysqlCommand = sql.conn.CreateCommand();
            mysqlCommand.CommandText = "delete from order where orderid=@id";

            mysqlCommand.Parameters.AddWithValue("@id", id);


            mysqlCommand.ExecuteNonQuery();
            sql.conn.Close();
        }
        public void DeleteOrderItem(int id) {
            sql = new SQL();
            sql.conn.Open();    //②打开数据库连接
            MySqlCommand mysqlCommand = sql.conn.CreateCommand();
            mysqlCommand.CommandText = "delete from orderitem where orderitemid=@id";

            mysqlCommand.Parameters.AddWithValue("@id", id);


            mysqlCommand.ExecuteNonQuery();
            sql.conn.Close();
        }
        public void AddOrderItem(OrderItem orderItem)
        {
            sql = new SQL();
            sql.conn.Open();    //②打开数据库连接
            MySqlCommand mysqlCommand = sql.conn.CreateCommand();
            mysqlCommand.CommandText = "insert into orderitem(amount,itemname,price)values(@amount,@itemname,@price)";
         
            mysqlCommand.Parameters.AddWithValue("@amount", orderItem.Amount);
            mysqlCommand.Parameters.AddWithValue("@itemname", orderItem.Itemname);
            mysqlCommand.Parameters.AddWithValue("@price", orderItem.Price);

            mysqlCommand.ExecuteNonQuery();
            sql.conn.Close();


        }
        public void Orderadditem(int orderlistid, int itemid)
        {

            sql = new SQL();
            sql.conn.Open();    //②打开数据库连接
            MySqlCommand mysqlCommand = sql.conn.CreateCommand();
            mysqlCommand.CommandText = "insert into link(orderitemlist,orderitemid)values(@orderitemlist,@orderitemid)";
            mysqlCommand.Parameters.AddWithValue("@orderitemlist", orderlistid);
            mysqlCommand.Parameters.AddWithValue("@orderitemid", itemid);



            mysqlCommand.ExecuteNonQuery();
            sql.conn.Close();


        }
        public void AddOrder(Order order)
        {
            sql = new SQL();
            sql.conn.Open();    //②打开数据库连接
            MySqlCommand mysqlCommand = sql.conn.CreateCommand();
            mysqlCommand.CommandText = "insert into ordertable(orderid,customername,orderitemlist)values(@orderid,@customername,@orderitemlist)";
          mysqlCommand.Parameters.AddWithValue("@orderid", order.OrderID);
          mysqlCommand.Parameters.AddWithValue("@customername", order.Customername);
          mysqlCommand.Parameters.AddWithValue("@orderitemlist", order.orderitemlist);


            mysqlCommand.ExecuteNonQuery();
            sql.conn.Close();


        }
        public List<Order> lists = new List<Order> { };
        public void Export()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(@"D:/s.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, lists);
            }
            Console.WriteLine(File.ReadAllText(@"D:/s.xml"));
        }
        public void Import(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(@path, FileMode.Open))
            {
                List<Order> lists1 = (List<Order>)xmlSerializer.Deserialize(fs);
                lists = lists1;
                ShowOrderLists();

            }
        }
        public void Add(Order od) { lists.Add(od); }

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




    }
}
