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
            
        }

    }
}
