using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BET_eCommerceAPI.Models
{
    public class TbCart
    {
        [Key]
        public string cart_id { get; set; }
        public DateTime date_created { get; set; }

        public virtual ICollection<TbCart_Item> Cart_Items { get; set; }
    }
}
