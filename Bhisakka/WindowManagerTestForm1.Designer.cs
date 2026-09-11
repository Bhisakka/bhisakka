namespace Bhisakka
{
    partial class WindowManagerTestForm1
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
            this.BtnGoNext = new MaterialComponents.LMaterialButton();
            this.SuspendLayout();
            // 
            // BtnGoNext
            // 
            this.BtnGoNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGoNext.FlatAppearance.BorderSize = 0;
            this.BtnGoNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGoNext.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.BtnGoNext.Location = new System.Drawing.Point(648, 398);
            this.BtnGoNext.Name = "BtnGoNext";
            this.BtnGoNext.Size = new System.Drawing.Size(140, 40);
            this.BtnGoNext.TabIndex = 0;
            this.BtnGoNext.Text = "Go to Form 2 & Hide";
            this.BtnGoNext.UseVisualStyleBackColor = true;
            this.BtnGoNext.Click += new System.EventHandler(this.BtnGoNext_Click);
            // 
            // WindowManagerTestForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnGoNext);
            this.Name = "WindowManagerTestForm1";
            this.Text = "WindowManagerTestForm1";
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialComponents.LMaterialButton BtnGoNext;
    }
}