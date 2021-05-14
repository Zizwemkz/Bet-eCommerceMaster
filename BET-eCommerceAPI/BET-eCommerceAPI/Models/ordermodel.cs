using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BET_eCommerceAPI.Models
{
    public class OrderModel
    {
        public string Order_ID { get; set; }

        [Required]
        public int OrderitemId { get; set; }

        [Required(ErrorMessage = "userName is required")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Total is required")]
        public double Total { get; set; }


        public bool shippedStatus { get; set; }

        [Required(ErrorMessage = "createddate is required")]
        public DateTime createddate { get; set; }
    }
}