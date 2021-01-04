using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAdmin
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }
        User user = new User();
        BankDetails bank = new BankDetails();
        int page = 0;
        bool error = false;
        private void button1_Click(object sender, EventArgs e)
        {
                if (page == 0)
                {
                    user.FirstName = textBox1.Text;
                    lblUserDataName.Text = "last name";
                }
                else if (page == 1)
                {
                    user.LastName = textBox1.Text;
                    lblUserDataName.Text = "gender";
                }
                else if (page == 2)
                {
                    user.Gender = textBox1.Text;
                    lblUserDataName.Text = "email";
                }
                else if (page == 3)
                {
                    user.Email = textBox1.Text;
                    lblUserDataName.Text = "city";
                }
                else if (page == 4)
                {
                    user.City = textBox1.Text;
                    lblUserDataName.Text = "postal code";
                }
                else if (page == 5)
                {
                    user.PostalCode = textBox1.Text;
                    lblUserDataName.Text = "street";
                }
                else if (page == 6)
                {
                    user.Street = textBox1.Text;
                    lblUserDataName.Text = "telephone";
                }
                else if (page == 7)
                {
                    try
                    {
                        user.Telephone = int.Parse(textBox1.Text);
                        error = false;
                        lblUserDataName.Text = "pin";
                    }
                    catch
                    {
                        MessageBox.Show("Please type in a number");
                        error = true;
                    }
                }
                else if (page == 8)
                {
                    user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(textBox1.Text);
                    Form1.globalUser = user;
                    this.Close();
                }
            if (error == false)
            {
                textBox1.Text = "";
                page++;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, null);
            }
        }
    }
}
