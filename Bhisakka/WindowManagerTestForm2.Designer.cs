namespace Bhisakka
{
    partial class WindowManagerTestForm2
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
            this.BtnGoBack = new MaterialComponents.LMaterialButton();
            this.SuspendLayout();
            // 
            // BtnGoBack
            // 
            this.BtnGoBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGoBack.FlatAppearance.BorderSize = 0;
            this.BtnGoBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGoBack.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.BtnGoBack.Location = new System.Drawing.Point(648, 398);
            this.BtnGoBack.Name = "BtnGoBack";
            this.BtnGoBack.Size = new System.Drawing.Size(140, 40);
            this.BtnGoBack.TabIndex = 0;
            this.BtnGoBack.Text = "Go Back & Close";
            this.BtnGoBack.UseVisualStyleBackColor = true;
            this.BtnGoBack.Click += new System.EventHandler(this.BtnGoBack_Click);
            // 
            // WindowManagerTestForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnGoBack);
            this.Name = "WindowManagerTestForm2";
            this.Text = "WindowManagerTestForm2";
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialComponents.LMaterialButton BtnGoBack;
    }
}