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
    public class StocksController : ApiController
    {
        String cadenaconexio;

        public StocksController()
        {
            cadenaconexio = @"Server = tcp:thegungansalesians.database.windows.net,1433; Initial Catalog = XWingsFactory; Persist Security Info = False; User ID = gungan; Password = 12345aA12345aA; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        }

        [HttpGet]
        public List<Stocks> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM Stocks";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            List<Stocks> details = new List<Stocks>();

            while (reader.Read())
            {
                Stocks det = new Stocks();

                det.idStock = Convert.ToInt16(reader.GetValue(0));
                det.idReference = Convert.ToInt16(reader.GetValue(1));
                det.Stock1 = Convert.ToInt16(reader.GetValue(2));

                details.Add(det);
            }

            myConnection.Close();

            return details;
        }

        [HttpGet]

        public Stocks Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM Stocks WHERE id=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            Stocks aid = null;

            while (reader.Read())
            {
                aid = new Stocks();

                aid.idStock = Convert.ToInt16(reader.GetValue(0));
                aid.idReference = Convert.ToInt16(reader.GetValue(1));
                aid.Stock1 = Convert.ToInt16(reader.GetValue(2));
            }

            myConnection.Close();

            return aid;
        }
    }
}
