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
        int page = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (page == 0)
            {
                bool error = true;
                while (error == true)
                {
                    error = false;
                    try
                    {
                        user.UserId = int.Parse(textBox1.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Please type in a number");
                    }
                }
            }
            else if (page == 1)
            {

            }
        }
    }
}
