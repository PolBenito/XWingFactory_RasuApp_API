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
    public class ReferencesController : ApiController
    {
        String cadenaconexio;

        public ReferencesController()
        {
            cadenaconexio = @"Server = tcp:thegungansalesians.database.windows.net,1433; Initial Catalog = XWingsFactory; Persist Security Info = False; User ID = gungan; Password = 12345aA12345aA; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        }

        [HttpGet]
        public List<References> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM [References]";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            List<References> details = new List<References>();

            while (reader.Read())
            {
                References det = new References();

                det.idReference = Convert.ToInt16(reader.GetValue(0));
                det.codeReference = Convert.ToString(reader.GetValue(1));
                det.descReference = Convert.ToString(reader.GetValue(2));
                det.Photo = Convert.ToString(reader.GetValue(3));
                det.VideoExplode = Convert.ToString(reader.GetValue(4));
                det.idReferenceType = Convert.ToInt16(reader.GetValue(5));

                details.Add(det);
            }

            myConnection.Close();

            return details;
        }

        [HttpGet]

        public References Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM [References] WHERE id=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            References aid = null;

            while (reader.Read())
            {
                aid = new References();

                aid.idReference = Convert.ToInt16(reader.GetValue(0));
                aid.codeReference = Convert.ToString(reader.GetValue(1));
                aid.descReference = Convert.ToString(reader.GetValue(2));
                aid.Photo = Convert.ToString(reader.GetValue(3));
                aid.VideoExplode = Convert.ToString(reader.GetValue(4));
                aid.idReferenceType = Convert.ToInt16(reader.GetValue(5));
            }

            myConnection.Close();

            return aid;
        }
    }
}
