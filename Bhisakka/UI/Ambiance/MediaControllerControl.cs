using Bhisakka.Audio;
using Bhisakka.DataAccess;
using Bhisakka.Models;
using MaterialComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bhisakka.UI.Ambiance
{
    public partial class MediaControllerControl : UserControl
    {
        public MediaControllerControl()
        {
            InitializeComponent();
            this.Load += MediaControllerControl_Load;

            LMaterialTheme.Register(this, delegate
            {
                this.BackColor = LMaterialTheme.Scheme.SurfaceContainerHigh;
                this.ForeColor = LMaterialTheme.Scheme.OnSurface;
            });
        }

        private void MediaControllerControl_Load(object sender, EventArgs e)
        {
            LoadAnnouncements();
            RefreshStatus();
        }

        private void LoadAnnouncements()
        {
            cmbAnnouncements.Items.Clear();

            try
            {
                AudioScheduleRepository repository = new AudioScheduleRepository();
                List<AudioSchedule> announcements = repository.GetManualAnnouncements();

                for (int i = 0; i < announcements.Count; i++)
                {
                    cmbAnnouncements.Items.Add(announcements[i]);
                }

                if (cmbAnnouncements.Items.Count > 0)
                {
                    cmbAnnouncements.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to load announcements: " + ex.Message;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            AudioScheduler scheduler = AmbianceService.GetScheduler();
            if (scheduler == null)
            {
                ShowNotReadyMessage();
                return;
            }

            scheduler.ResumePlayback();
            RefreshStatus();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            AudioScheduler scheduler = AmbianceService.GetScheduler();
            if (scheduler == null)
            {
                ShowNotReadyMessage();
                return;
            }

            scheduler.PausePlayback();
            RefreshStatus();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            AudioScheduler scheduler = AmbianceService.GetScheduler();
            if (scheduler == null)
            {
                ShowNotReadyMessage();
                return;
            }

            scheduler.StopPlayback();
            RefreshStatus();
        }

        private void btnPlayAnnouncement_Click(object sender, EventArgs e)
        {
            AudioScheduler scheduler = AmbianceService.GetScheduler();
            if (scheduler == null)
            {
                ShowNotReadyMessage();
                return;
            }

            AudioSchedule selected = cmbAnnouncements.SelectedItem as AudioSchedule;
            if (selected == null)
            {
                lblStatus.Text = "No announcement selected.";
                return;
            }

            scheduler.PlayAnnouncement(selected);
            RefreshStatus();
        }

        private void RefreshStatus()
        {
            AudioScheduler scheduler = AmbianceService.GetScheduler();
            if (scheduler == null)
            {
                lblStatus.Text = "Ambiance service not started.";
                return;
            }

            if (scheduler.IsPlaying())
            {
                AudioSchedule current = scheduler.GetCurrentTrack();
                if (current != null)
                {
                    lblStatus.Text = "Playing: " + current.GetTrackName();
                }
                else
                {
                    lblStatus.Text = "Playing";
                }
            }
            else
            {
                lblStatus.Text = "Idle";
            }
        }

        private void ShowNotReadyMessage()
        {
            lblStatus.Text = "Ambiance service not started.";
            LMaterialDialog.Show(this.FindForm(), "Media Controller", "The ambiance scheduler has not been initialized yet.");
        }
    }
}
