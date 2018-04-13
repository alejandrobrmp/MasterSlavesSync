using Hardcodet.Wpf.TaskbarNotification;
using MasterSlavesSync.Services;
using MasterSlavesSync.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MasterSlavesSync
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TaskbarIcon taskbar;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            taskbar = ServiceHolder.GetService<TaskbarService>().NotifyIcon;
        }

        protected override void OnExit(ExitEventArgs e)
        {
            taskbar.Dispose();
            base.OnExit(e);
        }
    }
}
