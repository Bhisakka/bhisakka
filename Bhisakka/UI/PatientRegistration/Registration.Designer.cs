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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registration));
            this.tblLayout = new MaterialComponents.LMaterialTableLayoutPanel();
            this.lblTitle = new MaterialComponents.LMaterialLabel();
            this.txtFirstName = new MaterialComponents.LMaterialTextBox();
            this.txtLastName = new MaterialComponents.LMaterialTextBox();
            this.dtpDob = new MaterialComponents.LMaterialDateTimePicker();
            this.pnlGender = new MaterialComponents.LMaterialFlowLayoutPanel();
            this.lblGender = new MaterialComponents.LMaterialLabel();
            this.rdoMale = new MaterialComponents.LMaterialRadioButton();
            this.rdoFemale = new MaterialComponents.LMaterialRadioButton();
            this.rdoOther = new MaterialComponents.LMaterialRadioButton();
            this.txtContact = new MaterialComponents.LMaterialTextBox();
            this.txtAddress = new MaterialComponents.LMaterialTextBox();
            this.btnSave = new MaterialComponents.LMaterialButton();
            this.tblLayout.SuspendLayout();
            this.pnlGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblLayout
            // 
            this.tblLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.tblLayout.ColumnCount = 2;
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayout.Controls.Add(this.lblTitle, 0, 0);
            this.tblLayout.Controls.Add(this.txtFirstName, 0, 1);
            this.tblLayout.Controls.Add(this.txtLastName, 1, 1);
            this.tblLayout.Controls.Add(this.dtpDob, 0, 2);
            this.tblLayout.Controls.Add(this.pnlGender, 0, 3);
            this.tblLayout.Controls.Add(this.txtContact, 0, 4);
            this.tblLayout.Controls.Add(this.txtAddress, 0, 5);
            this.tblLayout.Controls.Add(this.btnSave, 0, 6);
            this.tblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.tblLayout.Location = new System.Drawing.Point(0, 0);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.Padding = new System.Windows.Forms.Padding(24, 16, 24, 16);
            this.tblLayout.RowCount = 8;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.Size = new System.Drawing.Size(720, 640);
            this.tblLayout.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.tblLayout.SetColumnSpan(this.lblTitle, 2);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.lblTitle.Location = new System.Drawing.Point(27, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(666, 64);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Patient Registration";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.TypeRole = MaterialComponents.LMaterialTypeRole.HeadlineSmall;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.LabelText = "First Name";
            this.txtFirstName.Location = new System.Drawing.Point(24, 83);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(0, 3, 8, 3);
            this.txtFirstName.MaxLength = 100;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(328, 84);
            this.txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.LabelText = "Last Name";
            this.txtLastName.Location = new System.Drawing.Point(368, 83);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.txtLastName.MaxLength = 100;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(328, 84);
            this.txtLastName.TabIndex = 2;
            // 
            // dtpDob
            // 
            this.dtpDob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tblLayout.SetColumnSpan(this.dtpDob, 2);
            this.dtpDob.CustomFormat = null;
            this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDob.LabelText = "Date of Birth";
            this.dtpDob.Location = new System.Drawing.Point(24, 173);
            this.dtpDob.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(672, 84);
            this.dtpDob.TabIndex = 3;
            this.dtpDob.Value = new System.DateTime(2026, 9, 11, 13, 31, 15, 565);
            // 
            // pnlGender
            // 
            this.pnlGender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.tblLayout.SetColumnSpan(this.pnlGender, 2);
            this.pnlGender.Controls.Add(this.lblGender);
            this.pnlGender.Controls.Add(this.rdoMale);
            this.pnlGender.Controls.Add(this.rdoFemale);
            this.pnlGender.Controls.Add(this.rdoOther);
            this.pnlGender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.pnlGender.Location = new System.Drawing.Point(24, 260);
            this.pnlGender.Margin = new System.Windows.Forms.Padding(0);
            this.pnlGender.Name = "pnlGender";
            this.pnlGender.Size = new System.Drawing.Size(672, 64);
            this.pnlGender.TabIndex = 4;
            this.pnlGender.WrapContents = false;
            // 
            // lblGender
            // 
            this.lblGender.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGender.AutoSize = true;
            this.lblGender.BackColor = System.Drawing.Color.Transparent;
            this.lblGender.ColorRole = MaterialComponents.LMaterialColorRole.OnSurfaceVariant;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(68)))), ((int)(((byte)(60)))));
            this.lblGender.Location = new System.Drawing.Point(3, 26);
            this.lblGender.Margin = new System.Windows.Forms.Padding(3, 20, 16, 3);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(54, 19);
            this.lblGender.TabIndex = 0;
            this.lblGender.Text = "Gender";
            // 
            // rdoMale
            // 
            this.rdoMale.AutoSize = true;
            this.rdoMale.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rdoMale.Location = new System.Drawing.Point(76, 16);
            this.rdoMale.Margin = new System.Windows.Forms.Padding(3, 16, 16, 3);
            this.rdoMale.Name = "rdoMale";
            this.rdoMale.Size = new System.Drawing.Size(88, 36);
            this.rdoMale.TabIndex = 5;
            this.rdoMale.Text = "Male";
            // 
            // rdoFemale
            // 
            this.rdoFemale.AutoSize = true;
            this.rdoFemale.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rdoFemale.Location = new System.Drawing.Point(183, 16);
            this.rdoFemale.Margin = new System.Windows.Forms.Padding(3, 16, 16, 3);
            this.rdoFemale.Name = "rdoFemale";
            this.rdoFemale.Size = new System.Drawing.Size(104, 36);
            this.rdoFemale.TabIndex = 6;
            this.rdoFemale.Text = "Female";
            // 
            // rdoOther
            // 
            this.rdoOther.AutoSize = true;
            this.rdoOther.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rdoOther.Location = new System.Drawing.Point(306, 16);
            this.rdoOther.Margin = new System.Windows.Forms.Padding(3, 16, 16, 3);
            this.rdoOther.Name = "rdoOther";
            this.rdoOther.Size = new System.Drawing.Size(94, 36);
            this.rdoOther.TabIndex = 7;
            this.rdoOther.Text = "Other";
            // 
            // txtContact
            // 
            this.txtContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tblLayout.SetColumnSpan(this.txtContact, 2);
            this.txtContact.LabelText = "Contact Number";
            this.txtContact.Location = new System.Drawing.Point(24, 327);
            this.txtContact.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.txtContact.MaxLength = 30;
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(672, 84);
            this.txtContact.TabIndex = 8;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblLayout.SetColumnSpan(this.txtAddress, 2);
            this.txtAddress.LabelText = "Address";
            this.txtAddress.Location = new System.Drawing.Point(24, 417);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(672, 120);
            this.txtAddress.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tblLayout.SetColumnSpan(this.btnSave, 2);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.btnSave.Location = new System.Drawing.Point(533, 552);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 40);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 640);
            this.Controls.Add(this.tblLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 620);
            this.Name = "Registration";
            this.Text = "Patient Registration";
            this.tblLayout.ResumeLayout(false);
            this.pnlGender.ResumeLayout(false);
            this.pnlGender.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialComponents.LMaterialTableLayoutPanel tblLayout;
        private MaterialComponents.LMaterialLabel lblTitle;
        private MaterialComponents.LMaterialTextBox txtFirstName;
        private MaterialComponents.LMaterialTextBox txtLastName;
        private MaterialComponents.LMaterialDateTimePicker dtpDob;
        private MaterialComponents.LMaterialFlowLayoutPanel pnlGender;
        private MaterialComponents.LMaterialLabel lblGender;
        private MaterialComponents.LMaterialRadioButton rdoMale;
        private MaterialComponents.LMaterialRadioButton rdoFemale;
        private MaterialComponents.LMaterialRadioButton rdoOther;
        private MaterialComponents.LMaterialTextBox txtContact;
        private MaterialComponents.LMaterialTextBox txtAddress;
        private MaterialComponents.LMaterialButton btnSave;
    }
}
