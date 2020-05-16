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
    public class OrdersController : ApiController
    {
        String cadenaconexio;

        public OrdersController()
        {
            cadenaconexio = @"Server = tcp:thegungansalesians.database.windows.net,1433; Initial Catalog = XWingsFactory; Persist Security Info = False; User ID = gungan; Password = 12345aA12345aA; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        }

        [HttpGet]
        public List<Orders> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM Orders";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            List<Orders> details = new List<Orders>();

            while (reader.Read())
            {
                Orders det = new Orders();

                det.idOrder = Convert.ToInt16(reader.GetValue(0));
                det.codeOrder = Convert.ToString(reader.GetValue(1));
                det.dateOrder = Convert.ToDateTime(reader.GetValue(2));

                details.Add(det);
            }

            myConnection.Close();

            return details;
        }

        [HttpGet]

        public Orders Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM Orders WHERE id=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            Orders aid = null;

            while (reader.Read())
            {
                aid = new Orders();

                aid.idOrder = Convert.ToInt16(reader.GetValue(0));
                aid.codeOrder = Convert.ToString(reader.GetValue(1));
                aid.dateOrder = Convert.ToDateTime(reader.GetValue(2));
            }

            myConnection.Close();

            return aid;
        }
    }
}
