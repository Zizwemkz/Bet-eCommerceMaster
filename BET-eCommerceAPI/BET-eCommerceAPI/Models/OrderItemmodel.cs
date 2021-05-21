using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BET_eCommerceAPI.Models
{
    public class OrderItemModel
    {
  
        public int Id { get; set; }

        [Required(ErrorMessage = "OrderItemId is required")]
        public int OrderItemId { get; set; }

        [Required(ErrorMessage = "ItemId is required")]
        public Guid itemId { get; set; }

        [Required(ErrorMessage = "Quatity is required")]
        public int Quatity { get; set; }
    }
}