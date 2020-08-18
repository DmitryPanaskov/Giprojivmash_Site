using System.Collections.Generic;

namespace Giprojivmash.WEB.Models.Service
{
    public class ServicePageViewModel : LayoutViewModel
    {
        public ServiceFirstLayerViewModel CurrentServiceFirstLayer { get; internal set; }

        public IList<ServiceFirstLayerViewModel> ServiceFirstLayerList { get; internal set; }

        public IList<ServiceSecondLayerViewModel> ServiceSecondLayerList { get; internal set; }

        public IList<ServiceThirdLayerViewModel> ServiceThirdLayerList { get; internal set; }

        public IList<string> ActionNameList { get; internal set; }
    }
}
