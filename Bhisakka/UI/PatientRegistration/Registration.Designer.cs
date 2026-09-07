using System.Drawing;
using System.Windows.Forms;

namespace Bhisakka.UI.PatientRegistration
{
    partial class Registration
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lMaterialLabel1 = new MaterialComponents.LMaterialLabel();
            txtAge = new MaterialComponents.LMaterialTextBox();
            rdoMale = new MaterialComponents.LMaterialRadioButton();
            rdoFemale = new MaterialComponents.LMaterialRadioButton();
            txtFirstName = new MaterialComponents.LMaterialTextBox();
            txtContact = new MaterialComponents.LMaterialTextBox();
            txtLastName = new MaterialComponents.LMaterialTextBox();
            lMaterialTableLayoutPanel1 = new MaterialComponents.LMaterialTableLayoutPanel();
            txtAddress = new MaterialComponents.LMaterialTextBox();
            lMaterialButton1 = new MaterialComponents.LMaterialButton();
            lMaterialTableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lMaterialLabel1
            // 
            lMaterialLabel1.BackColor = Color.Transparent;
            lMaterialTableLayoutPanel1.SetColumnSpan(lMaterialLabel1, 4);
            lMaterialLabel1.Dock = DockStyle.Fill;
            lMaterialLabel1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lMaterialLabel1.ForeColor = Color.FromArgb(34, 26, 21);
            lMaterialLabel1.Location = new Point(19, 8);
            lMaterialLabel1.Name = "lMaterialLabel1";
            lMaterialLabel1.Size = new Size(1233, 100);
            lMaterialLabel1.TabIndex = 21;
            lMaterialLabel1.Text = "Patient Registration";
            lMaterialLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtAge
            // 
            txtAge.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtAge.LabelText = "Age";
            txtAge.Location = new Point(19, 262);
            txtAge.Margin = new Padding(3, 16, 3, 8);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(544, 65);
            txtAge.TabIndex = 17;
            // 
            // rdoMale
            // 
            rdoMale.Anchor = AnchorStyles.Left;
            rdoMale.AutoSize = true;
            rdoMale.Font = new Font("Segoe UI", 11F);
            rdoMale.ForeColor = Color.FromArgb(34, 26, 21);
            rdoMale.Location = new Point(874, 272);
            rdoMale.Margin = new Padding(3, 16, 3, 8);
            rdoMale.Name = "rdoMale";
            rdoMale.Size = new Size(69, 29);
            rdoMale.TabIndex = 20;
            rdoMale.TabStop = true;
            rdoMale.Text = "Male";
            rdoMale.UseVisualStyleBackColor = true;
            // 
            // rdoFemale
            // 
            rdoFemale.Anchor = AnchorStyles.Left;
            rdoFemale.AutoSize = true;
            rdoFemale.Font = new Font("Segoe UI", 11F);
            rdoFemale.ForeColor = Color.FromArgb(34, 26, 21);
            rdoFemale.Location = new Point(953, 272);
            rdoFemale.Margin = new Padding(3, 16, 3, 8);
            rdoFemale.Name = "rdoFemale";
            rdoFemale.Size = new Size(85, 29);
            rdoFemale.TabIndex = 22;
            rdoFemale.TabStop = true;
            rdoFemale.Text = "Female";
            rdoFemale.UseVisualStyleBackColor = true;
            // 
            // txtFirstName
            // 
            txtFirstName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lMaterialTableLayoutPanel1.SetColumnSpan(txtFirstName, 4);
            txtFirstName.LabelText = "First Name";
            txtFirstName.Location = new Point(19, 124);
            txtFirstName.Margin = new Padding(3, 16, 3, 8);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(1233, 70);
            txtFirstName.TabIndex = 15;
            // 
            // txtContact
            // 
            txtContact.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lMaterialTableLayoutPanel1.SetColumnSpan(txtContact, 4);
            txtContact.LabelText = "Contact Number";
            txtContact.Location = new Point(19, 340);
            txtContact.Margin = new Padding(3, 16, 3, 8);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(1233, 65);
            txtContact.TabIndex = 18;
            // 
            // txtLastName
            // 
            txtLastName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lMaterialTableLayoutPanel1.SetColumnSpan(txtLastName, 4);
            txtLastName.LabelText = "Last Name";
            txtLastName.Location = new Point(19, 200);
            txtLastName.Margin = new Padding(3, 16, 3, 8);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(1233, 65);
            txtLastName.TabIndex = 16;
            // 
            // lMaterialTableLayoutPanel1
            // 
            lMaterialTableLayoutPanel1.BackColor = Color.FromArgb(255, 248, 245);
            lMaterialTableLayoutPanel1.ColumnCount = 4;
            lMaterialTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            lMaterialTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            lMaterialTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            lMaterialTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            lMaterialTableLayoutPanel1.Controls.Add(txtLastName, 0, 2);
            lMaterialTableLayoutPanel1.Controls.Add(txtContact, 0, 5);
            lMaterialTableLayoutPanel1.Controls.Add(txtFirstName, 0, 1);
            lMaterialTableLayoutPanel1.Controls.Add(txtAge, 0, 4);
            lMaterialTableLayoutPanel1.Controls.Add(txtAddress, 0, 6);
            lMaterialTableLayoutPanel1.Controls.Add(rdoMale, 2, 4);
            lMaterialTableLayoutPanel1.Controls.Add(rdoFemale, 3, 4);
            lMaterialTableLayoutPanel1.Controls.Add(lMaterialButton1, 0, 7);
            lMaterialTableLayoutPanel1.Controls.Add(lMaterialLabel1, 0, 0);
            lMaterialTableLayoutPanel1.Dock = DockStyle.Fill;
            lMaterialTableLayoutPanel1.ForeColor = Color.FromArgb(34, 26, 21);
            lMaterialTableLayoutPanel1.Location = new Point(0, 0);
            lMaterialTableLayoutPanel1.Name = "lMaterialTableLayoutPanel1";
            lMaterialTableLayoutPanel1.Padding = new Padding(16, 8, 16, 16);
            lMaterialTableLayoutPanel1.RowCount = 9;
            lMaterialTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            lMaterialTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 94F));
            lMaterialTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 89F));
            lMaterialTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            lMaterialTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 93F));
            lMaterialTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 93F));
            lMaterialTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 114F));
            lMaterialTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            lMaterialTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            lMaterialTableLayoutPanel1.Size = new Size(1335, 767);
            lMaterialTableLayoutPanel1.TabIndex = 22;
            lMaterialTableLayoutPanel1.Paint += lMaterialTableLayoutPanel1_Paint;
            // 
            // txtAddress
            // 
            txtAddress.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lMaterialTableLayoutPanel1.SetColumnSpan(txtAddress, 4);
            txtAddress.LabelText = "Address";
            txtAddress.Location = new Point(19, 420);
            txtAddress.Margin = new Padding(3, 16, 3, 8);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(1233, 90);
            txtAddress.TabIndex = 19;
            // 
            // lMaterialButton1
            // 
            lMaterialTableLayoutPanel1.SetColumnSpan(lMaterialButton1, 4);
            lMaterialButton1.Dock = DockStyle.Fill;
            lMaterialButton1.FlatAppearance.BorderSize = 0;
            lMaterialButton1.FlatStyle = FlatStyle.Flat;
            lMaterialButton1.Font = new Font("Segoe UI Semibold", 10.5F);
            lMaterialButton1.Location = new Point(219, 508);
            lMaterialButton1.Margin = new Padding(200, 10, 200, 10);
            lMaterialButton1.Name = "lMaterialButton1";
            lMaterialButton1.Size = new Size(833, 80);
            lMaterialButton1.TabIndex = 14;
            lMaterialButton1.Text = "Save";
            lMaterialButton1.UseVisualStyleBackColor = true;
            lMaterialButton1.Click += lMaterialButton1_Click;
            // 
            // Registration
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1335, 767);
            Controls.Add(lMaterialTableLayoutPanel1);
            MinimumSize = new Size(900, 700);
            Name = "Registration";
            Text = "Patient Registration";
            lMaterialTableLayoutPanel1.ResumeLayout(false);
            lMaterialTableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MaterialComponents.LMaterialLabel lMaterialLabel1;
        private MaterialComponents.LMaterialTableLayoutPanel lMaterialTableLayoutPanel1;
        private MaterialComponents.LMaterialTextBox txtLastName;
        private MaterialComponents.LMaterialTextBox txtContact;
        private MaterialComponents.LMaterialTextBox txtFirstName;
        private MaterialComponents.LMaterialRadioButton rdoMale;
        private MaterialComponents.LMaterialRadioButton rdoFemale;
        private MaterialComponents.LMaterialTextBox txtAge;
        private MaterialComponents.LMaterialTextBox txtAddress;
        private MaterialComponents.LMaterialButton lMaterialButton1;
    }
}