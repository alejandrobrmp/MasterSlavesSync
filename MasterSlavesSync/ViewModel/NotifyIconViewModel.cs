using MasterSlavesSync.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MasterSlavesSync.ViewModel
{
    public class NotifyIconViewModel : BaseViewModel
    {

        private readonly string STATUSWINDOWPATH = "@/../Views/SyncStatusWindow.xaml";

        private SyncStatusWindowViewModel _StatusWindow;

        private string _ToolTipText = "MasterSlavesSync";
        public string ToolTipText
        {
            get { return _ToolTipText; }
            set
            {
                _ToolTipText = value;
                OnPropertyChanged();
            }
        }

        private ICommand _DoubleClick;
        public ICommand DoubleClick => _DoubleClick;

        public NotifyIconViewModel()
        {
            _StatusWindow = (Application.LoadComponent(new Uri(STATUSWINDOWPATH, UriKind.Relative)) as SyncStatusWindow)
                .DataContext as SyncStatusWindowViewModel;
        }

    }
}
