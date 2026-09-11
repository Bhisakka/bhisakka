using System.Drawing;
using System.Windows.Forms;
using MaterialComponents;

namespace Bhisakka.UI
{
    partial class ConsultationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultationForm));
            this.pnlLeft = new MaterialComponents.LMaterialPanel();
            this.grpQueue = new MaterialComponents.LMaterialGroupBox();
            this.lstQueue = new MaterialComponents.LMaterialListBox();
            this.btnCallNext = new MaterialComponents.LMaterialButton();
            this.grpCheckIn = new MaterialComponents.LMaterialGroupBox();
            this.lstCheckIn = new MaterialComponents.LMaterialListBox();
            this.btnCheckIn = new MaterialComponents.LMaterialButton();
            this.pnlRight = new MaterialComponents.LMaterialPanel();
            this.grpAudio = new MaterialComponents.LMaterialGroupBox();
            this.lblMicrophone = new MaterialComponents.LMaterialLabel();
            this.comboMicrophones = new MaterialComponents.LMaterialComboBox();
            this.lmtRecordStatus = new MaterialComponents.LMaterialLabel();
            this.lmtPgBar = new MaterialComponents.LMaterialProgressBar();
            this.pnlAudioButtons = new MaterialComponents.LMaterialPanel();
            this.btnRecord = new MaterialComponents.LMaterialButton();
            this.btnStop = new MaterialComponents.LMaterialButton();
            this.lmtSave = new MaterialComponents.LMaterialButton();
            this.grpPrescription = new MaterialComponents.LMaterialGroupBox();
            this.lblMedicine = new MaterialComponents.LMaterialLabel();
            this.cboMedicine = new MaterialComponents.LMaterialComboBox();
            this.numQuantity = new MaterialComponents.LMaterialNumericUpDown();
            this.txtDosage = new MaterialComponents.LMaterialTextBox();
            this.btnAddItem = new MaterialComponents.LMaterialButton();
            this.lstPrescriptionItems = new MaterialComponents.LMaterialListBox();
            this.grpNotes = new MaterialComponents.LMaterialGroupBox();
            this.txtDiagnosis = new MaterialComponents.LMaterialTextBox();
            this.numFee = new MaterialComponents.LMaterialNumericUpDown();
            this.rtxtNotes = new MaterialComponents.LMaterialRichTextBox();
            this.grpPatientInfo = new MaterialComponents.LMaterialGroupBox();
            this.lmtPatientName = new MaterialComponents.LMaterialTextBox();
            this.lmtConsultationID = new MaterialComponents.LMaterialTextBox();
            this.btnSaveConsultation = new MaterialComponents.LMaterialButton();
            this.pnlLeft.SuspendLayout();
            this.grpQueue.SuspendLayout();
            this.grpCheckIn.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.grpAudio.SuspendLayout();
            this.pnlAudioButtons.SuspendLayout();
            this.grpPrescription.SuspendLayout();
            this.grpNotes.SuspendLayout();
            this.grpPatientInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlLeft.Controls.Add(this.grpQueue);
            this.pnlLeft.Controls.Add(this.grpCheckIn);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(12, 12, 6, 12);
            this.pnlLeft.Size = new System.Drawing.Size(340, 850);
            this.pnlLeft.TabIndex = 1;
            // 
            // grpQueue
            // 
            this.grpQueue.Controls.Add(this.lstQueue);
            this.grpQueue.Controls.Add(this.btnCallNext);
            this.grpQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpQueue.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.grpQueue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(79)))), ((int)(((byte)(39)))));
            this.grpQueue.Location = new System.Drawing.Point(12, 252);
            this.grpQueue.Name = "grpQueue";
            this.grpQueue.Padding = new System.Windows.Forms.Padding(12, 8, 12, 12);
            this.grpQueue.Size = new System.Drawing.Size(322, 586);
            this.grpQueue.TabIndex = 0;
            this.grpQueue.TabStop = false;
            this.grpQueue.Text = "Live Queue";
            // 
            // lstQueue
            // 
            this.lstQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(234)))));
            this.lstQueue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstQueue.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstQueue.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lstQueue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.lstQueue.IntegralHeight = false;
            this.lstQueue.ItemHeight = 40;
            this.lstQueue.Location = new System.Drawing.Point(12, 27);
            this.lstQueue.Name = "lstQueue";
            this.lstQueue.Size = new System.Drawing.Size(298, 507);
            this.lstQueue.TabIndex = 0;
            // 
            // btnCallNext
            // 
            this.btnCallNext.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCallNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCallNext.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.btnCallNext.Location = new System.Drawing.Point(12, 534);
            this.btnCallNext.Name = "btnCallNext";
            this.btnCallNext.Size = new System.Drawing.Size(298, 40);
            this.btnCallNext.TabIndex = 1;
            this.btnCallNext.Text = "Call Next Patient";
            this.btnCallNext.Click += new System.EventHandler(this.BtnCallNext_Click);
            // 
            // grpCheckIn
            // 
            this.grpCheckIn.Controls.Add(this.lstCheckIn);
            this.grpCheckIn.Controls.Add(this.btnCheckIn);
            this.grpCheckIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCheckIn.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.grpCheckIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(79)))), ((int)(((byte)(39)))));
            this.grpCheckIn.Location = new System.Drawing.Point(12, 12);
            this.grpCheckIn.Name = "grpCheckIn";
            this.grpCheckIn.Padding = new System.Windows.Forms.Padding(12, 8, 12, 12);
            this.grpCheckIn.Size = new System.Drawing.Size(322, 240);
            this.grpCheckIn.TabIndex = 1;
            this.grpCheckIn.TabStop = false;
            this.grpCheckIn.Text = "Today\'s Check-In";
            // 
            // lstCheckIn
            // 
            this.lstCheckIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(234)))));
            this.lstCheckIn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstCheckIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCheckIn.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstCheckIn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lstCheckIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.lstCheckIn.IntegralHeight = false;
            this.lstCheckIn.ItemHeight = 40;
            this.lstCheckIn.Location = new System.Drawing.Point(12, 27);
            this.lstCheckIn.Name = "lstCheckIn";
            this.lstCheckIn.Size = new System.Drawing.Size(298, 161);
            this.lstCheckIn.TabIndex = 0;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckIn.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.btnCheckIn.Location = new System.Drawing.Point(12, 188);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(298, 40);
            this.btnCheckIn.TabIndex = 1;
            this.btnCheckIn.Text = "Check In Selected";
            this.btnCheckIn.Click += new System.EventHandler(this.BtnCheckIn_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlRight.Controls.Add(this.grpAudio);
            this.pnlRight.Controls.Add(this.grpPrescription);
            this.pnlRight.Controls.Add(this.grpNotes);
            this.pnlRight.Controls.Add(this.grpPatientInfo);
            this.pnlRight.Controls.Add(this.btnSaveConsultation);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.pnlRight.Location = new System.Drawing.Point(340, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(6, 12, 12, 12);
            this.pnlRight.Size = new System.Drawing.Size(940, 850);
            this.pnlRight.TabIndex = 0;
            // 
            // grpAudio
            // 
            this.grpAudio.Controls.Add(this.lblMicrophone);
            this.grpAudio.Controls.Add(this.comboMicrophones);
            this.grpAudio.Controls.Add(this.lmtRecordStatus);
            this.grpAudio.Controls.Add(this.lmtPgBar);
            this.grpAudio.Controls.Add(this.pnlAudioButtons);
            this.grpAudio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAudio.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.grpAudio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(79)))), ((int)(((byte)(39)))));
            this.grpAudio.Location = new System.Drawing.Point(6, 616);
            this.grpAudio.Name = "grpAudio";
            this.grpAudio.Padding = new System.Windows.Forms.Padding(12, 8, 12, 12);
            this.grpAudio.Size = new System.Drawing.Size(922, 174);
            this.grpAudio.TabIndex = 0;
            this.grpAudio.TabStop = false;
            this.grpAudio.Text = "Audio Recording (Liability Auditing)";
            // 
            // lblMicrophone
            // 
            this.lblMicrophone.AutoSize = true;
            this.lblMicrophone.BackColor = System.Drawing.Color.Transparent;
            this.lblMicrophone.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblMicrophone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.lblMicrophone.Location = new System.Drawing.Point(16, 26);
            this.lblMicrophone.Name = "lblMicrophone";
            this.lblMicrophone.Size = new System.Drawing.Size(83, 19);
            this.lblMicrophone.TabIndex = 0;
            this.lblMicrophone.Text = "Microphone";
            // 
            // comboMicrophones
            // 
            this.comboMicrophones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(234)))), ((int)(((byte)(226)))));
            this.comboMicrophones.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboMicrophones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMicrophones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboMicrophones.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboMicrophones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.comboMicrophones.IntegralHeight = false;
            this.comboMicrophones.ItemHeight = 36;
            this.comboMicrophones.Location = new System.Drawing.Point(16, 50);
            this.comboMicrophones.Name = "comboMicrophones";
            this.comboMicrophones.Size = new System.Drawing.Size(320, 42);
            this.comboMicrophones.TabIndex = 1;
            // 
            // lmtRecordStatus
            // 
            this.lmtRecordStatus.AutoSize = true;
            this.lmtRecordStatus.BackColor = System.Drawing.Color.Transparent;
            this.lmtRecordStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lmtRecordStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.lmtRecordStatus.Location = new System.Drawing.Point(360, 34);
            this.lmtRecordStatus.Name = "lmtRecordStatus";
            this.lmtRecordStatus.Size = new System.Drawing.Size(118, 21);
            this.lmtRecordStatus.TabIndex = 2;
            this.lmtRecordStatus.Text = "Not Recording";
            this.lmtRecordStatus.TypeRole = MaterialComponents.LMaterialTypeRole.TitleMedium;
            // 
            // lmtPgBar
            // 
            this.lmtPgBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lmtPgBar.Location = new System.Drawing.Point(360, 66);
            this.lmtPgBar.Name = "lmtPgBar";
            this.lmtPgBar.Size = new System.Drawing.Size(550, 16);
            this.lmtPgBar.TabIndex = 3;
            this.lmtPgBar.TabStop = false;
            // 
            // pnlAudioButtons
            // 
            this.pnlAudioButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlAudioButtons.Controls.Add(this.btnRecord);
            this.pnlAudioButtons.Controls.Add(this.btnStop);
            this.pnlAudioButtons.Controls.Add(this.lmtSave);
            this.pnlAudioButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAudioButtons.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.pnlAudioButtons.Location = new System.Drawing.Point(12, 106);
            this.pnlAudioButtons.Name = "pnlAudioButtons";
            this.pnlAudioButtons.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.pnlAudioButtons.Size = new System.Drawing.Size(898, 56);
            this.pnlAudioButtons.TabIndex = 4;
            // 
            // btnRecord
            // 
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.btnRecord.Location = new System.Drawing.Point(16, 8);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(140, 40);
            this.btnRecord.TabIndex = 0;
            this.btnRecord.Text = "Record";
            this.btnRecord.Click += new System.EventHandler(this.BtnRecord_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.btnStop.Location = new System.Drawing.Point(164, 8);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(140, 40);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // lmtSave
            // 
            this.lmtSave.Enabled = false;
            this.lmtSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lmtSave.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.lmtSave.Location = new System.Drawing.Point(312, 8);
            this.lmtSave.Name = "lmtSave";
            this.lmtSave.Size = new System.Drawing.Size(160, 40);
            this.lmtSave.TabIndex = 2;
            this.lmtSave.Text = "Save Recording";
            this.lmtSave.Click += new System.EventHandler(this.LmtSave_Click);
            // 
            // grpPrescription
            // 
            this.grpPrescription.Controls.Add(this.lblMedicine);
            this.grpPrescription.Controls.Add(this.cboMedicine);
            this.grpPrescription.Controls.Add(this.numQuantity);
            this.grpPrescription.Controls.Add(this.txtDosage);
            this.grpPrescription.Controls.Add(this.btnAddItem);
            this.grpPrescription.Controls.Add(this.lstPrescriptionItems);
            this.grpPrescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPrescription.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.grpPrescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(79)))), ((int)(((byte)(39)))));
            this.grpPrescription.Location = new System.Drawing.Point(6, 416);
            this.grpPrescription.Name = "grpPrescription";
            this.grpPrescription.Padding = new System.Windows.Forms.Padding(12, 8, 12, 12);
            this.grpPrescription.Size = new System.Drawing.Size(922, 200);
            this.grpPrescription.TabIndex = 1;
            this.grpPrescription.TabStop = false;
            this.grpPrescription.Text = "Prescription";
            // 
            // lblMedicine
            // 
            this.lblMedicine.AutoSize = true;
            this.lblMedicine.BackColor = System.Drawing.Color.Transparent;
            this.lblMedicine.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblMedicine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.lblMedicine.Location = new System.Drawing.Point(16, 26);
            this.lblMedicine.Name = "lblMedicine";
            this.lblMedicine.Size = new System.Drawing.Size(64, 19);
            this.lblMedicine.TabIndex = 0;
            this.lblMedicine.Text = "Medicine";
            // 
            // cboMedicine
            // 
            this.cboMedicine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(234)))), ((int)(((byte)(226)))));
            this.cboMedicine.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMedicine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedicine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMedicine.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboMedicine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.cboMedicine.IntegralHeight = false;
            this.cboMedicine.ItemHeight = 36;
            this.cboMedicine.Location = new System.Drawing.Point(16, 50);
            this.cboMedicine.Name = "cboMedicine";
            this.cboMedicine.Size = new System.Drawing.Size(300, 42);
            this.cboMedicine.TabIndex = 1;
            // 
            // numQuantity
            // 
            this.numQuantity.LabelText = "Qty";
            this.numQuantity.Location = new System.Drawing.Point(332, 22);
            this.numQuantity.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 84);
            this.numQuantity.TabIndex = 2;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtDosage
            // 
            this.txtDosage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDosage.LabelText = "Dosage Instructions";
            this.txtDosage.Location = new System.Drawing.Point(462, 22);
            this.txtDosage.Name = "txtDosage";
            this.txtDosage.Size = new System.Drawing.Size(445, 84);
            this.txtDosage.TabIndex = 3;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.btnAddItem.Location = new System.Drawing.Point(1546, 50);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(100, 40);
            this.btnAddItem.TabIndex = 4;
            this.btnAddItem.Text = "Add";
            this.btnAddItem.Click += new System.EventHandler(this.BtnAddItem_Click);
            // 
            // lstPrescriptionItems
            // 
            this.lstPrescriptionItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPrescriptionItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(234)))));
            this.lstPrescriptionItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstPrescriptionItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstPrescriptionItems.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lstPrescriptionItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.lstPrescriptionItems.IntegralHeight = false;
            this.lstPrescriptionItems.ItemHeight = 40;
            this.lstPrescriptionItems.Location = new System.Drawing.Point(16, 114);
            this.lstPrescriptionItems.Name = "lstPrescriptionItems";
            this.lstPrescriptionItems.Size = new System.Drawing.Size(891, 72);
            this.lstPrescriptionItems.TabIndex = 5;
            // 
            // grpNotes
            // 
            this.grpNotes.Controls.Add(this.txtDiagnosis);
            this.grpNotes.Controls.Add(this.numFee);
            this.grpNotes.Controls.Add(this.rtxtNotes);
            this.grpNotes.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpNotes.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.grpNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(79)))), ((int)(((byte)(39)))));
            this.grpNotes.Location = new System.Drawing.Point(6, 136);
            this.grpNotes.Name = "grpNotes";
            this.grpNotes.Padding = new System.Windows.Forms.Padding(12, 8, 12, 12);
            this.grpNotes.Size = new System.Drawing.Size(922, 280);
            this.grpNotes.TabIndex = 2;
            this.grpNotes.TabStop = false;
            this.grpNotes.Text = "Consultation Notes";
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiagnosis.LabelText = "Diagnosis";
            this.txtDiagnosis.Location = new System.Drawing.Point(16, 28);
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.Size = new System.Drawing.Size(891, 84);
            this.txtDiagnosis.TabIndex = 0;
            // 
            // numFee
            // 
            this.numFee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numFee.DecimalPlaces = 2;
            this.numFee.LabelText = "Consultation Fee (LKR)";
            this.numFee.Location = new System.Drawing.Point(1346, 28);
            this.numFee.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numFee.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numFee.Name = "numFee";
            this.numFee.Size = new System.Drawing.Size(300, 84);
            this.numFee.TabIndex = 1;
            this.numFee.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // rtxtNotes
            // 
            this.rtxtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtNotes.LabelText = "Notes";
            this.rtxtNotes.Location = new System.Drawing.Point(16, 120);
            this.rtxtNotes.Name = "rtxtNotes";
            this.rtxtNotes.Size = new System.Drawing.Size(891, 148);
            this.rtxtNotes.TabIndex = 2;
            // 
            // grpPatientInfo
            // 
            this.grpPatientInfo.Controls.Add(this.lmtPatientName);
            this.grpPatientInfo.Controls.Add(this.lmtConsultationID);
            this.grpPatientInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPatientInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.grpPatientInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(79)))), ((int)(((byte)(39)))));
            this.grpPatientInfo.Location = new System.Drawing.Point(6, 12);
            this.grpPatientInfo.Name = "grpPatientInfo";
            this.grpPatientInfo.Padding = new System.Windows.Forms.Padding(12, 8, 12, 12);
            this.grpPatientInfo.Size = new System.Drawing.Size(922, 124);
            this.grpPatientInfo.TabIndex = 3;
            this.grpPatientInfo.TabStop = false;
            this.grpPatientInfo.Text = "Patient Information";
            // 
            // lmtPatientName
            // 
            this.lmtPatientName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lmtPatientName.LabelText = "Patient Name";
            this.lmtPatientName.Location = new System.Drawing.Point(16, 28);
            this.lmtPatientName.Name = "lmtPatientName";
            this.lmtPatientName.ReadOnly = true;
            this.lmtPatientName.Size = new System.Drawing.Size(891, 84);
            this.lmtPatientName.TabIndex = 0;
            // 
            // lmtConsultationID
            // 
            this.lmtConsultationID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lmtConsultationID.LabelText = "Consultation ID";
            this.lmtConsultationID.Location = new System.Drawing.Point(1346, 28);
            this.lmtConsultationID.Name = "lmtConsultationID";
            this.lmtConsultationID.ReadOnly = true;
            this.lmtConsultationID.Size = new System.Drawing.Size(300, 84);
            this.lmtConsultationID.TabIndex = 1;
            // 
            // btnSaveConsultation
            // 
            this.btnSaveConsultation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSaveConsultation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveConsultation.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.btnSaveConsultation.Location = new System.Drawing.Point(6, 790);
            this.btnSaveConsultation.Name = "btnSaveConsultation";
            this.btnSaveConsultation.Size = new System.Drawing.Size(922, 48);
            this.btnSaveConsultation.TabIndex = 4;
            this.btnSaveConsultation.Text = "Save Consultation";
            this.btnSaveConsultation.Click += new System.EventHandler(this.BtnSaveConsultation_Click);
            // 
            // ConsultationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 850);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1120, 760);
            this.Name = "ConsultationForm";
            this.Text = "Consultation Workspace";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConsultationForm_FormClosing);
            this.Load += new System.EventHandler(this.ConsultationForm_Load);
            this.pnlLeft.ResumeLayout(false);
            this.grpQueue.ResumeLayout(false);
            this.grpCheckIn.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.grpAudio.ResumeLayout(false);
            this.grpAudio.PerformLayout();
            this.pnlAudioButtons.ResumeLayout(false);
            this.grpPrescription.ResumeLayout(false);
            this.grpPrescription.PerformLayout();
            this.grpNotes.ResumeLayout(false);
            this.grpPatientInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LMaterialPanel pnlLeft;
        private LMaterialGroupBox grpCheckIn;
        private LMaterialButton btnCheckIn;
        private LMaterialListBox lstCheckIn;
        private LMaterialGroupBox grpQueue;
        private LMaterialButton btnCallNext;
        private LMaterialListBox lstQueue;

        private LMaterialPanel pnlRight;
        private LMaterialButton btnSaveConsultation;
        private LMaterialGroupBox grpPatientInfo;
        private LMaterialTextBox lmtPatientName;
        private LMaterialTextBox lmtConsultationID;

        private LMaterialGroupBox grpNotes;
        private LMaterialTextBox txtDiagnosis;
        private LMaterialNumericUpDown numFee;
        private LMaterialRichTextBox rtxtNotes;

        private LMaterialGroupBox grpPrescription;
        private LMaterialLabel lblMedicine;
        private LMaterialComboBox cboMedicine;
        private LMaterialNumericUpDown numQuantity;
        private LMaterialTextBox txtDosage;
        private LMaterialButton btnAddItem;
        private LMaterialListBox lstPrescriptionItems;

        private LMaterialGroupBox grpAudio;
        private LMaterialPanel pnlAudioButtons;
        private LMaterialButton lmtSave;
        private LMaterialButton btnStop;
        private LMaterialButton btnRecord;
        private LMaterialLabel lblMicrophone;
        private LMaterialComboBox comboMicrophones;
        private LMaterialLabel lmtRecordStatus;
        private LMaterialProgressBar lmtPgBar;
    }
}
