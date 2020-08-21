using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PoojaLearn.Models
{
    public class Pooja
    {
      
        public string Name;
        public string Sex;
        public int Age;

    }


    public class PoojaDataAccess
    {
        public void UpsertPooja(Pooja emp)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["localDB"].ConnectionString);
            sqlConn.Open();
            SqlCommand sqlCmd = new SqlCommand("dbo.InsertData", sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Name", emp.Name);
            sqlCmd.Parameters.AddWithValue("@Age", emp.Age);
            sqlCmd.Parameters.AddWithValue("@Sex", emp.Sex);
            sqlCmd.ExecuteNonQuery();
            sqlConn.Close();
        }




        /*      public class PoojaProcesses
                   {
                       PoojaDataAccess empDA = new PoojaDataAccess();
                      public void UpsertPooja(Pooja emp)
                        {
                          empDA.UpsertPooja(emp);
                       }


              }

      */

        public class PoojaController : ApiController
        {
            PoojaDataAccess empProcess = new PoojaDataAccess();

            [HttpPost]
            [Route("Pooja/details/new")]
            public void SubmitEmployeeDetails(Pooja employee)
            {
                empProcess.UpsertPooja(employee);
            }


        }


    }
}