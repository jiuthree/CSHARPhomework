using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp {
  public class Goods {
    [Key]
    public long Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public Goods() {
    }

    public Goods(string name, double price) {
      ID = Guid.NewGuid().ToString();
      Name = name;
      Price = price;
    }

   
   
  }


}
