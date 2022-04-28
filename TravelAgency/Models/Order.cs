using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelAgency.Models
{
    public class Order
    {
        public List<ClientModel> Clients { get; set; }
        public List<DestinationModel> Destinations { get; set; }

        public int order_id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "You need to give us a client ID")]
        public int client_id { get; set; }

        [Display(Name = "Destination")]
        [Required(ErrorMessage = "You need to give us a destination ID")]
        public int dest_id { get; set; }

        [Display(Name = "Order From")]
        [Required(ErrorMessage = "You need to give us an order starting date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime order_from { get; set; }

        [Display(Name = "Order To")]
        [Required(ErrorMessage = "You need to give us an order finishing date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime order_to { get; set; }

        [Display(Name = "Price (PLN)")]
        [Range(0, 100000)]
        [Required(ErrorMessage = "You need to give us a price")]
        public int price { get; set; }

        [Display(Name = "Order date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime order_date { get; set; }


    }
}
