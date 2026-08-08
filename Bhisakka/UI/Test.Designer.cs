namespace Bhisakka.UI
{
    partial class Test
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
            this.btn_pingdb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_pingdb
            // 
            this.btn_pingdb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_pingdb.Location = new System.Drawing.Point(0, 0);
            this.btn_pingdb.Name = "btn_pingdb";
            this.btn_pingdb.Size = new System.Drawing.Size(365, 204);
            this.btn_pingdb.TabIndex = 0;
            this.btn_pingdb.Text = "Ping Database";
            this.btn_pingdb.UseVisualStyleBackColor = true;
            this.btn_pingdb.Click += new System.EventHandler(this.btn_pingdb_Click);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 204);
            this.Controls.Add(this.btn_pingdb);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "Test";
            this.Text = "Test Database Connectivity";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_pingdb;
    }
}