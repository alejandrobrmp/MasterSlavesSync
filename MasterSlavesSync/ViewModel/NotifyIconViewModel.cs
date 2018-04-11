using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MasterSlavesSync.ViewModel
{
    public class NotifyIconViewModel : BaseViewModel
    {
        private string _ToolTipText = "alone";

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
            _DoubleClick = new RelayCommand(() => { App.Current.MainWindow.Visibility = System.Windows.Visibility.Visible; }, p => true);
        }

    }
}
