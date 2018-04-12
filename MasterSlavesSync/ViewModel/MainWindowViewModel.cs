using Hardcodet.Wpf.TaskbarNotification;
using MasterSlavesSync.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSlavesSync.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {

        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        public ObservableCollection<WorkspaceViewModel> Workspaces => 
            _Workspaces ?? 
            (_Workspaces = new ObservableCollection<WorkspaceViewModel>(
                ServiceHolder.GetService<WorkspaceService>().Workspaces.Values));

    }
}
