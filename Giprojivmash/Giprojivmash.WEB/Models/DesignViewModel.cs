using System.Collections.Generic;

namespace Giprojivmash.WEB.Models
{
    public class DesignViewModel
    {
        public ServiceFirstLayerViewModel ServiceFirstLayer { get; internal set; }

        public IList<ServiceSecondLayerViewModel> ServiceSecondLayerList { get; internal set; }

        public IList<ServiceThirdLayerViewModel> ServiceThirdLayerList { get; internal set; }
    }
}
