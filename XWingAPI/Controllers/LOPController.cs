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
    public class LOPController : ApiController
    {
        String cadenaconexio;

        public LOPController()
        {
            cadenaconexio = @"Server = tcp:thegungansalesians.database.windows.net,1433; Initial Catalog = XWingsFactory; Persist Security Info = False; User ID = gungan; Password = 12345aA12345aA; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        }

        [HttpGet]
        public List<LOP> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM LOP";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            List<LOP> details = new List<LOP>();

            while (reader.Read())
            {
                LOP det = new LOP();

                det.idLOP = Convert.ToInt16(reader.GetValue(0));
                det.idOrder = Convert.ToInt16(reader.GetValue(1));

                details.Add(det);
            }

            myConnection.Close();

            return details;
        }

        [HttpGet]

        public LOP Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM LOP WHERE id=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            LOP aid = null;

            while (reader.Read())
            {
                aid = new LOP();

                aid.idLOP = Convert.ToInt16(reader.GetValue(0));
                aid.idOrder = Convert.ToInt16(reader.GetValue(1));
            }

            myConnection.Close();

            return aid;
        }
    }
}
