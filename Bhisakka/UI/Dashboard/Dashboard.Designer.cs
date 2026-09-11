using System.Drawing;
using System.Windows.Forms;
using MaterialComponents;

namespace Bhisakka.UI.Dashboard
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.pnlNav = new MaterialComponents.LMaterialPanel();
            this.pnlNavButtons = new MaterialComponents.LMaterialFlowLayoutPanel();
            this.pnlNavFooter = new MaterialComponents.LMaterialPanel();
            this.btnLogout = new MaterialComponents.LMaterialButton();
            this.pnlNavHeader = new MaterialComponents.LMaterialPanel();
            this.lblAppName = new MaterialComponents.LMaterialLabel();
            this.lblAppSub = new MaterialComponents.LMaterialLabel();
            this.divNav = new MaterialComponents.LMaterialDivider();
            this.lblWelcome = new MaterialComponents.LMaterialLabel();
            this.lblRole = new MaterialComponents.LMaterialLabel();
            this.pnlMediaControllerHost = new MaterialComponents.LMaterialPanel();
            this.pnlContent = new MaterialComponents.LMaterialPanel();
            this.lblContentTitle = new MaterialComponents.LMaterialLabel();
            this.pnlNav.SuspendLayout();
            this.pnlNavFooter.SuspendLayout();
            this.pnlNavHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(234)))));
            this.pnlNav.Controls.Add(this.pnlNavButtons);
            this.pnlNav.Controls.Add(this.pnlNavFooter);
            this.pnlNav.Controls.Add(this.pnlNavHeader);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNav.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.pnlNav.Location = new System.Drawing.Point(0, 0);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(300, 636);
            this.pnlNav.SurfaceRole = MaterialComponents.LMaterialSurfaceRole.SurfaceContainerLow;
            this.pnlNav.TabIndex = 1;
            // 
            // pnlNavButtons
            // 
            this.pnlNavButtons.AutoScroll = true;
            this.pnlNavButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlNavButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNavButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlNavButtons.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.pnlNavButtons.Location = new System.Drawing.Point(0, 150);
            this.pnlNavButtons.Name = "pnlNavButtons";
            this.pnlNavButtons.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlNavButtons.Size = new System.Drawing.Size(300, 418);
            this.pnlNavButtons.TabIndex = 0;
            this.pnlNavButtons.WrapContents = false;
            // 
            // pnlNavFooter
            // 
            this.pnlNavFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(234)))));
            this.pnlNavFooter.Controls.Add(this.btnLogout);
            this.pnlNavFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNavFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.pnlNavFooter.Location = new System.Drawing.Point(0, 568);
            this.pnlNavFooter.Name = "pnlNavFooter";
            this.pnlNavFooter.Padding = new System.Windows.Forms.Padding(20, 12, 20, 16);
            this.pnlNavFooter.Size = new System.Drawing.Size(300, 68);
            this.pnlNavFooter.SurfaceRole = MaterialComponents.LMaterialSurfaceRole.SurfaceContainerLow;
            this.pnlNavFooter.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.btnLogout.Location = new System.Drawing.Point(20, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(260, 40);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.Variant = MaterialComponents.LMaterialButtonVariant.Outlined;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // pnlNavHeader
            // 
            this.pnlNavHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(234)))));
            this.pnlNavHeader.Controls.Add(this.lblAppName);
            this.pnlNavHeader.Controls.Add(this.lblAppSub);
            this.pnlNavHeader.Controls.Add(this.divNav);
            this.pnlNavHeader.Controls.Add(this.lblWelcome);
            this.pnlNavHeader.Controls.Add(this.lblRole);
            this.pnlNavHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.pnlNavHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlNavHeader.Name = "pnlNavHeader";
            this.pnlNavHeader.Size = new System.Drawing.Size(300, 150);
            this.pnlNavHeader.SurfaceRole = MaterialComponents.LMaterialSurfaceRole.SurfaceContainerLow;
            this.pnlNavHeader.TabIndex = 2;
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.BackColor = System.Drawing.Color.Transparent;
            this.lblAppName.ColorRole = MaterialComponents.LMaterialColorRole.Primary;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 16.5F);
            this.lblAppName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(79)))), ((int)(((byte)(39)))));
            this.lblAppName.Location = new System.Drawing.Point(20, 20);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(96, 30);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "Bhisakka";
            this.lblAppName.TypeRole = MaterialComponents.LMaterialTypeRole.TitleLarge;
            // 
            // lblAppSub
            // 
            this.lblAppSub.AutoSize = true;
            this.lblAppSub.BackColor = System.Drawing.Color.Transparent;
            this.lblAppSub.ColorRole = MaterialComponents.LMaterialColorRole.OnSurfaceVariant;
            this.lblAppSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAppSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(68)))), ((int)(((byte)(60)))));
            this.lblAppSub.Location = new System.Drawing.Point(20, 52);
            this.lblAppSub.Name = "lblAppSub";
            this.lblAppSub.Size = new System.Drawing.Size(167, 15);
            this.lblAppSub.TabIndex = 1;
            this.lblAppSub.Text = "Ayurvedic Clinic Management";
            this.lblAppSub.TypeRole = MaterialComponents.LMaterialTypeRole.BodySmall;
            // 
            // divNav
            // 
            this.divNav.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divNav.Location = new System.Drawing.Point(20, 82);
            this.divNav.Name = "divNav";
            this.divNav.Size = new System.Drawing.Size(360, 1);
            this.divNav.TabIndex = 2;
            this.divNav.TabStop = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.lblWelcome.Location = new System.Drawing.Point(20, 98);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(79, 21);
            this.lblWelcome.TabIndex = 3;
            this.lblWelcome.Text = "Welcome";
            this.lblWelcome.TypeRole = MaterialComponents.LMaterialTypeRole.TitleMedium;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.BackColor = System.Drawing.Color.Transparent;
            this.lblRole.ColorRole = MaterialComponents.LMaterialColorRole.OnSurfaceVariant;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(68)))), ((int)(((byte)(60)))));
            this.lblRole.Location = new System.Drawing.Point(20, 124);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(35, 19);
            this.lblRole.TabIndex = 4;
            this.lblRole.Text = "Role";
            // 
            // pnlMediaControllerHost
            // 
            this.pnlMediaControllerHost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(229)))), ((int)(((byte)(221)))));
            this.pnlMediaControllerHost.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMediaControllerHost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.pnlMediaControllerHost.Location = new System.Drawing.Point(0, 636);
            this.pnlMediaControllerHost.Name = "pnlMediaControllerHost";
            this.pnlMediaControllerHost.Size = new System.Drawing.Size(1100, 64);
            this.pnlMediaControllerHost.SurfaceRole = MaterialComponents.LMaterialSurfaceRole.SurfaceContainerHigh;
            this.pnlMediaControllerHost.TabIndex = 2;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlContent.Controls.Add(this.lblContentTitle);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.pnlContent.Location = new System.Drawing.Point(300, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(24);
            this.pnlContent.Size = new System.Drawing.Size(800, 636);
            this.pnlContent.TabIndex = 0;
            // 
            // lblContentTitle
            // 
            this.lblContentTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblContentTitle.ColorRole = MaterialComponents.LMaterialColorRole.OnSurfaceVariant;
            this.lblContentTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblContentTitle.Font = new System.Drawing.Font("Segoe UI", 21F);
            this.lblContentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(68)))), ((int)(((byte)(60)))));
            this.lblContentTitle.Location = new System.Drawing.Point(24, 24);
            this.lblContentTitle.Name = "lblContentTitle";
            this.lblContentTitle.Size = new System.Drawing.Size(752, 588);
            this.lblContentTitle.TabIndex = 0;
            this.lblContentTitle.Text = "Bhisakka Ayurvedic Clinic\r\nSelect an option from the menu to begin.";
            this.lblContentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblContentTitle.TypeRole = MaterialComponents.LMaterialTypeRole.HeadlineMedium;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlNav);
            this.Controls.Add(this.pnlMediaControllerHost);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "Dashboard";
            this.Text = "Bhisakka - Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.pnlNav.ResumeLayout(false);
            this.pnlNavFooter.ResumeLayout(false);
            this.pnlNavHeader.ResumeLayout(false);
            this.pnlNavHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LMaterialPanel pnlNav;
        private LMaterialPanel pnlNavHeader;
        private LMaterialFlowLayoutPanel pnlNavButtons;
        private LMaterialPanel pnlNavFooter;
        private LMaterialLabel lblAppName;
        private LMaterialLabel lblAppSub;
        private LMaterialDivider divNav;
        private LMaterialLabel lblWelcome;
        private LMaterialLabel lblRole;
        private LMaterialButton btnLogout;
        internal LMaterialPanel pnlMediaControllerHost;
        private LMaterialPanel pnlContent;
        private LMaterialLabel lblContentTitle;
    }
}
