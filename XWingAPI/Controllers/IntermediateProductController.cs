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
    public class IntermediateProductController : ApiController
    {
        String cadenaconexio;

        public IntermediateProductController()
        {
            cadenaconexio = @"Server = tcp:thegungansalesians.database.windows.net,1433; Initial Catalog = XWingsFactory; Persist Security Info = False; User ID = gungan; Password = 12345aA12345aA; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        }

        [HttpGet]
        public List<IntermediateProduct> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM IntermediateProduct";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            List<IntermediateProduct> details = new List<IntermediateProduct>();

            while (reader.Read())
            {
                IntermediateProduct det = new IntermediateProduct();

                det.idIntermediateProduct = Convert.ToInt16(reader.GetValue(0));
                det.idReference = Convert.ToInt16(reader.GetValue(1));
                det.idLOPDetail = Convert.ToInt16(reader.GetValue(2));
                det.ReferenceCode = Convert.ToString(reader.GetValue(3));
                det.idStatus = Convert.ToInt16(reader.GetValue(4));
                det.idUser = Convert.ToInt16(reader.GetValue(5));

                details.Add(det);
            }

            myConnection.Close();

            return details;
        }

        [HttpGet]

        public IntermediateProduct Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM IntermediateProduct WHERE id=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            IntermediateProduct aid = null;

            while (reader.Read())
            {
                aid = new IntermediateProduct();

                aid.idIntermediateProduct = Convert.ToInt16(reader.GetValue(0));
                aid.idReference = Convert.ToInt16(reader.GetValue(1));
                aid.idLOPDetail = Convert.ToInt16(reader.GetValue(2));
                aid.ReferenceCode = Convert.ToString(reader.GetValue(3));
                aid.idStatus = Convert.ToInt16(reader.GetValue(4));
                aid.idUser = Convert.ToInt16(reader.GetValue(5));
            }

            myConnection.Close();

            return aid;
        }
    }
}
