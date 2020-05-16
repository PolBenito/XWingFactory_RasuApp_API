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
    public class StatusController : ApiController
    {
        String cadenaconexio;

        public StatusController()
        {
            cadenaconexio = @"Server = tcp:thegungansalesians.database.windows.net,1433; Initial Catalog = XWingsFactory; Persist Security Info = False; User ID = gungan; Password = 12345aA12345aA; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        }

        [HttpGet]
        public List<Status> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM Status";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            List<Status> details = new List<Status>();

            while (reader.Read())
            {
                Status det = new Status();

                det.idStatus = Convert.ToInt16(reader.GetValue(0));
                det.codeStatus = Convert.ToString(reader.GetValue(1));
                det.descStatus = Convert.ToString(reader.GetValue(2));

                details.Add(det);
            }

            myConnection.Close();

            return details;
        }

        [HttpGet]

        public Status Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM Status WHERE id=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            Status aid = null;

            while (reader.Read())
            {
                aid = new Status();

                aid.idStatus = Convert.ToInt16(reader.GetValue(0));
                aid.codeStatus = Convert.ToString(reader.GetValue(1));
                aid.descStatus = Convert.ToString(reader.GetValue(2));
            }

            myConnection.Close();

            return aid;
        }
    }
}
