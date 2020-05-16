using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XWingAPI.Models;

namespace XWingAPI.Controllers
{
    public class StockMovementsController : ApiController
    {
        String cadenaconexio;

        public StockMovementsController()
        {
            cadenaconexio = @"Server = tcp:thegungansalesians.database.windows.net,1433; Initial Catalog = XWingsFactory; Persist Security Info = False; User ID = gungan; Password = 12345aA12345aA; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        }

        [HttpGet]
        public List<StockMovements> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM StockMovements";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            List<StockMovements> details = new List<StockMovements>();

            while (reader.Read())
            {
                StockMovements det = new StockMovements();

                det.idStockMovement = Convert.ToInt16(reader.GetValue(0));
                det.idStockMovementTypes = Convert.ToInt16(reader.GetValue(1));
                det.Quantity = Convert.ToInt16(reader.GetValue(2));
                det.idDocument = Convert.ToInt16(reader.GetValue(3));

                details.Add(det);
            }

            myConnection.Close();

            return details;
        }

        [HttpGet]

        public StockMovements Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM StockMovements WHERE id=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            StockMovements aid = null;

            while (reader.Read())
            {
                aid = new StockMovements();

                aid.idStockMovement = Convert.ToInt16(reader.GetValue(0));
                aid.idStockMovementTypes = Convert.ToInt16(reader.GetValue(1));
                aid.Quantity = Convert.ToInt16(reader.GetValue(2));
                aid.idDocument = Convert.ToInt16(reader.GetValue(3));
            }

            myConnection.Close();

            return aid;
        }
    }
}
