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
            this.pnlNav = new LMaterialPanel();
            this.pnlNavButtons = new LMaterialFlowLayoutPanel();
            this.pnlNavFooter = new LMaterialPanel();
            this.btnLogout = new LMaterialButton();
            this.pnlNavHeader = new LMaterialPanel();
            this.lblAppName = new LMaterialLabel();
            this.lblAppSub = new LMaterialLabel();
            this.divNav = new LMaterialDivider();
            this.lblWelcome = new LMaterialLabel();
            this.lblRole = new LMaterialLabel();
            this.pnlMediaControllerHost = new LMaterialPanel();
            this.pnlContent = new LMaterialPanel();
            this.lblContentTitle = new LMaterialLabel();

            this.pnlNav.SuspendLayout();
            this.pnlNavFooter.SuspendLayout();
            this.pnlNavHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();

            //
            // pnlNav (left navigation rail)
            //
            this.pnlNav.Dock = DockStyle.Left;
            this.pnlNav.Width = 300;
            this.pnlNav.SurfaceRole = LMaterialSurfaceRole.SurfaceContainerLow;
            this.pnlNav.Controls.Add(this.pnlNavButtons);
            this.pnlNav.Controls.Add(this.pnlNavFooter);
            this.pnlNav.Controls.Add(this.pnlNavHeader);
            this.pnlNav.Name = "pnlNav";

            //
            // pnlNavHeader
            //
            this.pnlNavHeader.Dock = DockStyle.Top;
            this.pnlNavHeader.Height = 150;
            this.pnlNavHeader.SurfaceRole = LMaterialSurfaceRole.SurfaceContainerLow;
            this.pnlNavHeader.Controls.Add(this.lblAppName);
            this.pnlNavHeader.Controls.Add(this.lblAppSub);
            this.pnlNavHeader.Controls.Add(this.divNav);
            this.pnlNavHeader.Controls.Add(this.lblWelcome);
            this.pnlNavHeader.Controls.Add(this.lblRole);
            this.pnlNavHeader.Name = "pnlNavHeader";

            this.lblAppName.AutoSize = true;
            this.lblAppName.Location = new Point(20, 20);
            this.lblAppName.TypeRole = LMaterialTypeRole.TitleLarge;
            this.lblAppName.ColorRole = LMaterialColorRole.Primary;
            this.lblAppName.Text = "Bhisakka";
            this.lblAppName.Name = "lblAppName";

            this.lblAppSub.AutoSize = true;
            this.lblAppSub.Location = new Point(20, 52);
            this.lblAppSub.TypeRole = LMaterialTypeRole.BodySmall;
            this.lblAppSub.ColorRole = LMaterialColorRole.OnSurfaceVariant;
            this.lblAppSub.Text = "Ayurvedic Clinic Management";
            this.lblAppSub.Name = "lblAppSub";

            this.divNav.Location = new Point(20, 82);
            this.divNav.Size = new Size(260, 1);
            this.divNav.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.divNav.Name = "divNav";

            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new Point(20, 98);
            this.lblWelcome.TypeRole = LMaterialTypeRole.TitleMedium;
            this.lblWelcome.Text = "Welcome";
            this.lblWelcome.Name = "lblWelcome";

            this.lblRole.AutoSize = true;
            this.lblRole.Location = new Point(20, 124);
            this.lblRole.TypeRole = LMaterialTypeRole.BodyMedium;
            this.lblRole.ColorRole = LMaterialColorRole.OnSurfaceVariant;
            this.lblRole.Text = "Role";
            this.lblRole.Name = "lblRole";

            //
            // pnlNavButtons (scrollable stack of navigation buttons)
            //
            this.pnlNavButtons.Dock = DockStyle.Fill;
            this.pnlNavButtons.FlowDirection = FlowDirection.TopDown;
            this.pnlNavButtons.WrapContents = false;
            this.pnlNavButtons.AutoScroll = true;
            this.pnlNavButtons.Padding = new Padding(12, 8, 12, 8);
            this.pnlNavButtons.Name = "pnlNavButtons";

            //
            // pnlNavFooter
            //
            this.pnlNavFooter.Dock = DockStyle.Bottom;
            this.pnlNavFooter.Height = 68;
            this.pnlNavFooter.Padding = new Padding(20, 12, 20, 16);
            this.pnlNavFooter.SurfaceRole = LMaterialSurfaceRole.SurfaceContainerLow;
            this.pnlNavFooter.Controls.Add(this.btnLogout);
            this.pnlNavFooter.Name = "pnlNavFooter";

            this.btnLogout.Dock = DockStyle.Fill;
            this.btnLogout.Variant = LMaterialButtonVariant.Outlined;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);

            //
            // pnlMediaControllerHost (Issue #1 docks its persistent Media Controller here)
            //
            this.pnlMediaControllerHost.Dock = DockStyle.Bottom;
            this.pnlMediaControllerHost.Height = 64;
            this.pnlMediaControllerHost.SurfaceRole = LMaterialSurfaceRole.SurfaceContainerHigh;
            this.pnlMediaControllerHost.Name = "pnlMediaControllerHost";

            //
            // pnlContent
            //
            this.pnlContent.Dock = DockStyle.Fill;
            this.pnlContent.SurfaceRole = LMaterialSurfaceRole.Surface;
            this.pnlContent.Padding = new Padding(24);
            this.pnlContent.Controls.Add(this.lblContentTitle);
            this.pnlContent.Name = "pnlContent";

            this.lblContentTitle.Dock = DockStyle.Fill;
            this.lblContentTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblContentTitle.TypeRole = LMaterialTypeRole.HeadlineMedium;
            this.lblContentTitle.ColorRole = LMaterialColorRole.OnSurfaceVariant;
            this.lblContentTitle.Text = "Bhisakka Ayurvedic Clinic\r\nSelect an option from the menu to begin.";
            this.lblContentTitle.Name = "lblContentTitle";

            //
            // Dashboard
            //
            this.AutoScaleDimensions = new SizeF(8F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1100, 700);
            this.MinimumSize = new Size(900, 600);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlNav);
            this.Controls.Add(this.pnlMediaControllerHost);
            this.Name = "Dashboard";
            this.Text = "Bhisakka - Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);

            this.pnlContent.ResumeLayout(false);
            this.pnlNavHeader.ResumeLayout(false);
            this.pnlNavHeader.PerformLayout();
            this.pnlNavFooter.ResumeLayout(false);
            this.pnlNav.ResumeLayout(false);
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
