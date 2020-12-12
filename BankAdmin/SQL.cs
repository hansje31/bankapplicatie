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

        public List<string> GetUserName()
        {
            return database.List("SELECT voornaam from `user`", "voornaam");
        }

        public void InsertClass(Type t, object instance)
        {
            var collumns = ClassReader.AttributeList(t);
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
            string query = String.Format("INSERT INTO user ({0}) VALUES({1})",sb.ToString(),sb2.ToString());
            database.CustomQuery(query);
        }

    }
}
