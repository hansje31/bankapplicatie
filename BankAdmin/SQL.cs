using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAdmin
{
    class SQL
    {

        // make sure you can access/use the Database.cs files functions in order to 'launch' these SQL queries so you can change the database
        Database database;
        public SQL(Database db)
        {
            database = db;
        }

        public User GetSingleUser(string id)
        {
            return User.LoadUser(database.SingleQueryToDictionary("select * from user where user_id = "+id, ClassReader.ClassToDictionary(typeof(User))));
        }
        public List<User> GetBankUserJoins()
        {
            var result = new List<User>();
            var users = database.QueryToDictionary("select * from user inner join bankdetails on user.user_id = bankdetails.user_id", ClassReader.ClassToDictionary(typeof(User)), "bank_rekeningnummer");
            foreach(var user in users)
            {
                result.Add(User.LoadUser(user,"bank_rekeningnummer"));
            }
            return result;
        }

        public List<string> GetUserNames()
        {
            return database.List("SELECT voornaam from `user`", "voornaam");
        }
        public string LastId(string table, string idColName)
        {
            return database.SingleResultQuery(String.Format("select MAX({0}) from {1}", idColName, table));
        }

        public void InsertClass(Type t, object instance)
        {
            var collumns = ClassReader.FieldNames(t);
            var values = ClassReader.ValuesList(t, instance);
            var sb = new StringBuilder();
            var sb2 = new StringBuilder();
            foreach(string collumn in collumns)
            {
                sb.Append(collumn + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            foreach (string value in values)
            {
                if(value=="")
                    sb2.Append("'0'" + ",");
                else
                    sb2.Append("'"+value+"'" + ",");
            }
            sb2.Remove(sb2.Length - 1, 1);
            var tablename = t.GetCustomAttributes(true).OfType<TableName>().First().value;
            string query = String.Format("INSERT INTO {0} ({1}) VALUES({2})",tablename,sb.ToString(),sb2.ToString());
            database.CustomQuery(query);
        }

    }
}
