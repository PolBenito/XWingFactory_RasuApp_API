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
    public class UserTypesController : ApiController
    {
        String cadenaconexio;

        public UserTypesController()
        {
            cadenaconexio = @"Server = tcp:thegungansalesians.database.windows.net,1433; Initial Catalog = XWingsFactory; Persist Security Info = False; User ID = gungan; Password = 12345aA12345aA; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        }

        [HttpGet]
        public List<UserTypes> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM UserTypes";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            List<UserTypes> details = new List<UserTypes>();

            while (reader.Read())
            {
                UserTypes det = new UserTypes();

                det.idUserType = Convert.ToInt16(reader.GetValue(0));
                det.codeUserType = Convert.ToString(reader.GetValue(1));
                det.descUserType = Convert.ToString(reader.GetValue(2));

                details.Add(det);
            }

            myConnection.Close();

            return details;
        }

        [HttpGet]

        public UserTypes Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM UserTypes WHERE id=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            UserTypes aid = null;

            while (reader.Read())
            {
                aid = new UserTypes();

                aid.idUserType = Convert.ToInt16(reader.GetValue(0));
                aid.codeUserType = Convert.ToString(reader.GetValue(1));
                aid.descUserType = Convert.ToString(reader.GetValue(2));
            }

            myConnection.Close();

            return aid;
        }
    }
}
