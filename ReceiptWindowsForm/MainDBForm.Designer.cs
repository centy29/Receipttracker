namespace ReceiptWindowsForm
{
    partial class MainDBForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 

        //input field for receipt infos
        private TextBox textBoxInvoice;
        private TextBox textBoxBrand;
        private TextBox textBoxAddress;
        private TextBox textBoxTin;
        private TextBox textBoxAmount;
        private Button emailButton;



        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            
            label1 = new Label();
            groupBox1 = new GroupBox();
            textBoxInvoice = new TextBox();
            textBoxBrand = new TextBox();
            textBoxAddress = new TextBox();
            textBoxTin = new TextBox();
            textBoxAmount = new TextBox();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new Point(54, 25);
            button1.Name = "button1";
            button1.Size = new Size(129, 23);
            button1.TabIndex = 10;
            button1.Text = "BACK TO LOGIN";
            button1.UseVisualStyleBackColor = true;
            button1.Click += backbtn;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button2.Location = new Point(689, 26);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 9;
            button2.Text = "SEARCH";
            button2.UseVisualStyleBackColor = true;
            button2.Click += searchbtn;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button3.Location = new Point(359, 168);
            button3.Name = "button3";
            button3.Size = new Size(101, 23);
            button3.TabIndex = 8;
            button3.Text = "ADD RECEIPT";
            button3.UseVisualStyleBackColor = true;
            button3.Click += addbtn;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button4.Location = new Point(359, 227);
            button4.Name = "button4";
            button4.Size = new Size(101, 23);
            button4.TabIndex = 7;
            button4.Text = "DELETE RECEIPT";
            button4.UseVisualStyleBackColor = true;
            button4.Click += deletebtn;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button5.Location = new Point(359, 280);
            button5.Name = "button5";
            button5.Size = new Size(117, 23);
            button5.TabIndex = 6;
            button5.Text = "RECEIPT HISTORY";
            button5.UseVisualStyleBackColor = true;
            button5.Click += retrievebtn;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(316, 47);
            label1.Name = "label1";
            label1.Size = new Size(179, 15);
            label1.TabIndex = 5;
            label1.Text = "WELCOME TO RECEIPT TRACKER";
            label1.Click += welcomeuserlbl;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(textBoxInvoice);
            groupBox1.Controls.Add(textBoxBrand);
            groupBox1.Controls.Add(textBoxAddress);
            groupBox1.Controls.Add(textBoxTin);
            groupBox1.Controls.Add(textBoxAmount);
            groupBox1.Location = new Point(33, 131);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(275, 274);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "RECEIPT";
            groupBox1.Enter += receiptinfobox;
            
            // textBoxInvoice
            textBoxInvoice.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxInvoice.Location = new Point(20, 30);
            textBoxInvoice.Name = "textBoxInvoice";
            textBoxInvoice.PlaceholderText = "Invoice";
            textBoxInvoice.Size = new Size(200, 23);
            textBoxInvoice.TabIndex = 0;   

            // textBoxBrand
            textBoxBrand.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxBrand.Location = new Point(20, 60);
            textBoxBrand.Name = "textBoxBrand";
            textBoxBrand.PlaceholderText = "Brand";
            textBoxBrand.Size = new Size(200, 23);
            textBoxBrand.TabIndex = 1;

            // textBoxAddress
            textBoxAddress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxAddress.Location = new Point(20, 90);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.PlaceholderText = "Address";
            textBoxAddress.Size = new Size(200, 23);
            textBoxAddress.TabIndex = 2;

            // textBoxTin
            textBoxTin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxTin.Location = new Point(20, 120);
            textBoxTin.Name = "textBoxTin";
            textBoxTin.PlaceholderText = "TIN";
            textBoxTin.Size = new Size(200, 23);
            textBoxTin.TabIndex = 3;

            // textBoxAmount
            textBoxAmount.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxAmount.Location = new Point(20, 150);
            textBoxAmount.Name = "textBoxAmount";
            textBoxAmount.PlaceholderText = "Amount";
            textBoxAmount.Size = new Size(200, 23);
            textBoxAmount.TabIndex = 4;

            // textBox1
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(546, 26);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.Location = new Point(528, 131);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(245, 296);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += historylistgrid;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(115, 101);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 1;
            label2.Text = "RECEIPT INFO";
            label2.Click += receiptlbl;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(591, 101);
            label3.Name = "label3";
            label3.Size = new Size(123, 15);
            label3.TabIndex = 0;
            label3.Text = "RECEIPT HISTORY LIST";
            label3.Click += historylbl;
            // 
            // MainDBForm
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(textBox1);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "MainDBForm";
            Text = "MainDBForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();

            // emailButton
            emailButton = new Button();
            emailButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            emailButton.Location = new Point(54, 60);
            emailButton.Name = "emailButton";
            emailButton.Size = new Size(129, 23);
            emailButton.TabIndex = 11;
            emailButton.Text = "SEND EMAIL";
            emailButton.UseVisualStyleBackColor = true;
            emailButton.Click += sendEmailBtn;

            Controls.Add(emailButton);


        }

        #endregion
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}