using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bhisakka.Audio
{
    public static class AmbianceService
    {
        private static AudioScheduler scheduler;
        private static NotifyIcon trayIcon;

        public static void Initialize()
        {
            if (scheduler != null)
            {
                return;
            }

            scheduler = new AudioScheduler();
            scheduler.Start();

            CreateTrayIcon();
        }

        internal static AudioScheduler GetScheduler()
        {
            return scheduler;
        }

        private static void CreateTrayIcon()
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            ToolStripMenuItem openItem = new ToolStripMenuItem("Open Dashboard");
            openItem.Click += OnOpenDashboardClick;
            menu.Items.Add(openItem);

            ToolStripMenuItem exitItem = new ToolStripMenuItem("Exit");
            exitItem.Click += OnExitClick;
            menu.Items.Add(exitItem);

            trayIcon = new NotifyIcon();
            trayIcon.Icon = SystemIcons.Application;
            trayIcon.Text = "Bhisakka Ambiance Scheduler";
            trayIcon.ContextMenuStrip = menu;
            trayIcon.Visible = true;
            trayIcon.DoubleClick += OnOpenDashboardClick;
        }

        private static void OnOpenDashboardClick(object sender, EventArgs e)
        {
            Util.WindowManager.GetInstance().Show<UI.Dashboard.Dashboard>();
        }

        private static void OnExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
