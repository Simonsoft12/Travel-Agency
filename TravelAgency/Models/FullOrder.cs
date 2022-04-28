using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DataLibrary.Models;

namespace TravelAgency.Models
{
    public class FullOrder
    {
        public List<ClientModel> Clients { get; internal set; }
        public List<DestinationModel> Destinations { get; internal set; }

        [Display(Name = "Order ID")]
        [Required(ErrorMessage = "You need to give us an order ID")]
        public int order_id { get; set; }

        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required(ErrorMessage = "You need to give us client's first name")]
        public string client_fname { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required(ErrorMessage = "You need to give us client's last name")]
        public string client_lname { get; set; }

        [Display(Name = "Destination")]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required(ErrorMessage = "You need to give us destination name")]
        public string dest_name { get; set; }

        [Display(Name = "Destination Address")]
        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = "You need to give us destination address")]
        public string dest_address { get; set; }

        [Display(Name = "Order From")]
        [Required(ErrorMessage = "You need to give us an order's starting date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime order_from { get; set; }

        [Display(Name = "Order To")]
        [Required(ErrorMessage = "You need to give us an order's finishing date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime order_to { get; set; }

        [Display(Name = "Price (PLN)")]
        [Range(0, 100000)]
        [Required(ErrorMessage = "You need to give us a price")]
        public int price { get; set; }

        [Display(Name = "Order Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime order_date { get; set; }
    }
}