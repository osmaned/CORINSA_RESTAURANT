using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORINSA_Restaurant
{
    public class Product
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Alias { get; set; }
       public string Description { get; set; }
       public decimal Price { get; set; }

       public Product() { }

       public Product(int pId, string pName, string pAlias, string pDescription, decimal pPrice)
       {
           this.Id = pId;
           this.Name = pName;
           this.Alias = pAlias;
           this.Description = pDescription;
           this.Price = pPrice;       
       }
    }
}
