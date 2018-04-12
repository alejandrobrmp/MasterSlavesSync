using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MasterSlavesSync.Models
{
    public enum FileAction
    {
        Copy,
        Delete,
        Rename,
        Update
    }

    public class WorkspaceFileManager
    {
        public delegate void ChangeDetected(FileAction action);
        public event ChangeDetected OnChangeDetected;
        public delegate void Progress(FileAction action, int value);
        public event Progress ReportProgress;

        private readonly Workspace workspace;
        private readonly FileSystemWatcher watcher;
        private Thread CopyThread;
        private Queue<Uri> CopyQueue;
        private Thread DeleteThread;
        private Queue<Uri> DeleteQueue;
        private Thread RenameThread;
        private Queue<Uri> RenameQueue;
        private Thread UpdateThread;
        private Queue<Uri> UpdateQueue;

        public WorkspaceFileManager(
            Workspace workspace)
        {
            this.workspace = workspace;

            CopyThread = new Thread(CopyRun);
            DeleteThread = new Thread(DeleteRun);
            RenameThread = new Thread(RenameRun);
            UpdateThread = new Thread(UpdateRun);

            CopyThread.Start();
            DeleteThread.Start();
            RenameThread.Start();
            UpdateThread.Start();

            watcher = new FileSystemWatcher(
                this.workspace.Master.AbsolutePath,
                (NotifyFilters.LastAccess |
                NotifyFilters.LastWrite |
                NotifyFilters.FileName |
                NotifyFilters.DirectoryName).ToString());

            watcher.Created += FileChange;
            watcher.Deleted += FileChange;
            watcher.Renamed += FileChange;
            watcher.Changed += FileChange;
        }

        private void FileChange(object sender, FileSystemEventArgs e)
        {
            FileAction action;
            Uri file = new Uri(e.FullPath);
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Created:
                    CopyQueue.AddItem(file);
                    action = FileAction.Copy;
                    break;
                case WatcherChangeTypes.Deleted:
                    DeleteQueue.AddItem(file);
                    action = FileAction.Delete;
                    break;
                case WatcherChangeTypes.Changed:
                    UpdateQueue.AddItem(file);
                    action = FileAction.Update;
                    break;
                case WatcherChangeTypes.Renamed:
                    RenameQueue.AddItem(file);
                    action = FileAction.Rename;
                    break;
                case WatcherChangeTypes.All:
                default:
                    action = FileAction.Copy | FileAction.Delete | FileAction.Rename | FileAction.Update;
                    break;
            }
            OnChangeDetected?.Invoke(action);
        }

        private void CopyRun()
        {
            CopyQueue = new Queue<Uri>();
            CopyQueue.OnItemAdded += () =>
            {
                ReportProgress?.Invoke(FileAction.Copy, CopyQueue.Count);
                Uri nextFile;
                while ((nextFile = CopyQueue.GetNext()) != null)
                {
                    List<Uri> outputs = workspace.GetSlavesPaths(nextFile);
                    foreach (var file in outputs)
                    {
                        File.Copy(nextFile.AbsolutePath, file.AbsolutePath, true);
                    }
                    ReportProgress?.Invoke(FileAction.Copy, CopyQueue.Count);
                }
            };
        }

        private void DeleteRun()
        {

        }

        private void RenameRun()
        {

        }

        private void UpdateRun()
        {

        }

        public void Dispose()
        {
            CopyThread.Abort();
            DeleteThread.Abort();
            RenameThread.Abort();
            UpdateThread.Abort();
        }

    }
}
