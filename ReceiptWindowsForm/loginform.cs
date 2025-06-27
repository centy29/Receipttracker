using System;
using System.Drawing;
using System.Windows.Forms;
using ReceiptDataLayer;

namespace ReceiptWindowsForm
{
    public partial class loginform : Form
    {
        public loginform()
        {
            InitializeComponent();

            this.BackgroundImage = Image.FromFile("receiptbackround.jpeg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void welcomelbl(object sender, EventArgs e)
        {
           
        }

        private void pinlbl(object sender, EventArgs e)
        {
            
        }

        private void inputpintxt(object sender, EventArgs e)
        {
            
        }

        private void loginbtn(object sender, EventArgs e)
        {
            string pin = textBox1.Text.Trim();

            DBReceiptData db = new DBReceiptData();
            string name = db.GetNameByPin(pin);

            if (name != null && name != "")
            {
                MessageBox.Show("Welcome, " + name + "!", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainDBForm mainForm = new MainDBForm();
                this.Hide();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid PIN. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void registerbtn(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            this.Hide();
            registerForm.Show();
        }

        private void exitbtn(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
