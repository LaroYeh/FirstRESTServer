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
        public PersonPersistence(){}

        /// <summary>
        /// 取得對象(單一)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Person> getPerson()
        {
            List<Person> personList = new List<Person>();
            string sql = "SELECT * FROM [Person]";
            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Person person = new Person();
                        person.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                        person.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                        person.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                        person.PayRate = reader.GetDecimal(reader.GetOrdinal("PayRate"));
                        person.StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
                        personList.Add(person);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return personList;
        }
        /// <summary>
        /// 取得對象(單一)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Person getPerson(int id)
        {
            Person person = new Person();
            string sql = "SELECT * FROM [Person] WHERE ID = @ID";
            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        person.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                        person.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                        person.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                        person.PayRate = reader.GetDecimal(reader.GetOrdinal("PayRate"));
                        person.StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return person;
        }

        /// <summary>
        /// 新增對象
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public int addPerson(Person person)
        {
            string sql = @"
                INSERT INTO [Person] ([FirstName],[LastName],[PayRate],[StartDate],[UpdDate])
                VALUES (@FirstName, @LastName, @PayRate, @StartDate, @updDate);
                SELECT IDENT_CURRENT ('Person') AS Current_Identity;";
            int id = -1; 
            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("FirstName", SqlDbType.NVarChar, 50).Value = person.FirstName;
                    cmd.Parameters.Add("LastName", SqlDbType.NVarChar, 50).Value = person.LastName;
                    cmd.Parameters.Add("PayRate", SqlDbType.Decimal).Value = person.PayRate;
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

        /// <summary>
        /// 刪除對象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool delPerson(int id)
        {
            bool result = false;
            string sql = "SELECT * FROM [Person] WHERE ID=@ID";
            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        reader.Close();
                        cmd.CommandText = "DELETE [Person] WHERE ID = @ID";
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                    else
                        result = false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;

        }


    }
}