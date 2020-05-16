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
    public class LOPDetailsController : ApiController
    {
        String cadenaconexio;

        public LOPDetailsController()
        {
            cadenaconexio = @"Server = tcp:thegungansalesians.database.windows.net,1433; Initial Catalog = XWingsFactory; Persist Security Info = False; User ID = gungan; Password = 12345aA12345aA; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        }

        [HttpGet]
        public List<LOPDetails> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM LOPDetails";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            List<LOPDetails> details = new List<LOPDetails>();

            while (reader.Read())
            {
                LOPDetails det = new LOPDetails();

                det.idLOPDetail = Convert.ToInt16(reader.GetValue(0));
                det.idLOP = Convert.ToInt16(reader.GetValue(1));
                det.idReference = Convert.ToInt16(reader.GetValue(2));
                det.Quantity = Convert.ToInt16(reader.GetValue(3));

                details.Add(det);
            }

            myConnection.Close();

            return details;
        }

        [HttpGet]

        public LOPDetails Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM LOPDetails WHERE id=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            LOPDetails aid = null;

            while (reader.Read())
            {
                aid = new LOPDetails();

                aid.idLOPDetail = Convert.ToInt16(reader.GetValue(0));
                aid.idLOP = Convert.ToInt16(reader.GetValue(1));
                aid.idReference = Convert.ToInt16(reader.GetValue(2));
                aid.Quantity = Convert.ToInt16(reader.GetValue(3));
            }

            myConnection.Close();

            return aid;
        }
    }
}
