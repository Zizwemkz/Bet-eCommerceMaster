using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BET_eCommerceAPI.Models
{
    public class Departmentmodel
    {
     
        public int Department_ID { get; set; }
        [Required]
     
        public string Department_Name { get; set; }
        [Required]
      
        public string Description { get; set; }

    }
}
