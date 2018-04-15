using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using FirstRESTServer.Models;

namespace FirstRESTServer
{
    public class PersonPersistence
    {
        string connStr = ConfigurationManager.ConnectionStrings["MyMSSQL"].ConnectionString;
        //SqlConnection conn = new SqlConnection();
        public PersonPersistence()
        {
            //try
            //{
            //    using (var conn = new SqlConnection(connStr))
            //    {
            //        conn.Open();
            //    }

            //}
            //catch (SqlException ex)
            //{
            //    throw;
            //}
        }
        //public string GetPerson(int id)
        //{

        //}
        public int addPerson(Person person)
        {
            string insData = @"
                INSERT INTO [Person] ([FirstName],[LastName],[PayRate],[StartDate],[updDate])
                VALUES (@FirstName, @LastName, @PayRate, @StartDate, @updDate);
                SELECT IDENT_CURRENT ('Person') AS Current_Identity;";
            int id = 0; 
            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    
                    SqlCommand cmd = new SqlCommand(insData,conn);
                    //cmd.Parameters.Add("ID", SqlDbType.Int).Value = person.ID;
                    cmd.Parameters.Add("FirstName", SqlDbType.NVarChar, 50).Value = person.FirstName;
                    cmd.Parameters.Add("LastName", SqlDbType.NVarChar, 50).Value = person.LastName;
                    cmd.Parameters.Add("PayRate", SqlDbType.Float).Value = person.PayRate;
                    cmd.Parameters.Add("StartDate", SqlDbType.DateTime).Value = person.StartDate.ToString("yyyy-MM-dd HH:mm:ss");
                    cmd.Parameters.Add("updDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return id;
        }

    }
}