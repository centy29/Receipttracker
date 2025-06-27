using System;
using System.Windows.Forms;
using System.Xml.Linq;
using ReceiptCommon;
using ReceiptDataLayer;

namespace ReceiptTrackerWin
{
    public partial class RegisterForm : Form
    {
        private DBReceiptData db = new DBReceiptData();

        public RegisterForm()
        {
            InitializeComponent();
        }
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label txtPin;

        private void btnBack_Click(object sender, EventArgs e) => Close();

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string pin = txtPin.Text.Trim();
            string name = txtName.Text.Trim();

            if (string.IsNullOrEmpty(pin) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter both name and PIN.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Proceed with registration logic
            MessageBox.Show($"Registered:\nName: {name}\nPIN: {pin}", "Registered");
        }


        private void InitializeComponent()
        {
            // lblName
            this.lblName = new System.Windows.Forms.Label();
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(50, 50);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(42, 15);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name:";

            // txtName
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtName.Location = new System.Drawing.Point(130, 45);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 23);
            this.txtName.TabIndex = 6;

        }
    }
}
