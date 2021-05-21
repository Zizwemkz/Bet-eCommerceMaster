using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BET_eCommerceAPI.Models
{
    public class CategoryModel
    {
       
        public int Category_ID { get; set; }

        [Column(TypeName = "nvarchar(6)")]
        [Required(ErrorMessage = "Description Name is required")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(6)")]
        [Required(ErrorMessage = "DepartmentId is required")]
        public int Department_ID { get; set; }

        //[Column(TypeName = "nvarchar(6)")]
        //[Required(ErrorMessage = "Description is required")]
        //public string Description { get; set; }
    }
}