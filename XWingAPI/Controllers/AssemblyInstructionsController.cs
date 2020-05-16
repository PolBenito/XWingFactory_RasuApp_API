using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.Http;
using XWingAPI.Models;

namespace XWingAPI.Controllers
{
    public class AssemblyInstructionsController : ApiController
    {
        String cadenaconexio;

        public AssemblyInstructionsController()
        {
            cadenaconexio = @"Server = tcp:thegungansalesians.database.windows.net,1433; Initial Catalog = XWingsFactory; Persist Security Info = False; User ID = gungan; Password = 12345aA12345aA; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        }

        [HttpGet]
        public List<AssemblyInstructions> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM AssemblyInstructions";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            List<AssemblyInstructions> details = new List<AssemblyInstructions>();

            while (reader.Read())
            {
                AssemblyInstructions det = new AssemblyInstructions();
                
                det.idAssemblyInstructions = Convert.ToInt16(reader.GetValue(0));
                det.idreference = Convert.ToInt16(reader.GetValue(1));
                det.Instructions = ObjectToByteArray(reader.GetValue(2));

                details.Add(det);
            }

            myConnection.Close();

            return details;
        }

        [HttpGet]

        //Select only one row
        public AssemblyInstructions Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM ASSEMBLYINSTRUCTIONS WHERE id=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            AssemblyInstructions aid = null;

            while (reader.Read())
            {
                aid = new AssemblyInstructions();

                aid.idAssemblyInstructions = Convert.ToInt16(reader.GetValue(0));
                aid.idreference = Convert.ToInt16(reader.GetValue(1));
                aid.Instructions = ObjectToByteArray(reader.GetValue(2));
            }

            myConnection.Close();

            return aid;
        }

        byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}
