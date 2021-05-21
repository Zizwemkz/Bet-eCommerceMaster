using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BET_eCommerceAPI.Models
{
    public class ItemModel
    {

        public int ItemId { get; set; }
      
        public int Category_Id { get; set; }

        [Required(ErrorMessage = " Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description Name is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "QuantityInStock is required")]
        public int QuantityInStock { get; set; }

        public byte[] Picture { get; set; }

        [Required(ErrorMessage = "Item Price is required")]
        public double Price { get; set; }


    }
}