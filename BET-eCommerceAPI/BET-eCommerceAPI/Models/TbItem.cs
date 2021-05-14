
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BET_eCommerceAPI.Models
{
    public class TbItem
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ItemId { get; set; }

        [Required]
        [ForeignKey("Category_Id")]
        public int Category_Id { get; set; }

        [Required]
        public string Name { get; set; }
    
        [Required]
        public string Description { get; set; }
       
        public int Quantity { get; set; }

        [Required]
        public double Price { get; set; }

        public virtual TbCategory TbCategory { get; set; }
        //public virtual ICollection<Cart_Item> Cart_Items { get; set; }
    }
}