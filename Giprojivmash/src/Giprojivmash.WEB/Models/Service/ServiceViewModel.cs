using System.Collections.Generic;

namespace Giprojivmash.WEB.Models.Service
{
    public class ServiceViewModel : LayoutViewModel
    {
        public ServiceFirstLayerViewModel CurrentServiceFirstLayer { get; internal set; }

        public IList<ServiceSecondLayerViewModel> ServiceSecondLayerList { get; internal set; }

        public IList<ServiceThirdLayer> ServiceThirdLayerList { get; internal set; }

        public IList<SidebarLineViewModel> Sidebar { get;  internal set; }
    }
}
