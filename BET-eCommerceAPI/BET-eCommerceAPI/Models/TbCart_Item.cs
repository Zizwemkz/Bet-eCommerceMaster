using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BET_eCommerceAPI.Models
{
    public class TbCart_Item
    {
        [Key]
        public string cart_item_id { get; set; }
        [ForeignKey("Cart")]
        public string cart_id { get; set; }
        [ForeignKey("Item")]
        public int item_id { get; set; }
        public int quantity { get; set; }
        [DataType(DataType.Currency)]
        public double price { get; set; }

        public virtual TbItem Item { get; set; }
        public virtual TbCart Cart { get; set; }
    }
}
