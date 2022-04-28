using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataLibrary.Logic
{
    public static class DestinationProcessor
    {
        public static int CreateDestination(string dest_name, string dest_phone, 
            string dest_address)
        {
            DestinationModel data = new DestinationModel
            {
                Dest_name = dest_name,
                Dest_phone = dest_phone,
                Dest_address = dest_address,
            };

            string sql = @"Insert into dbo.Destinations (dest_name, dest_phone, dest_address)
                values (@Dest_name, @Dest_phone, @Dest_address);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int UpdateDestination(int dest_id, string dest_name,
            string dest_phone, string dest_address)
        {
            DestinationModel data = new DestinationModel
            {
                Dest_id = dest_id,
                Dest_name = dest_name,
                Dest_phone = dest_phone,
                Dest_address = dest_address
            };

            string sql = @"UPDATE dbo.Destinations  
            SET    dest_name = @DEST_NAME,  
                   dest_phone = @DEST_PHONE,  
                   dest_address = @DEST_ADDRESS  
            WHERE  dest_id = @DEST_ID;";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int DeleteDestination(int dest_id)
        {
            DestinationModel data = new DestinationModel
            {
                Dest_id = dest_id
            };

            string sql = "DELETE FROM dbo.Destinations  WHERE  dest_id = @DEST_ID;";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<DestinationModel> LoadDestinations()
        {
            string sql = "Select * from dbo.Destinations;";

            return SqlDataAccess.LoadData<DestinationModel>(sql);
        }

        public static List<DestinationModel> LoadDestinations(int id)
        {
            string sql = "Select * from dbo.Destinations WHERE dest_id = '" + id + "';";

            return SqlDataAccess.LoadData<DestinationModel>(sql);
        }
    }
}
