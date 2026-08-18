namespace Bhisakka.UI.AuthN
{
    partial class SignIn
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
            this.LblTitle = new MaterialComponents.LMaterialLabel();
            this.lMaterialPanel1 = new MaterialComponents.LMaterialPanel();
            this.TxtUsername = new MaterialComponents.LMaterialTextBox();
            this.TxtPassword = new MaterialComponents.LMaterialTextBox();
            this.TxtSubmit = new MaterialComponents.LMaterialButton();
            this.lMaterialPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.LblTitle.Location = new System.Drawing.Point(0, 0);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(584, 50);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "Sign In";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lMaterialPanel1
            // 
            this.lMaterialPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.lMaterialPanel1.Controls.Add(this.TxtSubmit);
            this.lMaterialPanel1.Controls.Add(this.TxtPassword);
            this.lMaterialPanel1.Controls.Add(this.TxtUsername);
            this.lMaterialPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lMaterialPanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.lMaterialPanel1.Location = new System.Drawing.Point(0, 50);
            this.lMaterialPanel1.Name = "lMaterialPanel1";
            this.lMaterialPanel1.Size = new System.Drawing.Size(584, 261);
            this.lMaterialPanel1.TabIndex = 1;
            // 
            // TxtUsername
            // 
            this.TxtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtUsername.LabelText = "Username";
            this.TxtUsername.Location = new System.Drawing.Point(12, 3);
            this.TxtUsername.MaxLength = 100;
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Size = new System.Drawing.Size(560, 84);
            this.TxtUsername.TabIndex = 0;
            this.TxtUsername.TextChanged += new System.EventHandler(this.TxtUsername_TextChanged);
            // 
            // TxtPassword
            // 
            this.TxtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPassword.LabelText = "Password";
            this.TxtPassword.Location = new System.Drawing.Point(12, 93);
            this.TxtPassword.MaxLength = 32;
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(560, 84);
            this.TxtPassword.TabIndex = 0;
            this.TxtPassword.UseSystemPasswordChar = true;
            this.TxtPassword.TextChanged += new System.EventHandler(this.TxtPassword_TextChanged);
            // 
            // TxtSubmit
            // 
            this.TxtSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSubmit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TxtSubmit.FlatAppearance.BorderSize = 0;
            this.TxtSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TxtSubmit.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.TxtSubmit.Location = new System.Drawing.Point(150, 183);
            this.TxtSubmit.Name = "TxtSubmit";
            this.TxtSubmit.Size = new System.Drawing.Size(300, 40);
            this.TxtSubmit.TabIndex = 1;
            this.TxtSubmit.Text = "Sign In";
            this.TxtSubmit.UseVisualStyleBackColor = true;
            this.TxtSubmit.Click += new System.EventHandler(this.TxtSubmit_Click);
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.Controls.Add(this.lMaterialPanel1);
            this.Controls.Add(this.LblTitle);
            this.MinimumSize = new System.Drawing.Size(600, 350);
            this.Name = "SignIn";
            this.Text = "SignIn";
            this.lMaterialPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialComponents.LMaterialLabel LblTitle;
        private MaterialComponents.LMaterialPanel lMaterialPanel1;
        private MaterialComponents.LMaterialTextBox TxtUsername;
        private MaterialComponents.LMaterialTextBox TxtPassword;
        private MaterialComponents.LMaterialButton TxtSubmit;
    }
}