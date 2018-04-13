using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MasterSlavesSync.Models
{
    public interface IDialog<T>
    {
        DialogResponse<T> ShowDialog(DialogResponse<T> defaultResponse);
    }
}
