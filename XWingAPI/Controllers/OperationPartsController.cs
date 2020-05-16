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
    public class OperationPartsController : ApiController
    {
        String cadenaconexio;

        public OperationPartsController()
        {
            cadenaconexio = @"Server = tcp:thegungansalesians.database.windows.net,1433; Initial Catalog = XWingsFactory; Persist Security Info = False; User ID = gungan; Password = 12345aA12345aA; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        }

        [HttpGet]
        public List<OperationParts> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM OperationParts";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            List<OperationParts> details = new List<OperationParts>();

            while (reader.Read())
            {
                OperationParts det = new OperationParts();

                det.idOperationParts = Convert.ToInt16(reader.GetValue(0));
                det.idAssemblyInstructionsDetail = Convert.ToInt16(reader.GetValue(1));
                det.idReference = Convert.ToInt16(reader.GetValue(2));
                det.NumberOfPieces = Convert.ToInt16(reader.GetValue(3));

                details.Add(det);
            }

            myConnection.Close();

            return details;
        }

        [HttpGet]

        public OperationParts Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM OperationParts WHERE id=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            OperationParts aid = null;

            while (reader.Read())
            {
                aid = new OperationParts();

                aid.idOperationParts = Convert.ToInt16(reader.GetValue(0));
                aid.idAssemblyInstructionsDetail = Convert.ToInt16(reader.GetValue(1));
                aid.idReference = Convert.ToInt16(reader.GetValue(2));
                aid.NumberOfPieces = Convert.ToInt16(reader.GetValue(3));
            }

            myConnection.Close();

            return aid;
        }
    }
}
