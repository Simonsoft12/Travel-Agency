using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelAgency.Models
{
    public class Destination
    {
        [Display(Name = "Destination ID")]
        public int dest_id { get; set; }

        [Display(Name = "Destination")]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required(ErrorMessage = "You need to give us a destination")]
        public string dest_name { get; set; }

        [Display(Name = "Destination Phone")]
        [StringLength(15, MinimumLength = 3)]
        [Required(ErrorMessage = "You need to give us destination phone number")]
        public string dest_phone { get; set; }

        [Display(Name = "Destination Address")]
        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = "You need to give us destination address")]
        public string dest_address { get; set; }
    }
}
