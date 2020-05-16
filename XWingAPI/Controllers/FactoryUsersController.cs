using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XWingAPI.Models;

namespace XWingAPI.Controllers
{
    public class FactoryUsersController : ApiController
    {
        String cadenaconexio;

        public FactoryUsersController()
        {
            cadenaconexio = @"Server = tcp:thegungansalesians.database.windows.net,1433; Initial Catalog = XWingsFactory; Persist Security Info = False; User ID = gungan; Password = 12345aA12345aA; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        }

        [HttpGet]
        public List<FactoryUsers> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM FactoryUsers";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            List<FactoryUsers> details = new List<FactoryUsers>();

            while (reader.Read())
            {
                FactoryUsers det = new FactoryUsers();

                det.idUser = Convert.ToInt16(reader.GetValue(0));
                det.UserName = reader.GetValue(1).ToString();
                det.idUserType = Convert.ToInt16(reader.GetValue(2));
                det.password = reader.GetValue(3).ToString();

                details.Add(det);
            }

            myConnection.Close();

            return details;
        }

        [HttpGet]

        public FactoryUsers Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM FactoryUsers WHERE id=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            FactoryUsers aid = null;

            while (reader.Read())
            {
                aid = new FactoryUsers();

                aid.idUser = Convert.ToInt16(reader.GetValue(0));
                aid.UserName = reader.GetValue(1).ToString();
                aid.idUserType = Convert.ToInt16(reader.GetValue(2));
                aid.password = reader.GetValue(3).ToString();
            }

            myConnection.Close();

            return aid;
        }
    }
}
