using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Microsoft.VisualBasic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAdmin
{
    public partial class EditUserForm : Form
    {
        public static User globalUser;
        public EditUserForm(User portableUser)
        {
            InitializeComponent();
            globalUser = portableUser;
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            txtFirstName.Text = globalUser.FirstName;
            txtLastName.Text = globalUser.LastName;
            txtCity.Text = globalUser.City;
            txtEmail.Text = globalUser.Email;
            txtPostalCode.Text = globalUser.PostalCode;
            txtStreet.Text = globalUser.Street;
            txtTelephone.Text = globalUser.Telephone.ToString();
            txtGender.Text = globalUser.Gender;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var pin = Interaction.InputBox("Please type in the new pin", "New pin");
            globalUser.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(pin);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            globalUser.FirstName = txtFirstName.Text;
            globalUser.LastName = txtLastName.Text;
            globalUser.City = txtCity.Text;
            globalUser.Email = txtEmail.Text;
            globalUser.PostalCode = txtPostalCode.Text;
            globalUser.Street = txtStreet.Text;
            globalUser.Gender = txtGender.Text;
            int telephone;
            if (int.TryParse(txtTelephone.Text, out telephone) == true)
            {
                globalUser.Telephone = telephone;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please type in a number in the telephone field");
            }
            
        }
    }
}
