using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Resources;

namespace MasterSlavesSync.Services
{
    public class ResourceHolder : IResourceHolder
    {
        private readonly string URI_BASE = "pack://application:,,,/";

        public StreamResourceInfo GetResource(string path)
        {
            if (path.StartsWith("/")) path = path.Remove(0, 1);

            StreamResourceInfo stream = Application.GetResourceStream(new Uri(URI_BASE + path));

            return stream;
        }
    }
}
