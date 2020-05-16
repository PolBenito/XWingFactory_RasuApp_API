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
    public class ReferenceTypesController : ApiController
    {
        String cadenaconexio;

        public ReferenceTypesController()
        {
            cadenaconexio = @"Server = tcp:thegungansalesians.database.windows.net,1433; Initial Catalog = XWingsFactory; Persist Security Info = False; User ID = gungan; Password = 12345aA12345aA; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        }

        [HttpGet]
        public List<ReferenceTypes> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM ReferenceTypes";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            List<ReferenceTypes> details = new List<ReferenceTypes>();

            while (reader.Read())
            {
                ReferenceTypes det = new ReferenceTypes();

                det.idReferenceType = Convert.ToInt16(reader.GetValue(0));
                det.codeReferenceType = Convert.ToString(reader.GetValue(1));
                det.descReferenceType = Convert.ToString(reader.GetValue(2));

                details.Add(det);
            }

            myConnection.Close();

            return details;
        }

        [HttpGet]

        public ReferenceTypes Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM ReferenceTypes WHERE id=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            ReferenceTypes aid = null;

            while (reader.Read())
            {
                aid = new ReferenceTypes();

                aid.idReferenceType = Convert.ToInt16(reader.GetValue(0));
                aid.codeReferenceType = Convert.ToString(reader.GetValue(1));
                aid.descReferenceType = Convert.ToString(reader.GetValue(2));
            }

            myConnection.Close();

            return aid;
        }
    }
}
