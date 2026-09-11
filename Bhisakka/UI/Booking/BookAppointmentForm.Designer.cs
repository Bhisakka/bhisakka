using System.Drawing;
using System.Windows.Forms;
using MaterialComponents;

namespace Bhisakka.UI.Booking
{
    partial class BookAppointmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookAppointmentForm));
            this.lblTitle = new MaterialComponents.LMaterialLabel();
            this.grpBooking = new MaterialComponents.LMaterialGroupBox();
            this.lblPatient = new MaterialComponents.LMaterialLabel();
            this.cboPatient = new MaterialComponents.LMaterialComboBox();
            this.dtpDate = new MaterialComponents.LMaterialDateTimePicker();
            this.lblSlot = new MaterialComponents.LMaterialLabel();
            this.cboSlot = new MaterialComponents.LMaterialComboBox();
            this.btnBook = new MaterialComponents.LMaterialButton();
            this.grpBooking.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.lblTitle.Location = new System.Drawing.Point(24, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(432, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Book Appointment";
            this.lblTitle.TypeRole = MaterialComponents.LMaterialTypeRole.HeadlineSmall;
            // 
            // grpBooking
            // 
            this.grpBooking.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBooking.Controls.Add(this.lblPatient);
            this.grpBooking.Controls.Add(this.cboPatient);
            this.grpBooking.Controls.Add(this.dtpDate);
            this.grpBooking.Controls.Add(this.lblSlot);
            this.grpBooking.Controls.Add(this.cboSlot);
            this.grpBooking.Controls.Add(this.btnBook);
            this.grpBooking.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.grpBooking.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(79)))), ((int)(((byte)(39)))));
            this.grpBooking.Location = new System.Drawing.Point(24, 72);
            this.grpBooking.Name = "grpBooking";
            this.grpBooking.Size = new System.Drawing.Size(432, 336);
            this.grpBooking.TabIndex = 1;
            this.grpBooking.TabStop = false;
            this.grpBooking.Text = "Appointment Details";
            // 
            // lblPatient
            // 
            this.lblPatient.BackColor = System.Drawing.Color.Transparent;
            this.lblPatient.ColorRole = MaterialComponents.LMaterialColorRole.OnSurfaceVariant;
            this.lblPatient.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.lblPatient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(68)))), ((int)(((byte)(60)))));
            this.lblPatient.Location = new System.Drawing.Point(16, 30);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(200, 20);
            this.lblPatient.TabIndex = 0;
            this.lblPatient.Text = "Patient";
            this.lblPatient.TypeRole = MaterialComponents.LMaterialTypeRole.LabelLarge;
            // 
            // cboPatient
            // 
            this.cboPatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(234)))), ((int)(((byte)(226)))));
            this.cboPatient.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPatient.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboPatient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.cboPatient.IntegralHeight = false;
            this.cboPatient.ItemHeight = 36;
            this.cboPatient.Location = new System.Drawing.Point(16, 52);
            this.cboPatient.Name = "cboPatient";
            this.cboPatient.Size = new System.Drawing.Size(400, 42);
            this.cboPatient.TabIndex = 1;
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDate.CustomFormat = null;
            this.dtpDate.LabelText = "Appointment Date";
            this.dtpDate.Location = new System.Drawing.Point(16, 100);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(400, 84);
            this.dtpDate.TabIndex = 2;
            this.dtpDate.Value = new System.DateTime(2026, 9, 11, 13, 30, 29, 462);
            // 
            // lblSlot
            // 
            this.lblSlot.BackColor = System.Drawing.Color.Transparent;
            this.lblSlot.ColorRole = MaterialComponents.LMaterialColorRole.OnSurfaceVariant;
            this.lblSlot.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.lblSlot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(68)))), ((int)(((byte)(60)))));
            this.lblSlot.Location = new System.Drawing.Point(16, 192);
            this.lblSlot.Name = "lblSlot";
            this.lblSlot.Size = new System.Drawing.Size(220, 20);
            this.lblSlot.TabIndex = 3;
            this.lblSlot.Text = "Available Time Slot";
            this.lblSlot.TypeRole = MaterialComponents.LMaterialTypeRole.LabelLarge;
            // 
            // cboSlot
            // 
            this.cboSlot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSlot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(234)))), ((int)(((byte)(226)))));
            this.cboSlot.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSlot.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboSlot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.cboSlot.IntegralHeight = false;
            this.cboSlot.ItemHeight = 36;
            this.cboSlot.Location = new System.Drawing.Point(16, 214);
            this.cboSlot.Name = "cboSlot";
            this.cboSlot.Size = new System.Drawing.Size(400, 42);
            this.cboSlot.TabIndex = 4;
            // 
            // btnBook
            // 
            this.btnBook.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.btnBook.Location = new System.Drawing.Point(16, 272);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(400, 44);
            this.btnBook.TabIndex = 5;
            this.btnBook.Text = "Book Appointment";
            // 
            // BookAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 432);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpBooking);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(460, 471);
            this.Name = "BookAppointmentForm";
            this.Text = "Book Appointment";
            this.grpBooking.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialComponents.LMaterialLabel lblTitle;

        private MaterialComponents.LMaterialGroupBox grpBooking;
        private MaterialComponents.LMaterialLabel lblPatient;
        private MaterialComponents.LMaterialComboBox cboPatient;
        private MaterialComponents.LMaterialDateTimePicker dtpDate;
        private MaterialComponents.LMaterialLabel lblSlot;
        private MaterialComponents.LMaterialComboBox cboSlot;
        private MaterialComponents.LMaterialButton btnBook;
    }
}
