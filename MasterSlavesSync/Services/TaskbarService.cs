using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSlavesSync.Services
{
    public class TaskbarService : IService
    {
        public TaskbarIcon NotifyIcon { get; }

        public TaskbarService()
        {
            NotifyIcon = (TaskbarIcon)App.Current.FindResource("NotifyIcon");
        }
    }
}
