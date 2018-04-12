using MasterSlavesSync.Models;
using MasterSlavesSync.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSlavesSync.Services
{
    public class WorkspaceService : IService
    {
        public Dictionary<Workspace, WorkspaceViewModel> Workspaces { get; private set; }

        public WorkspaceService()
        {
            List<Workspace> workspaces = ServiceHolder.GetService<JSONUtilsService>().Deserialize<List<Workspace>>(Workspace.FILE_PATH) ?? new List<Workspace>();

            foreach (var ws in workspaces)
            {
                ws.OnSlavesChanged += Workspace_OnSlavesChanged;
                WorkspaceViewModel vm = new WorkspaceViewModel(ws);
                Workspaces.Add(ws, vm);
            }

        }

        private void Workspace_OnSlavesChanged(object sender)
        {
            ServiceHolder.GetService<JSONUtilsService>().Serialize(Workspace.FILE_PATH, sender);
        }
    }
}
