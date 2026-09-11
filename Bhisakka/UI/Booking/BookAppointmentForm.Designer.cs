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
            lblTitle = new MaterialComponents.LMaterialLabel();

            grpBooking = new MaterialComponents.LMaterialGroupBox();
            lblPatient = new MaterialComponents.LMaterialLabel();
            cboPatient = new MaterialComponents.LMaterialComboBox();
            dtpDate = new MaterialComponents.LMaterialDateTimePicker();
            lblSlot = new MaterialComponents.LMaterialLabel();
            cboSlot = new MaterialComponents.LMaterialComboBox();
            btnBook = new MaterialComponents.LMaterialButton();

            SuspendLayout();

            //
            // lblTitle
            //
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.TypeRole = LMaterialTypeRole.HeadlineSmall;
            lblTitle.Location = new Point(24, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(432, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Book Appointment";

            //
            // grpBooking
            //
            grpBooking.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpBooking.Location = new Point(24, 72);
            grpBooking.Name = "grpBooking";
            grpBooking.Size = new Size(432, 336);
            grpBooking.TabIndex = 1;
            grpBooking.Text = "Appointment Details";

            //
            // lblPatient
            //
            lblPatient.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblPatient.TypeRole = LMaterialTypeRole.LabelLarge;
            lblPatient.ColorRole = LMaterialColorRole.OnSurfaceVariant;
            lblPatient.Location = new Point(16, 30);
            lblPatient.Name = "lblPatient";
            lblPatient.Size = new Size(200, 20);
            lblPatient.TabIndex = 0;
            lblPatient.Text = "Patient";

            //
            // cboPatient
            //
            cboPatient.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboPatient.Location = new Point(16, 52);
            cboPatient.Name = "cboPatient";
            cboPatient.Size = new Size(400, 40);
            cboPatient.TabIndex = 1;

            //
            // dtpDate
            //
            dtpDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpDate.Location = new Point(16, 100);
            dtpDate.LabelText = "Appointment Date";
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(400, 84);
            dtpDate.TabIndex = 2;
            dtpDate.ValueChanged += dtpDate_ValueChanged;

            //
            // lblSlot
            //
            lblSlot.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblSlot.TypeRole = LMaterialTypeRole.LabelLarge;
            lblSlot.ColorRole = LMaterialColorRole.OnSurfaceVariant;
            lblSlot.Location = new Point(16, 192);
            lblSlot.Name = "lblSlot";
            lblSlot.Size = new Size(220, 20);
            lblSlot.TabIndex = 3;
            lblSlot.Text = "Available Time Slot";

            //
            // cboSlot
            //
            cboSlot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboSlot.Location = new Point(16, 214);
            cboSlot.Name = "cboSlot";
            cboSlot.Size = new Size(400, 40);
            cboSlot.TabIndex = 4;

            //
            // btnBook
            //
            btnBook.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnBook.Location = new Point(16, 272);
            btnBook.Name = "btnBook";
            btnBook.Size = new Size(400, 44);
            btnBook.TabIndex = 5;
            btnBook.Text = "Book Appointment";
            btnBook.Click += btnBook_Click;

            grpBooking.Controls.Add(lblPatient);
            grpBooking.Controls.Add(cboPatient);
            grpBooking.Controls.Add(dtpDate);
            grpBooking.Controls.Add(lblSlot);
            grpBooking.Controls.Add(cboSlot);
            grpBooking.Controls.Add(btnBook);

            //
            // BookAppointmentForm
            //
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 432);
            Controls.Add(lblTitle);
            Controls.Add(grpBooking);
            MinimumSize = new Size(460, 471);
            Name = "BookAppointmentForm";
            Text = "Book Appointment";

            ResumeLayout(false);
            PerformLayout();
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
