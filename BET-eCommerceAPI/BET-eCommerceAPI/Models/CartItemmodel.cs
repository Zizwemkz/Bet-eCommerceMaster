using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BET_eCommerceAPI.Models
{
    public class CartItemmodel
    {
        [Required]
        public string cart_item_id { get; set; }
        [Required]
        public string cart_id { get; set; }
        [Required]
        public int item_id { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double price { get; set; }

    }
}
