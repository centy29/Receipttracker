using System;
using System.Windows.Forms;
using ReceiptDataLayer;

namespace ReceiptWindowsForm
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            this.BackgroundImage = Image.FromFile("receiptbackround.jpeg"); 
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void registerbtn(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string pin = textBox2.Text.Trim();

            if (name == "" || pin == "")
            {
                MessageBox.Show("please complete inputing Name and PIN.", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DBReceiptData db = new DBReceiptData();
            bool isRegistered = db.RegisterAccount(name, pin);

            if (isRegistered)
            {
                MessageBox.Show("Registration for" + name + ".", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
      
                loginform login = new loginform();
                login.Show();
            }
            else
            {
                MessageBox.Show("Registration failed. try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backtologinbtn(object sender, EventArgs e)
        {
            this.Hide();
            loginform login = new loginform();
            login.Show();
        }
   
        private void namelbl(object sender, EventArgs e) { }
        private void enterpinlbl(object sender, EventArgs e) { }
        private void pintxtbox(object sender, EventArgs e) { }
    }
}
