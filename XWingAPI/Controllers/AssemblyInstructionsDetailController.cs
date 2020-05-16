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
    public class AssemblyInstructionsDetailController : ApiController
    {
        String cadenaconexio;

        public AssemblyInstructionsDetailController()
        {
            cadenaconexio = @"Server = tcp:thegungansalesians.database.windows.net,1433; Initial Catalog = XWingsFactory; Persist Security Info = False; User ID = gungan; Password = 12345aA12345aA; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            
        }

        [HttpGet]
        public List<AssemblyInstructionsDetail> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM AssemblyInstructionsDetail";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            List<AssemblyInstructionsDetail> details = new List<AssemblyInstructionsDetail>();

            while (reader.Read())
            {
                AssemblyInstructionsDetail det = new AssemblyInstructionsDetail();

                det.idAssemblyInstructionsDetail = Convert.ToInt16(reader.GetValue(0));
                det.idAssemblyInstructions = Convert.ToInt16(reader.GetValue(1));
                det.CodeOperation = reader.GetValue(2).ToString();
                det.DescOperation = reader.GetValue(3).ToString();
                det.NumberOfUsers = Convert.ToInt16(reader.GetValue(4));
                det.OperationOrder = Convert.ToInt16(reader.GetValue(5));

                details.Add(det);
            }

            myConnection.Close();

            return details;
        }

        [HttpGet]

        public AssemblyInstructionsDetail Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexio;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM ASSEMBLYINSTRUCTIONSDETAIL WHERE id=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            AssemblyInstructionsDetail aid = null;

            while (reader.Read())
            {
                aid = new AssemblyInstructionsDetail();

                aid.idAssemblyInstructionsDetail = Convert.ToInt16(reader.GetValue(0));
                aid.idAssemblyInstructions = Convert.ToInt16(reader.GetValue(1));
                aid.CodeOperation = reader.GetValue(2).ToString();
                aid.DescOperation = reader.GetValue(3).ToString();
                aid.NumberOfUsers = Convert.ToInt16(reader.GetValue(4));
                aid.OperationOrder = Convert.ToInt16(reader.GetValue(5));
            }

            myConnection.Close();

            return aid;
        }
    }
}
