using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BET_eCommerceAPI.Models
{
    public class TbOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string OrderID { get; set; }

        [Required]
        public int OrderitemId { get; set; }

        [ForeignKey("userName")]
        public string userName { get; set; }
        public double Total { get; set; }
        public bool ShippedStatus { get; set; }
        public DateTime Createddate { get; set; }

        //public virtual ApplicationUser TbUser { get; set; }
        
        
        //public virtual ICollection<Order_Item> Order_Items { get; set; }
        //public virtual ICollection<Shipping_Address> Shipping_Addresses { get; set; }

    }
}
