using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BankAdmin
{
    class Database
    {

        // connectionstring in this file now has value of connectionstring from another file AKA now being called conn, that is being passed through in form1.cs
        private string ConnectionString = "";
        public Database(string conn)
        {
            ConnectionString = conn;
        }

        // the connection is now being made to the database, you can now craft SQL queries to change the database (from this application)
        private MySqlConnection Connect()
        {
            var connection = new MySqlConnection(ConnectionString);
            try
            {
                connection.Open();
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
            return connection;
        }

        public List<string> List(string query, string collumn)
        {
            // creates list
            List<string> result = new List<string>();
            using (MySqlConnection connection = Connect())
            {
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 300;
                    cmd.CommandText = query;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // voeg collumn1 enzo toe in de dictionary
                            result.Add(reader[collumn].ToString());
                        }
                    }
                }
            }
            return result;
        }
    
        public void CustomQuery(string query)
        {
            using (MySqlConnection connection = Connect())
            {
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 300;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        //creates a dictionary that matches the property names of a class to the values in the db, using specific queries such as users where id = 1;
        public Dictionary<string,string> SingleQueryToDictionary(string query, Dictionary<string,string> dict)
        {
            Dictionary<string,string> result = new Dictionary<string, string>();
            using (MySqlConnection connection = Connect())
            {
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 300;
                    cmd.CommandText = query;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        foreach (string key in dict.Keys)
                        {
                            result.Add(dict[key], reader[key].ToString());
                        }
                        
                    }
                }
            }
            return result;
        }
    }
}
