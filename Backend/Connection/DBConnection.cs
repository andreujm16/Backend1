using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Backend.Connection
{
    public class DBConnection
    {
        SqlConnection cnn;
        private string server;
        private string db;
        private string user;
        private string password;

        public class conectionReturn
        {
            public SqlConnection connection { get; set; }
            public bool connected { get; set; }
        }

        //Constructor
        public void DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            
            server = System.Configuration.ConfigurationManager.AppSettings["server"].ToString();
            db = System.Configuration.ConfigurationManager.AppSettings["db"].ToString();
            user = System.Configuration.ConfigurationManager.AppSettings["user"].ToString();
            password = System.Configuration.ConfigurationManager.AppSettings["password"].ToString();

            string connectionString;
            connectionString = @"Data Source=" + server + ";Initial Catalog=" + db + ";User ID=" + user + ";Password=" + password + "";
            cnn = new SqlConnection(connectionString);

        }

        //open connection to database
        public conectionReturn OpenConnection()
        {
            try
            {
                Initialize();
                cnn.Open();

                return new conectionReturn { connected = true, connection = cnn };
            }
            catch (Exception e)
            {
                return new conectionReturn { connected = false, connection = cnn };
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                cnn.Close();
                cnn.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Dictionary<string, object>> getDataSQL(conectionReturn conection, string query)
        {
            //Create Command
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = 600;
            cmd.Connection = conection.connection;


            //Create a data reader and Execute the command
            SqlDataReader dataReader = cmd.ExecuteReader();

            var rows = new List<Dictionary<string, object>>();

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                var row = new Dictionary<string, object>();

                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    try
                    {
                        row.Add(dataReader.GetName(i), dataReader[i]);
                    }
                    catch
                    {
                        string name = dataReader.GetName(i);
                        //try
                        //{
                        //    var value = dataReader[i];
                        //}
                        //catch { }

                        row.Add(name, "");
                    }

                }

                rows.Add(row);

                row = null;
            }




            //close Data Reader
            dataReader.Close();
            dataReader.Dispose();

            cmd.Dispose();

            return rows;
        }

        public bool InsertUpdateOrDelete(conectionReturn conection, string query)
        {
            try
            {

                SqlCommand cmd = new SqlCommand();

                cmd.CommandTimeout = 150;
                cmd.CommandText = query;
                cmd.Connection = conection.connection;


                var q = cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}