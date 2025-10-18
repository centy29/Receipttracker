using ReceiptCommon;
using ReceiptDataLayer;
using recieptlogicemail;
using System;
using System.Windows.Forms;

namespace ReceiptWindowsForm
{
    public partial class MainDBForm : Form
    {
        private DBReceiptinfo db = new DBReceiptinfo();

        public MainDBForm()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("maindbbackground.jpg"); //syntax for adding piture background
            this.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void LoadReceipts()
        {
            dataGridView1.DataSource = db.GetAllRecieptInfos(); //constructor for loading the receipts
        }

        private void backbtn(object sender, EventArgs e)
        {
            this.Hide();
            loginform back = new loginform();
            back.Show();
        }

        private void searchbtn(object sender, EventArgs e)
        {
            int invoice;
            if (int.TryParse(textBox1.Text.Trim(), out invoice))
            {
                var receipt = db.GetInvoice(invoice);
                if (receipt != null)
                {
                    MessageBox.Show("Receipt found: " + receipt.brand + ", with an Amount of: " + receipt.amount.ToString());
                }
                else
                {
                    MessageBox.Show("No receipt found with invoice number like that.");
                }
            }
            else
            {
                MessageBox.Show(" enter a valid invoice number!");
            }
        }

        private void addbtn(object sender, EventArgs e)
        {
            try
            {
                DBinfos receipt = new DBinfos();
                receipt.invoice = int.Parse(textBoxInvoice.Text.Trim());
                receipt.brand = textBoxBrand.Text.Trim();
                receipt.address = textBoxAddress.Text.Trim();
                receipt.tin = int.Parse(textBoxTin.Text.Trim());
                receipt.amount = decimal.Parse(textBoxAmount.Text.Trim());

                bool isAdded = db.AddReceipt(receipt); // if adding receipt is true or false

                if (isAdded)
                {
                    MessageBox.Show(" the Receipt added successfully.");
                    LoadReceipts();
                }
                else
                {
                    MessageBox.Show("system Failed to add receipt.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input. complete your info!");
            }
        }


        private void deletebtn(object sender, EventArgs e)
        {
            int invoice;
            if (int.TryParse(textBoxInvoice.Text.Trim(), out invoice))
            {
                bool deleted = db.DeleteReceipt(invoice);
                if (deleted)
                {
                    MessageBox.Show("Receipt deleted completely.");
                    LoadReceipts();
                }
                else
                {
                    MessageBox.Show("system Failed to delete receipt. Check the selected invoice number.");
                }
            }
            else
            {
                MessageBox.Show("Enter a invoice number to delete.");
            }
        }


        private void retrievebtn(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null; 
            LoadReceipts(); 
            MessageBox.Show("Receipt history successfully loaded.");
        }

        private void sendEmailBtn(object sender, EventArgs e)
        {
            EmailLogic emailLogic = new EmailLogic();

            ReceiptEmail email = new ReceiptEmail();
            email.FromEmail = "vincesmoke666@gmail.com";
            email.ToEmail = "vincesmoke666@gmail.com";
            email.Subject = "Receipt Notification";
            email.Body = "Your receipt has been successfully saved!";

            string result = emailLogic.SendEmail(email);
            MessageBox.Show(result, "Email Notification");
        }


        private void welcomeuserlbl(object sender, EventArgs e) { }
        private void receiptlbl(object sender, EventArgs e) { }
        private void historylbl(object sender, EventArgs e) { }
        private void receiptinfobox(object sender, EventArgs e) { }
        private void historylistgrid(object sender, DataGridViewCellEventArgs e) { }
    }
}
