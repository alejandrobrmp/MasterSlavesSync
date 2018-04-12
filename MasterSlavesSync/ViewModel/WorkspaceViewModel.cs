using MasterSlavesSync.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MasterSlavesSync.ViewModel
{

    public class WorkspaceViewModel : BaseViewModel
    {

        public Workspace Workspace { get; }
        public List<Uri> Slaves => Workspace.Slaves;
        private WorkspaceFileManager workspaceFileManager;

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
            workspaceFileManager = new WorkspaceFileManager(Workspace);
            workspaceFileManager.ReportProgress += WorkspaceFileManager_ReportProgress;
        }

        private void WorkspaceFileManager_ReportProgress(FileAction action, int value)
        {
            
        }

        private void EvaluateIsSyncing()
        {
            IsSincyng =
                CopiesRemaining != 0 |
                DeletesRemaining != 0 |
                RenamesRemaining != 0 |
                UpdatesRemaining != 0;
        }

        private void Workspace_OnSlavesChanged(object sender)
        {
            OnPropertyChanged(nameof(Slaves));
        }
    }
}
