using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSlavesSync.Models
{
    public static class UriExtensions
    {
        public static Uri GetRelativeToWithSameNode(this Uri uri, Uri uri2)
        {
            string sameNode = uri2.Segments.LastOrDefault();
            int sameNodeIndex = Array.FindIndex(uri.Segments, s => s.Equals(sameNode));

            string newUri = "";

            for (int i = 1; i < uri.Segments.Length - sameNodeIndex + 1; i++)
            {
                newUri += "\\" + uri.Segments[i + sameNodeIndex];
            }

            return new Uri(newUri, UriKind.Relative);
        }
    }

    public class Workspace
    {

        public delegate void SlavesChanged();
        public event SlavesChanged OnSlavesChanged;

        public Uri Master { get; set; }
        public List<Uri> Slaves { get; private set; }

        public Workspace(Uri master)
        {
            if (!master.IsAbsoluteUri) throw new Exception("Not an absolute Uri.");
            Master = master;
        }

        public void AddSlave(Uri slave)
        {
            if (!slave.IsAbsoluteUri) throw new Exception("Not an absolute Uri.");
            if (!slave.Segments.LastOrDefault().Equals(Master.Segments.LastOrDefault()))
                throw new Exception("Folder should be the same.");

            Slaves.Add(slave);

            OnSlavesChanged?.Invoke();
        }

        public List<Uri> GetSlavesPaths(Uri file)
        {
            List<Uri> uris = new List<Uri>();
            foreach (var item in Slaves)
            {
                uris.Add(file.GetRelativeToWithSameNode(item));
            }
            return uris;
        }

    }
}
