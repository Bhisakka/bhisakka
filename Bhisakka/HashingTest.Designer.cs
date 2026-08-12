namespace Bhisakka
{
    partial class HashingTest
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
            this.TxtRaw = new MaterialComponents.LMaterialTextBox();
            this.LblHashed = new MaterialComponents.LMaterialLabel();
            this.BtnLogin = new MaterialComponents.LMaterialButton();
            this.SuspendLayout();
            // 
            // TxtRaw
            // 
            this.TxtRaw.LabelText = "Username";
            this.TxtRaw.Location = new System.Drawing.Point(65, 35);
            this.TxtRaw.Name = "TxtRaw";
            this.TxtRaw.Size = new System.Drawing.Size(240, 84);
            this.TxtRaw.TabIndex = 0;
            // 
            // LblHashed
            // 
            this.LblHashed.AutoSize = true;
            this.LblHashed.BackColor = System.Drawing.Color.Transparent;
            this.LblHashed.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.LblHashed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.LblHashed.Location = new System.Drawing.Point(69, 138);
            this.LblHashed.Name = "LblHashed";
            this.LblHashed.Size = new System.Drawing.Size(0, 30);
            this.LblHashed.TabIndex = 1;
            // 
            // BtnLogin
            // 
            this.BtnLogin.FlatAppearance.BorderSize = 0;
            this.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.BtnLogin.Location = new System.Drawing.Point(65, 224);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(178, 54);
            this.BtnLogin.TabIndex = 2;
            this.BtnLogin.Text = "LogIn";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // HashingTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.LblHashed);
            this.Controls.Add(this.TxtRaw);
            this.Name = "HashingTest";
            this.Text = "Hashing Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialComponents.LMaterialTextBox TxtRaw;
        private MaterialComponents.LMaterialLabel LblHashed;
        private MaterialComponents.LMaterialButton BtnLogin;
    }
}