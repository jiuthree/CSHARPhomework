using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homework5.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        
      public  OrderService service = new OrderService();
      public  Order order1 = new Order();
      public  Order order2 = new Order();
        [TestInitialize]

        public  void Intialize()
        {
            

            order1.OrderID = 1 + 100;
            order1.Customername = "客户" + 1;
            for (int j = 0; j < 3; j++)
            {
                OrderItem item = new OrderItem();
                item.Amount = 3;
                item.Price = 9;
                item.Itemname = "商品" + j;
                item.ItemID = 100 + j;
                order1.AddOrderItem(item);

            }

            order1.CountTotal();
            service.Add(order1);




            order2.OrderID = 1 + 100;
            order2.Customername = "客户" + 2;
            for (int j = 0; j < 3; j++)
            {
                OrderItem item = new OrderItem();
                item.Amount = 3;
                item.Price = 9;
                item.Itemname = "商品" + j;
                item.ItemID = 100 + j;
                order2.AddOrderItem(item);

            }

            order2.CountTotal();


        }
       
        [TestMethod()]
        public void ExportTest()
        {
            service.Export();
            FileStream fs = new FileStream(@"D:/s.xml", FileMode.Open);
            Assert.IsNotNull(fs);
        }

        [TestMethod()]
        public void ImportTest()
        {
            service.Import("D:/s.xml");
            Assert.IsNotNull(service.lists);
        }

        [TestMethod()]
        public void AddTest()
        {
            
            service.Remove(order1);
            service.Add(order2);
            Assert.IsNotNull(service.lists);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            service.Remove(order1);
            Assert.IsNotNull(service.lists);
        }

        [TestMethod()]
        public void ShowOrderListsTest()
        {
          
            Assert.IsTrue(service.ShowOrderLists());
        }

        [TestMethod()]
        public void SortTest()
        {
            Assert.IsTrue(service.Sort());
        }

        [TestMethod()]
        public void QuerybyorderIDTest()
        {
            Assert.IsTrue(service.QuerybyorderID(0,200));
        }

        [TestMethod()]
        public void QuerybyCustomernameTest()
        {
            Assert.IsTrue(service.QuerybyCustomername("客户1"));
        }

        [TestMethod()]
        public void ModifyOrderTest()
        {
      
            Assert.IsTrue(service.ModifyOrder(101,order2));
        }
    }
}