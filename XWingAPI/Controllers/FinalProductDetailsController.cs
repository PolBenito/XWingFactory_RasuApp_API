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
    public class FinalProductDetailsController : ApiController
    {
        String cadenaconexio;

        public FinalProductDetailsController()
        {
            cadenaconexio = @"Server = tcp:thegungansalesians.database.windows.net,1433; Initial Catalog = XWingsFactory; Persist Security Info = False; User ID = gungan; Password = 12345aA12345aA; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        }

        [HttpGet]
        public List<FinalProductDetails> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM FinalProductDetails";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            List<FinalProductDetails> details = new List<FinalProductDetails>();

            while (reader.Read())
            {
                FinalProductDetails det = new FinalProductDetails();

                det.idFinalProductDetail = Convert.ToInt16(reader.GetValue(0));
                det.idFinalProduct = Convert.ToInt16(reader.GetValue(1));
                det.idIntermediateProduct = Convert.ToInt16(reader.GetValue(2));

                details.Add(det);
            }

            myConnection.Close();

            return details;
        }

        [HttpGet]

        public FinalProductDetails Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM FinalProductDetails WHERE id=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            FinalProductDetails aid = null;

            while (reader.Read())
            {
                aid = new FinalProductDetails();

                aid.idFinalProductDetail = Convert.ToInt16(reader.GetValue(0));
                aid.idFinalProduct = Convert.ToInt16(reader.GetValue(1));
                aid.idIntermediateProduct = Convert.ToInt16(reader.GetValue(2));
            }

            myConnection.Close();

            return aid;
        }
    }
}
