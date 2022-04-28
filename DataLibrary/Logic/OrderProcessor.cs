using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataLibrary.Logic
{
    public static class OrderProcessor
    {

        public static int CreateOrder(int client_id, int dest_id,
            DateTime order_from, DateTime order_to, int price)
        {
            DateTime order_date = DateTime.Now;
            OrderModel data = new OrderModel
            {
                Client_id = client_id,
                Dest_id = dest_id,
                Order_from = order_from,
                Order_to = order_to,
                Price = price,
                Order_date = order_date
            };

            string sql = @"Insert into dbo.Orders (client_id, dest_id, order_from, order_to, price, order_date)
                values (@Client_id, @Dest_id, @Order_from, @Order_to, @Price, @Order_date);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int DeleteOrder(int order_id)
        {
            OrderModel data = new OrderModel
            {
                Order_id = order_id
            };

            string sql = "DELETE FROM dbo.Orders  WHERE  order_id = @ORDER_ID;";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<OrderModel> LoadOrders()
        {
            string sql = "Select * from dbo.Orders;";

            return SqlDataAccess.LoadData<OrderModel>(sql);
        }

        public static List<FullOrderModel> LoadFullOrders()
        {

            string sql = @"SELECT C.client_fname, C.client_lname, D.dest_name, D.dest_address,
                            O.order_id, O.order_from, O.order_to, O.price, O.order_date
                     FROM dbo.Orders O
                     Join Clients C on C.client_id = O.client_id
                     Join Destinations D on D.dest_id = O.dest_id;";

            return SqlDataAccess.LoadData<FullOrderModel>(sql);
        }
    }
}
