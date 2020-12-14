using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic;
using System.IO;

namespace BankAdmin // necessary code for application to run
{
    public partial class Form1 : Form // necessary code for application to run
    {

        // between tese parantheses you can code your code here, in most cases you would put your global variables here
        Database database;
        SQL sql;
        public static User globalUser;

        // variable containing usernames
        public string[] username = {};

        public Form1() // runs when the winForms GUI itself is being rendered...
        {
            InitializeComponent();

            // connection naar database maken
            string connectionString = "";
            try
            {
                // connectionstring is de file waar de connection naar database staat
                connectionString = File.ReadAllText(Directory.GetCurrentDirectory() + @"\connectionstring.txt");
            }
            catch
            {
                MessageBox.Show("Please make sure connectionstring.txt is in the same folder as this program.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            // connection naar de database, deze variabele connectionstring (met wachtwoordgegevens van de database en meer) word doorgevoerd naar Database class
            database = new Database(connectionString);
            // quizz class can now make use of Database class to connect to database
            sql = new SQL(database);
            GetUserNames();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x = new User();
            x.City = "a";
            x.Email = "b";
            x.FirstName = "you";
            var reader = new ClassReader();
            
            sql.InsertClass(typeof(User), x);

            GetUserNames();
        }

        public void GetUserNames()
        {
            // put 'name' data in database into combobox
            var GetUserName = sql.GetUserName();
            comboBox1.DataSource = GetUserName.ToArray();

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var AddUserDialog = new AddUserForm();
            AddUserDialog.ShowDialog();
            sql.InsertClass(typeof(User), globalUser);
            GetUserNames();
        }
    }
}
