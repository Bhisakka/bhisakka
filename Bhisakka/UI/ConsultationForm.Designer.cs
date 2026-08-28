using System.Drawing;
using System.Windows.Forms;
using MaterialComponents;

namespace Bhisakka.UI
{
    partial class ConsultationForm
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
        private void InitializeComponent()
        {
            this.lmgpPatientsinfo = new MaterialComponents.LMaterialGroupBox();
            this.lmtDoctorName = new MaterialComponents.LMaterialTextBox();
            this.lmtConsultationID = new MaterialComponents.LMaterialTextBox();
            this.lmtPatientName = new MaterialComponents.LMaterialTextBox();
            this.lmtConsultationNotes = new MaterialComponents.LMaterialGroupBox();
            this.lmtAudioRecording = new MaterialComponents.LMaterialGroupBox();
<<<<<<< HEAD
            this.lmtPgBar = new MaterialComponents.LMaterialProgressBar();
=======
>>>>>>> f9b4e328b9b7c41011b7f99d507121724a6340d4
            this.lmtRecordStatus = new MaterialComponents.LMaterialLabel();
            this.lmtSave = new MaterialComponents.LMaterialButton();
            this.btnRecord = new MaterialComponents.LMaterialButton();
            this.btnStop = new MaterialComponents.LMaterialButton();
            this.comboMicrophones = new MaterialComponents.LMaterialComboBox();
<<<<<<< HEAD
            this.lblTitle = new System.Windows.Forms.Label();
=======
            this.lmtPgBar = new MaterialComponents.LMaterialProgressBar();
>>>>>>> f9b4e328b9b7c41011b7f99d507121724a6340d4
            this.lmgpPatientsinfo.SuspendLayout();
            this.lmtAudioRecording.SuspendLayout();
            this.SuspendLayout();
            // 
            // lmgpPatientsinfo
            // 
            this.lmgpPatientsinfo.Controls.Add(this.lmtDoctorName);
            this.lmgpPatientsinfo.Controls.Add(this.lmtConsultationID);
            this.lmgpPatientsinfo.Controls.Add(this.lmtPatientName);
            this.lmgpPatientsinfo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.lmgpPatientsinfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(79)))), ((int)(((byte)(39)))));
            this.lmgpPatientsinfo.Location = new System.Drawing.Point(12, 88);
            this.lmgpPatientsinfo.Name = "lmgpPatientsinfo";
            this.lmgpPatientsinfo.Size = new System.Drawing.Size(307, 224);
            this.lmgpPatientsinfo.TabIndex = 1;
            this.lmgpPatientsinfo.TabStop = false;
            this.lmgpPatientsinfo.Text = "Patient Information";
            // 
            // lmtDoctorName
            // 
            this.lmtDoctorName.LabelText = "Doctor Name";
            this.lmtDoctorName.Location = new System.Drawing.Point(6, 120);
            this.lmtDoctorName.Name = "lmtDoctorName";
            this.lmtDoctorName.Size = new System.Drawing.Size(240, 65);
            this.lmtDoctorName.TabIndex = 2;
            // 
            // lmtConsultationID
            // 
            this.lmtConsultationID.LabelText = "Consultation ID";
            this.lmtConsultationID.Location = new System.Drawing.Point(6, 72);
            this.lmtConsultationID.Name = "lmtConsultationID";
            this.lmtConsultationID.Size = new System.Drawing.Size(240, 65);
            this.lmtConsultationID.TabIndex = 1;
            // 
            // lmtPatientName
            // 
            this.lmtPatientName.LabelText = "Patient Name";
            this.lmtPatientName.Location = new System.Drawing.Point(6, 25);
            this.lmtPatientName.Name = "lmtPatientName";
            this.lmtPatientName.Size = new System.Drawing.Size(240, 65);
            this.lmtPatientName.TabIndex = 0;
            // 
            // lmtConsultationNotes
            // 
            this.lmtConsultationNotes.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.lmtConsultationNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(79)))), ((int)(((byte)(39)))));
            this.lmtConsultationNotes.Location = new System.Drawing.Point(12, 318);
            this.lmtConsultationNotes.Name = "lmtConsultationNotes";
            this.lmtConsultationNotes.Size = new System.Drawing.Size(320, 140);
            this.lmtConsultationNotes.TabIndex = 2;
            this.lmtConsultationNotes.TabStop = false;
            this.lmtConsultationNotes.Text = "Consultation Notes";
            // 
            // lmtAudioRecording
            // 
            this.lmtAudioRecording.Controls.Add(this.lmtPgBar);
            this.lmtAudioRecording.Controls.Add(this.lmtRecordStatus);
            this.lmtAudioRecording.Controls.Add(this.lmtSave);
            this.lmtAudioRecording.Controls.Add(this.btnRecord);
            this.lmtAudioRecording.Controls.Add(this.btnStop);
            this.lmtAudioRecording.Controls.Add(this.comboMicrophones);
            this.lmtAudioRecording.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.lmtAudioRecording.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(79)))), ((int)(((byte)(39)))));
            this.lmtAudioRecording.Location = new System.Drawing.Point(12, 474);
            this.lmtAudioRecording.Name = "lmtAudioRecording";
            this.lmtAudioRecording.Size = new System.Drawing.Size(868, 140);
            this.lmtAudioRecording.TabIndex = 3;
            this.lmtAudioRecording.TabStop = false;
            this.lmtAudioRecording.Text = "Audio Recording";
            // 
<<<<<<< HEAD
            // lmtPgBar
            // 
            this.lmtPgBar.Location = new System.Drawing.Point(224, 34);
            this.lmtPgBar.Name = "lmtPgBar";
            this.lmtPgBar.Size = new System.Drawing.Size(240, 28);
            this.lmtPgBar.TabIndex = 6;
            this.lmtPgBar.TabStop = false;
            this.lmtPgBar.Text = "lMaterialProgressBar1";
            // 
=======
>>>>>>> f9b4e328b9b7c41011b7f99d507121724a6340d4
            // lmtRecordStatus
            // 
            this.lmtRecordStatus.AutoSize = true;
            this.lmtRecordStatus.BackColor = System.Drawing.Color.Transparent;
            this.lmtRecordStatus.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lmtRecordStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.lmtRecordStatus.Location = new System.Drawing.Point(57, 43);
            this.lmtRecordStatus.Name = "lmtRecordStatus";
            this.lmtRecordStatus.Size = new System.Drawing.Size(97, 19);
            this.lmtRecordStatus.TabIndex = 4;
            this.lmtRecordStatus.Text = "Not Recording";
            this.lmtRecordStatus.Click += new System.EventHandler(this.lMaterialLabel1_Click);
            // 
            // lmtSave
            // 
            this.lmtSave.FlatAppearance.BorderSize = 0;
            this.lmtSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lmtSave.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.lmtSave.Location = new System.Drawing.Point(411, 94);
            this.lmtSave.Name = "lmtSave";
            this.lmtSave.Size = new System.Drawing.Size(140, 40);
            this.lmtSave.TabIndex = 2;
            this.lmtSave.Text = "Save";
            this.lmtSave.UseVisualStyleBackColor = true;
<<<<<<< HEAD
            this.lmtSave.Click += new System.EventHandler(this.lmtSave_Click);
=======
>>>>>>> f9b4e328b9b7c41011b7f99d507121724a6340d4
            // 
            // btnRecord
            // 
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.btnRecord.Location = new System.Drawing.Point(37, 94);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(140, 40);
            this.btnRecord.TabIndex = 0;
            this.btnRecord.Text = "Record";
            this.btnRecord.Click += new System.EventHandler(this.BtnRecord_Click);
            // 
            // btnStop
            // 
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.btnStop.Location = new System.Drawing.Point(224, 94);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(140, 40);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // comboMicrophones
            // 
            this.comboMicrophones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(234)))), ((int)(((byte)(226)))));
            this.comboMicrophones.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboMicrophones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMicrophones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboMicrophones.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboMicrophones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.comboMicrophones.FormattingEnabled = true;
            this.comboMicrophones.IntegralHeight = false;
            this.comboMicrophones.ItemHeight = 36;
            this.comboMicrophones.Location = new System.Drawing.Point(518, 25);
            this.comboMicrophones.Name = "comboMicrophones";
            this.comboMicrophones.Size = new System.Drawing.Size(240, 42);
            this.comboMicrophones.TabIndex = 5;
            // 
<<<<<<< HEAD
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(389, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(296, 32);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "PATIENT CONSULTATION";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
=======
            // lmtPgBar
            // 
            this.lmtPgBar.Location = new System.Drawing.Point(224, 34);
            this.lmtPgBar.Name = "lmtPgBar";
            this.lmtPgBar.Size = new System.Drawing.Size(240, 28);
            this.lmtPgBar.TabIndex = 6;
            this.lmtPgBar.TabStop = false;
            this.lmtPgBar.Text = "lMaterialProgressBar1";
>>>>>>> f9b4e328b9b7c41011b7f99d507121724a6340d4
            // 
            // ConsultationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 658);
<<<<<<< HEAD
            this.Controls.Add(this.lblTitle);
=======
>>>>>>> f9b4e328b9b7c41011b7f99d507121724a6340d4
            this.Controls.Add(this.lmtAudioRecording);
            this.Controls.Add(this.lmtConsultationNotes);
            this.Controls.Add(this.lmgpPatientsinfo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConsultationForm";
            this.Text = "ConsultationForm";
            this.Load += new System.EventHandler(this.ConsultationForm_Load);
            this.lmgpPatientsinfo.ResumeLayout(false);
            this.lmtAudioRecording.ResumeLayout(false);
            this.lmtAudioRecording.PerformLayout();
            this.ResumeLayout(false);
<<<<<<< HEAD
            this.PerformLayout();
=======
>>>>>>> f9b4e328b9b7c41011b7f99d507121724a6340d4

        }

        #endregion
        private MaterialComponents.LMaterialGroupBox lmgpPatientsinfo;
        private MaterialComponents.LMaterialTextBox lmtConsultationID;
        private MaterialComponents.LMaterialTextBox lmtPatientName;
        private MaterialComponents.LMaterialTextBox lmtDoctorName;
        private MaterialComponents.LMaterialGroupBox lmtConsultationNotes;
        private MaterialComponents.LMaterialGroupBox lmtAudioRecording;
        private MaterialComponents.LMaterialButton lmtSave;
        private MaterialComponents.LMaterialLabel lmtRecordStatus;
        //private MaterialComponents.LMaterialComboBox comboMicrophones;
        private MaterialComponents.LMaterialButton btnRecord;
        private MaterialComponents.LMaterialButton btnStop;
        private LMaterialComboBox comboMicrophones;
        private LMaterialProgressBar lmtPgBar;
<<<<<<< HEAD
        private Label lblTitle;
=======
>>>>>>> f9b4e328b9b7c41011b7f99d507121724a6340d4
    }
}