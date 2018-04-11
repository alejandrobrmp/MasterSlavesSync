using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MasterSlavesSync.Views
{
    /// <summary>
    /// Lógica de interacción para SyncStatusWindow.xaml
    /// </summary>
    public partial class SyncStatusWindow : Window
    {
        private readonly float OFFSET = 20f;

        public SyncStatusWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var desktopWorkingArea = SystemParameters.WorkArea;
            Left = desktopWorkingArea.Right - Width - OFFSET;
            Top = desktopWorkingArea.Bottom - Height - OFFSET;
        }
    }
}
