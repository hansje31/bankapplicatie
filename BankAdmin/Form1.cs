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
        Random rnd = new Random();
        public static User globalUser;
        public List<User> databaseCache;

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
            databaseCache = sql.GetUserNamesBankNumbers();
            GetUserNames();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var id = ((int[])comboBoxUsers.Tag)[comboBoxUsers.SelectedIndex];
            var user = sql.GetSingleUser(id.ToString());
            var EditUserDialog = new EditUserForm(user);
            EditUserDialog.ShowDialog();
        }

        public void GetUserNames()
        {
            // put 'name' data in database into combobox
            databaseCache = sql.GetUserNamesBankNumbers();
            comboBoxUsers.DataSource = databaseCache.Select(x=> x.FirstName).ToArray();
            comboBoxUsers.Tag = databaseCache.Select(x => x.UserId).ToArray();

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var AddUserDialog = new AddUserForm();
            AddUserDialog.ShowDialog();
            sql.InsertClass(typeof(User), globalUser);
            var userId = sql.LastId("user", "user_id");
            var bankdetails = new BankDetails() { BankAccountNumber = GenerateBankNumber(), BankAccountPin = globalUser.Password, BankBalance = 0, UserId = userId };
            sql.InsertClass(typeof(BankDetails), bankdetails);
            GetUserNames();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                var result = databaseCache.Where(name => name.FirstName.Contains(txtSearch.Text) || ((Dictionary<string, string>)name.JoinCollumns)["bank_rekeningnummer"].Contains(txtSearch.Text));
                comboBoxUsers.DataSource = result.Select(x => x.FirstName).ToArray();
                comboBoxUsers.Tag = result.Select(x => x.UserId).ToArray();
            }
            else
            {
                comboBoxUsers.DataSource = databaseCache.Select(x=> x.FirstName).ToArray();
                comboBoxUsers.Tag = databaseCache.Select(x => x.UserId).ToArray();
            }
            comboBoxUsers.Focus();
            comboBoxUsers.DroppedDown = true;
        }
        private Int64 GenerateBankNumber()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 9; i++)
            {
                sb.Append(rnd.Next(0, 9));
            }
            return Convert.ToInt64(sb.ToString());
        }
    }
}
