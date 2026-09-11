using System.Drawing;
using System.Windows.Forms;

namespace Bhisakka.UI.Ambiance
{
    partial class MediaControllerControl
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            btnPlay = new MaterialComponents.LMaterialButton();
            btnPause = new MaterialComponents.LMaterialButton();
            btnStop = new MaterialComponents.LMaterialButton();
            lblStatus = new MaterialComponents.LMaterialLabel();
            cmbAnnouncements = new MaterialComponents.LMaterialComboBox();
            btnPlayAnnouncement = new MaterialComponents.LMaterialButton();
            SuspendLayout();
            //
            // btnPlay
            //
            btnPlay.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnPlay.Variant = MaterialComponents.LMaterialButtonVariant.Tonal;
            btnPlay.Location = new Point(8, 12);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(88, 40);
            btnPlay.TabIndex = 0;
            btnPlay.Text = "Play";
            btnPlay.Click += btnPlay_Click;
            //
            // btnPause
            //
            btnPause.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnPause.Variant = MaterialComponents.LMaterialButtonVariant.Tonal;
            btnPause.Location = new Point(100, 12);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(88, 40);
            btnPause.TabIndex = 1;
            btnPause.Text = "Pause";
            btnPause.Click += btnPause_Click;
            //
            // btnStop
            //
            btnStop.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnStop.Variant = MaterialComponents.LMaterialButtonVariant.Tonal;
            btnStop.Location = new Point(192, 12);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(88, 40);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.Click += btnStop_Click;
            //
            // lblStatus (stretches to fill the space between transport and announcements)
            //
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.AutoSize = false;
            lblStatus.ColorRole = MaterialComponents.LMaterialColorRole.OnSurfaceVariant;
            lblStatus.Location = new Point(296, 12);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(246, 40);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Idle";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            //
            // cmbAnnouncements (pinned to the right)
            //
            cmbAnnouncements.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbAnnouncements.Location = new Point(554, 12);
            cmbAnnouncements.Name = "cmbAnnouncements";
            cmbAnnouncements.Size = new Size(210, 40);
            cmbAnnouncements.TabIndex = 4;
            //
            // btnPlayAnnouncement (pinned to the right)
            //
            btnPlayAnnouncement.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPlayAnnouncement.Location = new Point(772, 12);
            btnPlayAnnouncement.Name = "btnPlayAnnouncement";
            btnPlayAnnouncement.Size = new Size(120, 40);
            btnPlayAnnouncement.TabIndex = 5;
            btnPlayAnnouncement.Text = "Announce";
            btnPlayAnnouncement.Click += btnPlayAnnouncement_Click;
            //
            // MediaControllerControl
            //
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnPlay);
            Controls.Add(btnPause);
            Controls.Add(btnStop);
            Controls.Add(lblStatus);
            Controls.Add(cmbAnnouncements);
            Controls.Add(btnPlayAnnouncement);
            Name = "MediaControllerControl";
            Size = new Size(900, 64);
            MinimumSize = new Size(420, 64);
            ResumeLayout(false);
        }

        #endregion

        private MaterialComponents.LMaterialButton btnPlay;
        private MaterialComponents.LMaterialButton btnPause;
        private MaterialComponents.LMaterialButton btnStop;
        private MaterialComponents.LMaterialLabel lblStatus;
        private MaterialComponents.LMaterialComboBox cmbAnnouncements;
        private MaterialComponents.LMaterialButton btnPlayAnnouncement;
    }
}
