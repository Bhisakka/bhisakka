namespace Bhisakka
{
    partial class DatabaseTest
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
            this.lMaterialCard1 = new MaterialComponents.LMaterialCard();
            this.lbtn_db_version = new MaterialComponents.LMaterialButton();
            this.lMaterialCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lMaterialCard1
            // 
            this.lMaterialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(234)))));
            this.lMaterialCard1.Controls.Add(this.lbtn_db_version);
            this.lMaterialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lMaterialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.lMaterialCard1.Location = new System.Drawing.Point(0, 0);
            this.lMaterialCard1.Name = "lMaterialCard1";
            this.lMaterialCard1.Padding = new System.Windows.Forms.Padding(16);
            this.lMaterialCard1.Size = new System.Drawing.Size(284, 161);
            this.lMaterialCard1.TabIndex = 0;
            // 
            // lbtn_db_version
            // 
            this.lbtn_db_version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbtn_db_version.FlatAppearance.BorderSize = 0;
            this.lbtn_db_version.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbtn_db_version.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.lbtn_db_version.Location = new System.Drawing.Point(125, 102);
            this.lbtn_db_version.Name = "lbtn_db_version";
            this.lbtn_db_version.Size = new System.Drawing.Size(140, 40);
            this.lbtn_db_version.TabIndex = 0;
            this.lbtn_db_version.Text = "Get DB Version";
            this.lbtn_db_version.UseVisualStyleBackColor = true;
            this.lbtn_db_version.Click += new System.EventHandler(this.lbtn_db_version_Click);
            // 
            // DatabaseTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.lMaterialCard1);
            this.MinimumSize = new System.Drawing.Size(270, 150);
            this.Name = "DatabaseTest";
            this.Text = "DatabaseTest";
            this.lMaterialCard1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialComponents.LMaterialCard lMaterialCard1;
        private MaterialComponents.LMaterialButton lbtn_db_version;
    }
}

