using System.Collections.Generic;

namespace Giprojivmash.WEB.Models
{
    public class ServiceViewModel : BaseViewModel
    {
        public IList<ServiceFirstLayerViewModel> ServiceFirstLayerList { get; internal set; }

        public IList<ServiceSecondLayerViewModel> ServiceSecondLayerList { get; internal set; }

        public IList<ServiceThirdLayerViewModel> ServiceThirdLayerList { get; internal set; }
    }
}
