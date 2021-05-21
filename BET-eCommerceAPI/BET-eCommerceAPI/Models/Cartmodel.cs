using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BET_eCommerceAPI.Models
{
    public class Cartmodel
    {
         [Required]
        public string cart_id { get; set; }

        [Required]
        public DateTime date_created { get; set; }
    }
}
