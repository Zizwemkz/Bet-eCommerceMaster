using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BET_eCommerceAPI.Models
{
    public class TbOrder_Item
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int OrderItemId {get;set;}
        public int Quantity { get; set; }

        [Required]
        [ForeignKey("ItemId")]
        public Guid ItemId { get; set; }
        //public string OrderID { get; set; }
        public virtual TbItem TbItem { get; set; }
    }
}