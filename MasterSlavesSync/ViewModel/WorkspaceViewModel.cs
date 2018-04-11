using MasterSlavesSync.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSlavesSync.ViewModel
{

    public enum FileAction
    {
        Copy,
        Delete,
        Rename,
        Update
    }

    public class WorkspaceViewModel : BaseViewModel
    {
        private Dictionary<FileAction, Models.Queue<Uri>> queues = new Dictionary<FileAction, Models.Queue<Uri>>();

        private readonly FileSystemWatcher watcher;
        public Workspace Workspace { get; }

        private int _CopiesRemaining;
        public int CopiesRemaining
        {
            get { return _CopiesRemaining; }
            set
            {
                _CopiesRemaining = value;
                OnPropertyChanged();
                EvaluateIsSyncing();
            }
        }

        private int _DeletesRemaining;
        public int DeletesRemaining
        {
            get { return _DeletesRemaining; }
            set
            {
                _DeletesRemaining = value;
                OnPropertyChanged();
                EvaluateIsSyncing();
            }
        }

        private int _RenamesRemainingRemaining;
        public int RenamesRemaining
        {
            get { return _RenamesRemainingRemaining; }
            set
            {
                _RenamesRemainingRemaining = value;
                OnPropertyChanged();
                EvaluateIsSyncing();
            }
        }

        private int _UpdatesRemainingRemaining;
        public int UpdatesRemaining
        {
            get { return _UpdatesRemainingRemaining; }
            set
            {
                _UpdatesRemainingRemaining = value;
                OnPropertyChanged();
                EvaluateIsSyncing();
            }
        }

        private bool _IsSincyng;
        public bool IsSincyng
        {
            get
            {
                return _IsSincyng;
            }
            set
            {
                _IsSincyng = value;
                OnPropertyChanged();
            }
        }

        public WorkspaceViewModel(Workspace workspace)
        {
            Workspace = workspace;
            Workspace.OnSlavesChanged += Workspace_OnSlavesChanged;

            GenerateQueues();

            watcher = new FileSystemWatcher(
                Workspace.Master.AbsolutePath, 
                (NotifyFilters.LastAccess | 
                NotifyFilters.LastWrite | 
                NotifyFilters.FileName |
                NotifyFilters.DirectoryName).ToString());

            watcher.Created += Watcher_FileChange;
            watcher.Deleted += Watcher_FileChange;
            watcher.Renamed += Watcher_FileChange;
            watcher.Changed += Watcher_FileChange;

        }

        private void GenerateQueues()
        {
            Models.Queue<Uri> copyQueue = new Models.Queue<Uri>();
            copyQueue.OnItemAdded += CopyQueue_OnItemAdded;
            Models.Queue<Uri> deleteQueue = new Models.Queue<Uri>();
            deleteQueue.OnItemAdded += DeleteQueue_OnItemAdded;
            Models.Queue<Uri> renameQueue = new Models.Queue<Uri>();
            renameQueue.OnItemAdded += RenameQueue_OnItemAdded;
            Models.Queue<Uri> updateQueue = new Models.Queue<Uri>();
            updateQueue.OnItemAdded += UpdateQueue_OnItemAdded;

            queues.Add(FileAction.Copy, copyQueue);
            queues.Add(FileAction.Delete, deleteQueue);
            queues.Add(FileAction.Rename, renameQueue);
            queues.Add(FileAction.Update, updateQueue);
        }

        private void EvaluateIsSyncing()
        {
            IsSincyng =
                CopiesRemaining != 0 |
                DeletesRemaining != 0 |
                RenamesRemaining != 0 |
                UpdatesRemaining != 0;
        }

        private void CopyQueue_OnItemAdded()
        {
            Uri file;
            while ((file = queues[FileAction.Copy].GetNext()) != null)
            {
                List<Uri> slaves = Workspace.GetSlavesPaths(file);
                foreach (var item in slaves)
                {

                }
            }
        }

        private void DeleteQueue_OnItemAdded()
        {
            
        }

        private void RenameQueue_OnItemAdded()
        {

        }

        private void UpdateQueue_OnItemAdded()
        {

        }

        private void Watcher_FileChange(object sender, FileSystemEventArgs e)
        {
            Uri uri = new Uri(e.FullPath);

            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Created:
                    break;
                case WatcherChangeTypes.Deleted:
                    break;
                case WatcherChangeTypes.Changed:
                    break;
                case WatcherChangeTypes.Renamed:
                    break;
                case WatcherChangeTypes.All:
                    break;
                default:
                    break;
            }

        }

        private void Workspace_OnSlavesChanged()
        {
            
        }
    }
}
