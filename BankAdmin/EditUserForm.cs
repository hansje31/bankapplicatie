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
    }
}
