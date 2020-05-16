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
    public class StockMovementTypesController : ApiController
    {
        String cadenaconexio;

        public StockMovementTypesController()
        {
            cadenaconexio = @"Server = tcp:thegungansalesians.database.windows.net,1433; Initial Catalog = XWingsFactory; Persist Security Info = False; User ID = gungan; Password = 12345aA12345aA; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        }

        [HttpGet]
        public List<StockMovementTypes> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM StockMovementTypes";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            List<StockMovementTypes> details = new List<StockMovementTypes>();

            while (reader.Read())
            {
                StockMovementTypes det = new StockMovementTypes();

                det.idStockMovementTypes = Convert.ToInt16(reader.GetValue(0));
                det.codeStockMovementTypes = Convert.ToString(reader.GetValue(1));
                det.descStockMovementTypes = Convert.ToString(reader.GetValue(2));

                details.Add(det);
            }

            myConnection.Close();

            return details;
        }

        [HttpGet]

        public StockMovementTypes Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM StockMovementTypes WHERE id=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            StockMovementTypes aid = null;

            while (reader.Read())
            {
                aid = new StockMovementTypes();

                aid.idStockMovementTypes = Convert.ToInt16(reader.GetValue(0));
                aid.codeStockMovementTypes = Convert.ToString(reader.GetValue(1));
                aid.descStockMovementTypes = Convert.ToString(reader.GetValue(2));
            }

            myConnection.Close();

            return aid;
        }
    }
}
