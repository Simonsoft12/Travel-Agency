using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataLibrary.Logic
{
    public static class ClientProcessor
    {
        public static int CreateClient(string client_fname, string client_lname,
            string client_phone, string client_address)
        {
            ClientModel data = new ClientModel
            {
                Client_fname = client_fname,
                Client_lname = client_lname,
                Client_phone = client_phone,
                Client_address = client_address
            };

            string sql = @"Insert into dbo.Clients (client_fname, client_lname, client_phone, client_address)
                 values (@Client_fname, @Client_lname, @Client_phone, @Client_address);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int UpdateClient(int client_id, string client_fname, string client_lname,
            string client_phone, string client_address)
        {
            ClientModel data = new ClientModel
            {
                Client_id = client_id,
                Client_fname = client_fname,
                Client_lname = client_lname,
                Client_phone = client_phone,
                Client_address = client_address
            };

            string sql = @"UPDATE dbo.Clients  
            SET    client_fname = @CLIENT_FNAME,  
                   client_lname = @CLIENT_LNAME,  
                   client_phone = @CLIENT_PHONE,  
                   client_address = @CLIENT_ADDRESS  
            WHERE  client_id = @CLIENT_ID;";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int DeleteClient(int client_id)
        {
            ClientModel data = new ClientModel
            {
                Client_id = client_id
            };

            string sql = "DELETE FROM dbo.Clients  WHERE  client_id = @CLIENT_ID;";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<ClientModel> LoadClients()
        {
            string sql = "Select * from dbo.Clients;";

            return SqlDataAccess.LoadData<ClientModel>(sql);
        }

        public static List<ClientModel> LoadClients(int id)
        {
            string sql = "Select * from dbo.Clients WHERE client_id = '" + id + "';";

            return SqlDataAccess.LoadData<ClientModel>(sql);
        }
    }
}
