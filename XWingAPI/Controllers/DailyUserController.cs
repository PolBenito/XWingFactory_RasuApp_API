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
    public class DailyUserController : ApiController
    {
        String cadenaconexio;

        public DailyUserController()
        {
            cadenaconexio = @"Server = tcp:thegungansalesians.database.windows.net,1433; Initial Catalog = XWingsFactory; Persist Security Info = False; User ID = gungan; Password = 12345aA12345aA; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        }

        [HttpGet]
        public List<DailyUser> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM DailyUser";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            List<DailyUser> details = new List<DailyUser>();

            while (reader.Read())
            {
                DailyUser det = new DailyUser();

                det.idDailyUser = Convert.ToInt16(reader.GetValue(0));
                det.idUser = Convert.ToInt16(reader.GetValue(1));
                det.idAssemblyInstructions = Convert.ToInt16(reader.GetValue(2));

                details.Add(det);
            }

            myConnection.Close();

            return details;
        }

        [HttpGet]

        public DailyUser Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM DailyUser WHERE id=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            DailyUser aid = null;

            while (reader.Read())
            {
                aid = new DailyUser();

                aid.idDailyUser = Convert.ToInt16(reader.GetValue(0));
                aid.idUser = Convert.ToInt16(reader.GetValue(1));
                aid.idAssemblyInstructions = Convert.ToInt16(reader.GetValue(2));
            }

            myConnection.Close();

            return aid;
        }
    }
}
