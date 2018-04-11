using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Resources;

namespace MasterSlavesSync.Services
{
    public interface IResourceHolder : IService
    {
        StreamResourceInfo GetResource(string path);
    }
}
