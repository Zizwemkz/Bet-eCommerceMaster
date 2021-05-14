using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BET_eCommerceAPI.Models
{
    public class ItemModel
    {

        public Guid ItemId { get; set; }

      
        public int Category_Id { get; set; }

        [Required(ErrorMessage = "Description Name is required")]
        [RegularExpression(pattern: @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Numbers and special characters are not allowed.")]
        [StringLength(maximumLength: 35, ErrorMessage = "Category Name must be atleast 3 characters long", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description Name is required")]
        [RegularExpression(pattern: @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Numbers and special characters are not allowed.")]
        [StringLength(maximumLength: 35, ErrorMessage = "Category Name must be atleast 3 characters long", MinimumLength = 3)]
        public string Description { get; set; }

        [Required(ErrorMessage = "QuantityInStock is required")]
        [StringLength(maximumLength: 4, ErrorMessage = "Category Name must be atleast 3 characters long", MinimumLength = 3)]
        public int QuantityInStock { get; set; }

        
        [Required(ErrorMessage = "Item Price is required")]
        public double Price { get; set; }
    }
}