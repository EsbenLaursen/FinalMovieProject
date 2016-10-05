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
        
        public Address Address { get; set; }

        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        //ErrorMessage = "Please enter correct email address")]
       
        public string Email { get; set; }
        
        public string password { get; set; }
        public string Role { get; set; }

    }
}
