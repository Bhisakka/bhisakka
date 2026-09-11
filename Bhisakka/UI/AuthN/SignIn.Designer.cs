namespace Bhisakka.UI.AuthN
{
    partial class SignIn
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlCard = new MaterialComponents.LMaterialCard();
            this.LblTitle = new MaterialComponents.LMaterialLabel();
            this.TxtUsername = new MaterialComponents.LMaterialTextBox();
            this.TxtPassword = new MaterialComponents.LMaterialTextBox();
            this.TxtSubmit = new MaterialComponents.LMaterialButton();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlCard
            //
            this.pnlCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCard.Controls.Add(this.LblTitle);
            this.pnlCard.Controls.Add(this.TxtUsername);
            this.pnlCard.Controls.Add(this.TxtPassword);
            this.pnlCard.Controls.Add(this.TxtSubmit);
            this.pnlCard.Location = new System.Drawing.Point(120, 44);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(360, 360);
            this.pnlCard.TabIndex = 0;
            //
            // LblTitle
            //
            this.LblTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle.Location = new System.Drawing.Point(24, 28);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(312, 44);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "Sign In";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTitle.TypeRole = MaterialComponents.LMaterialTypeRole.HeadlineSmall;
            //
            // TxtUsername
            //
            this.TxtUsername.LabelText = "Username";
            this.TxtUsername.Location = new System.Drawing.Point(24, 84);
            this.TxtUsername.MaxLength = 100;
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Size = new System.Drawing.Size(312, 84);
            this.TxtUsername.TabIndex = 1;
            this.TxtUsername.TextChanged += new System.EventHandler(this.TxtUsername_TextChanged);
            //
            // TxtPassword
            //
            this.TxtPassword.LabelText = "Password";
            this.TxtPassword.Location = new System.Drawing.Point(24, 174);
            this.TxtPassword.MaxLength = 32;
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(312, 84);
            this.TxtPassword.TabIndex = 2;
            this.TxtPassword.UseSystemPasswordChar = true;
            this.TxtPassword.TextChanged += new System.EventHandler(this.TxtPassword_TextChanged);
            //
            // TxtSubmit
            //
            this.TxtSubmit.Location = new System.Drawing.Point(24, 280);
            this.TxtSubmit.Name = "TxtSubmit";
            this.TxtSubmit.Size = new System.Drawing.Size(312, 44);
            this.TxtSubmit.TabIndex = 3;
            this.TxtSubmit.Text = "Sign In";
            this.TxtSubmit.Click += new System.EventHandler(this.TxtSubmit_Click);
            //
            // SignIn
            //
            this.AcceptButton = this.TxtSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 448);
            this.Controls.Add(this.pnlCard);
            this.MinimumSize = new System.Drawing.Size(616, 487);
            this.Name = "SignIn";
            this.Text = "Bhisakka - Sign In";
            this.pnlCard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialComponents.LMaterialCard pnlCard;
        private MaterialComponents.LMaterialLabel LblTitle;
        private MaterialComponents.LMaterialTextBox TxtUsername;
        private MaterialComponents.LMaterialTextBox TxtPassword;
        private MaterialComponents.LMaterialButton TxtSubmit;
    }
}
