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
            this.tblLayout.ColumnCount = 2;
            this.tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tblLayout.Dock = DockStyle.Fill;
            this.tblLayout.Padding = new Padding(24, 16, 24, 16);
            this.tblLayout.RowCount = 8;
            this.tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));   // title
            this.tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));   // first / last
            this.tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));   // dob
            this.tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));   // gender
            this.tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));   // contact
            this.tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 130F));  // address
            this.tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));   // save
            this.tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));   // filler
            this.tblLayout.Controls.Add(this.lblTitle, 0, 0);
            this.tblLayout.Controls.Add(this.txtFirstName, 0, 1);
            this.tblLayout.Controls.Add(this.txtLastName, 1, 1);
            this.tblLayout.Controls.Add(this.dtpDob, 0, 2);
            this.tblLayout.Controls.Add(this.pnlGender, 0, 3);
            this.tblLayout.Controls.Add(this.txtContact, 0, 4);
            this.tblLayout.Controls.Add(this.txtAddress, 0, 5);
            this.tblLayout.Controls.Add(this.btnSave, 0, 6);
            this.tblLayout.SetColumnSpan(this.lblTitle, 2);
            this.tblLayout.SetColumnSpan(this.dtpDob, 2);
            this.tblLayout.SetColumnSpan(this.pnlGender, 2);
            this.tblLayout.SetColumnSpan(this.txtContact, 2);
            this.tblLayout.SetColumnSpan(this.txtAddress, 2);
            this.tblLayout.SetColumnSpan(this.btnSave, 2);
            this.tblLayout.Location = new Point(0, 0);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = false;
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.TypeRole = MaterialComponents.LMaterialTypeRole.HeadlineSmall;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Patient Registration";
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // txtFirstName
            //
            this.txtFirstName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.txtFirstName.LabelText = "First Name";
            this.txtFirstName.Margin = new Padding(0, 3, 8, 3);
            this.txtFirstName.MaxLength = 100;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new Size(300, 84);
            this.txtFirstName.TabIndex = 1;
            //
            // txtLastName
            //
            this.txtLastName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.txtLastName.LabelText = "Last Name";
            this.txtLastName.Margin = new Padding(8, 3, 0, 3);
            this.txtLastName.MaxLength = 100;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new Size(300, 84);
            this.txtLastName.TabIndex = 2;
            //
            // dtpDob
            //
            this.dtpDob.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.dtpDob.Format = DateTimePickerFormat.Short;
            this.dtpDob.LabelText = "Date of Birth";
            this.dtpDob.Margin = new Padding(0, 3, 0, 3);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new Size(600, 84);
            this.dtpDob.TabIndex = 3;
            //
            // pnlGender
            //
            this.pnlGender.Controls.Add(this.lblGender);
            this.pnlGender.Controls.Add(this.rdoMale);
            this.pnlGender.Controls.Add(this.rdoFemale);
            this.pnlGender.Controls.Add(this.rdoOther);
            this.pnlGender.Dock = DockStyle.Fill;
            this.pnlGender.Margin = new Padding(0);
            this.pnlGender.Name = "pnlGender";
            this.pnlGender.TabIndex = 4;
            this.pnlGender.WrapContents = false;
            //
            // lblGender
            //
            this.lblGender.Anchor = AnchorStyles.Left;
            this.lblGender.AutoSize = true;
            this.lblGender.ColorRole = MaterialComponents.LMaterialColorRole.OnSurfaceVariant;
            this.lblGender.Margin = new Padding(3, 20, 16, 3);
            this.lblGender.Name = "lblGender";
            this.lblGender.Text = "Gender";
            //
            // rdoMale
            //
            this.rdoMale.AutoSize = true;
            this.rdoMale.Margin = new Padding(3, 16, 16, 3);
            this.rdoMale.Name = "rdoMale";
            this.rdoMale.TabIndex = 5;
            this.rdoMale.Text = "Male";
            //
            // rdoFemale
            //
            this.rdoFemale.AutoSize = true;
            this.rdoFemale.Margin = new Padding(3, 16, 16, 3);
            this.rdoFemale.Name = "rdoFemale";
            this.rdoFemale.TabIndex = 6;
            this.rdoFemale.Text = "Female";
            //
            // rdoOther
            //
            this.rdoOther.AutoSize = true;
            this.rdoOther.Margin = new Padding(3, 16, 16, 3);
            this.rdoOther.Name = "rdoOther";
            this.rdoOther.TabIndex = 7;
            this.rdoOther.Text = "Other";
            //
            // txtContact
            //
            this.txtContact.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.txtContact.LabelText = "Contact Number";
            this.txtContact.Margin = new Padding(0, 3, 0, 3);
            this.txtContact.MaxLength = 30;
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new Size(600, 84);
            this.txtContact.TabIndex = 8;
            //
            // txtAddress
            //
            this.txtAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtAddress.LabelText = "Address";
            this.txtAddress.Margin = new Padding(0, 3, 0, 3);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new Size(600, 120);
            this.txtAddress.TabIndex = 9;
            //
            // btnSave
            //
            this.btnSave.Anchor = AnchorStyles.Right;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(160, 40);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // Registration
            //
            this.AutoScaleDimensions = new SizeF(8F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(720, 640);
            this.Controls.Add(this.tblLayout);
            this.MinimumSize = new Size(640, 620);
            this.Name = "Registration";
            this.Text = "Patient Registration";
            this.tblLayout.ResumeLayout(false);
            this.tblLayout.PerformLayout();
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
