using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OrderApp {

  public class Order{

    [Key]
    public long Id { get; set; }

    public long CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }
    
   

    public List<OrderItem> Items { get; set; }

    public string CustomerName { get => (Customer != null) ? Customer.Name : ""; }


    public Order() {
      Id = Guid.NewGuid().ToString();
      Items = new List<OrderItem>();
   
    }

    public Order(Customer customer, List<OrderItem> items):this() {
      this.Customer = customer;
   
      if (items != null) Items = items;
    }
     public double TotalPrice
        {
            get => Items == null ? 0 : Items.Sum(item => item.TotalPrice);
        }
     public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append($"Id:{Id}, customer:{Customer},totalPrice：{TotalPrice}");
            Items.ForEach(od => strBuilder.Append("\n\t" + od));
            return strBuilder.ToString();
        }

    }
}
