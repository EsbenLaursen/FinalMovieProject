using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDll.Entities
{
    public class Customer : AbstractEntity
    {
        [Required (ErrorMessage = "Please enter a valid first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a valid last name")]
        public string LastName { get; set; }

        
        public string Email { get; set; }
        
        public string password { get; set; }
        public string Role { get; set; }
        public virtual List<Order> Orders { get; set; }

        public int ZipCode { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public int StreetNumber { get; set; }

    }
}
