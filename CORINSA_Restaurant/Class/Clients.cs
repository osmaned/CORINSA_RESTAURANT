using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORINSA_Restaurant
{
    public class Clients
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Email { get; set; }
       public string Telephone { get; set; }
       public string Address { get; set; }

       public Clients() { }

       public Clients(int pId, string pName, string pEmail, string pTelephone, string pAddress)
       {
           this.Id = pId;
           this.Name = pName;
           this.Email = pEmail;
           this.Telephone = pTelephone;
           this.Address = pAddress;       
       }
    }
}
