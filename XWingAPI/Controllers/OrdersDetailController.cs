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
    public class OrdersDetailController : ApiController
    {
        String cadenaconexio;

        public OrdersDetailController()
        {
            cadenaconexio = @"Server = tcp:thegungansalesians.database.windows.net,1433; Initial Catalog = XWingsFactory; Persist Security Info = False; User ID = gungan; Password = 12345aA12345aA; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        }

        [HttpGet]
        public List<OrdersDetail> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM OrdersDetail";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            List<OrdersDetail> details = new List<OrdersDetail>();

            while (reader.Read())
            {
                OrdersDetail det = new OrdersDetail();

                det.idOrderDetail = Convert.ToInt16(reader.GetValue(0));
                det.idOrder = Convert.ToInt16(reader.GetValue(1));
                det.idPlanet = Convert.ToInt16(reader.GetValue(2));
                det.idReference = Convert.ToInt16(reader.GetValue(3));
                det.Quantity = Convert.ToInt16(reader.GetValue(4));
                det.DeliveryDate = Convert.ToDateTime(reader.GetValue(5));

                details.Add(det);
            }

            myConnection.Close();

            return details;
        }

        [HttpGet]

        public OrdersDetail Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM OrdersDetail WHERE id=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            OrdersDetail aid = null;

            while (reader.Read())
            {
                aid = new OrdersDetail();

                aid.idOrderDetail = Convert.ToInt16(reader.GetValue(0));
                aid.idOrder = Convert.ToInt16(reader.GetValue(1));
                aid.idPlanet = Convert.ToInt16(reader.GetValue(2));
                aid.idReference = Convert.ToInt16(reader.GetValue(3));
                aid.Quantity = Convert.ToInt16(reader.GetValue(4));
                aid.DeliveryDate = Convert.ToDateTime(reader.GetValue(5));
            }

            myConnection.Close();

            return aid;
        }
    }
}
