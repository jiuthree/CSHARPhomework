using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using homework5;

namespace Winform
{
    public partial class Form1 : Form
    { public OrderService service;
      public string CustomName { get; set; }
        public string ID1 { get; set; }
        public string ID2 { get; set; }
       

        public Form1()
        {
            InitializeComponent();
            Random random = new Random();
            service = new OrderService();
            for (int i = 0; i < 3; i++)
            {
                Order order = new Order();
                order.OrderID = Convert.ToString(i) + 100;
                order.Customername = "客户" + i;
                for (int j = 0; j < 3; j++)
                {
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
            bindingSource1.DataSource = service.lists;
            textBox2.DataBindings.Add("Text",this,"CustomName");
            textBox1.DataBindings.Add("Text", this, "ID1");
            textBox3.DataBindings.Add("Text", this, "ID2");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = service.QuerybyCustomername(textBox2.Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = service.QuerybyorderID(int.Parse(ID1),int.Parse(ID2));
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = true;
            dataGridView2.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView2.AllowUserToDeleteRows = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false ;
            dataGridView1.AllowUserToDeleteRows = false ;
            dataGridView2.AllowUserToDeleteRows = false ;
            service.lists=service.Reclear();

            bindingSource1.DataSource = service.Sort();
        }
    }
}
