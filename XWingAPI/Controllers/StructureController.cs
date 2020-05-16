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
    public class StructureController : ApiController
    {
        String cadenaconexio;

        public StructureController()
        {
            cadenaconexio = @"Server = tcp:thegungansalesians.database.windows.net,1433; Initial Catalog = XWingsFactory; Persist Security Info = False; User ID = gungan; Password = 12345aA12345aA; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        }

        [HttpGet]
        public List<Structure> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM Structure";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            List<Structure> details = new List<Structure>();

            while (reader.Read())
            {
                Structure det = new Structure();

                det.idStructure = Convert.ToInt16(reader.GetValue(0));
                det.idReferenceFinal = Convert.ToInt16(reader.GetValue(1));
                det.idReferencePart = Convert.ToInt16(reader.GetValue(2));
                det.NumberOfParts = Convert.ToInt16(reader.GetValue(3));

                details.Add(det);
            }

            myConnection.Close();

            return details;
        }

        [HttpGet]

        public Structure Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM Structure WHERE id=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            Structure aid = null;

            while (reader.Read())
            {
                aid = new Structure();

                aid.idStructure = Convert.ToInt16(reader.GetValue(0));
                aid.idReferenceFinal = Convert.ToInt16(reader.GetValue(1));
                aid.idReferencePart = Convert.ToInt16(reader.GetValue(2));
                aid.NumberOfParts = Convert.ToInt16(reader.GetValue(3));
            }

            myConnection.Close();

            return aid;
        }
    }
}
