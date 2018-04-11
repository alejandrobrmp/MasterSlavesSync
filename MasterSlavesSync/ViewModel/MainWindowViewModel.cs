using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSlavesSync.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {

        private TaskbarIcon _NotifyIcon;
        public TaskbarIcon TaskbarIcon
        {
            set
            {
                _NotifyIcon = value;
            }
        }



    }
}
