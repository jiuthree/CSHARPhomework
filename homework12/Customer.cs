using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp {
  public class Customer {
    [Key]
    public long Id { get; set; }
    public string Name { get; set; }

    public Customer() {
      ID = Guid.NewGuid().ToString();
    }

    public Customer(string name):this() {
      Name = name;
    }


   
  }
}
