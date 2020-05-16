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
    public class FinalProductController : ApiController
    {
        String cadenaconexio;

        public FinalProductController()
        {
            cadenaconexio = @"Server = tcp:thegungansalesians.database.windows.net,1433; Initial Catalog = XWingsFactory; Persist Security Info = False; User ID = gungan; Password = 12345aA12345aA; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        }

        [HttpGet]
        public List<FinalProduct> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM FinalProduct";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            List<FinalProduct> details = new List<FinalProduct>();

            while (reader.Read())
            {
                FinalProduct det = new FinalProduct();

                det.idFinalProduct = Convert.ToInt16(reader.GetValue(0));
                det.idReference = Convert.ToInt16(reader.GetValue(1));
                det.codeProduct = Convert.ToString(reader.GetValue(2));
                det.idStatus = Convert.ToInt16(reader.GetValue(3));
                det.idLOPDetail = Convert.ToInt16(reader.GetValue(4));

                details.Add(det);
            }

            myConnection.Close();

            return details;
        }

        [HttpGet]

        public FinalProduct Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM FinalProduct WHERE id=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            FinalProduct aid = null;

            while (reader.Read())
            {
                aid = new FinalProduct();

                aid.idFinalProduct = Convert.ToInt16(reader.GetValue(0));
                aid.idReference = Convert.ToInt16(reader.GetValue(1));
                aid.codeProduct = Convert.ToString(reader.GetValue(2));
                aid.idStatus = Convert.ToInt16(reader.GetValue(3));
                aid.idLOPDetail = Convert.ToInt16(reader.GetValue(4));
            }

            myConnection.Close();

            return aid;
        }
    }
}
