using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDll.Entities
{
    public class Address : AbstractEntity
    {
        public int ZipCode { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public int StreetNumber { get; set; }

        public override string ToString()
        {
            return "City: " + City + "StreetName: " + StreetName;
        }
        public List<Customer> Customer { get; set; }
    }
    
}
