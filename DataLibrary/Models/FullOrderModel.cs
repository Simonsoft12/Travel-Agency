using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class FullOrderModel
    {
        public int Order_id { get; set; }

        public string Client_fname { get; set; }

        public string Client_lname { get; set; }

        public string Dest_name { get; set; }

        public string Dest_address { get; set; }

        public DateTime Order_from { get; set; }

        public DateTime Order_to { get; set; }

        public int Price { get; set; }
        public DateTime Order_date { get; set; }
    }
}
