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

        public List<string> GetUserName()
        {
            return database.List("SELECT * from `users`", "name");
        }

    }
}
