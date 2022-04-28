using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace TravelAgency.Models
{
    public class Client
    {
        [Display(Name = "Client ID")]
        public int client_id { get; set; }

        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required(ErrorMessage = "You need to give us your first name")]
        public string client_fname { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required(ErrorMessage = "You need to give us your last name")]
        public string client_lname { get; set; }

        [Display(Name = "Phone")]
        [StringLength(15, MinimumLength = 3)]
        [Required(ErrorMessage = "You need to give us your phone number")]
        public string client_phone { get; set; }

        [Display(Name = "Address")]
        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = "You need to give us your address")]
        public string client_address { get; set; }
    }
}