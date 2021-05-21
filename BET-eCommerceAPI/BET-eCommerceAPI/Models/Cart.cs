using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET_eCommerceAPI.Models
{
    public class Cart
    {
        [Key]
        public string cart_id { get; set; }
        public DateTime date_created { get; set; }
        public string Email { get; set; } 

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Cart_Item> Cart_Items { get; set; }
    }
}
