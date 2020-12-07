using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PXUK16.Web.Models
{
    public class UpdateManufactory
    {
        public int ManafactoryId { get; set; }
        [Display(Name = "Manufactory Name")]
        [Required(ErrorMessage = "Manufactory Name is required.")]
        public string Name { get; set; }
    }
}
