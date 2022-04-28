using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class OrderModel
    {
        public int Order_id { get; set; }
        public int Client_id { get; set; }
        public int Dest_id { get; set; }
        public DateTime Order_from { get; set; }
        public DateTime Order_to { get; set; }
        public int Price { get; set; }
        public DateTime Order_date { get; set; }
    }
}
