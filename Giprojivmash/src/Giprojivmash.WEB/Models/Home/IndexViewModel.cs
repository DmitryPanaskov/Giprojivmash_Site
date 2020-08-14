using System.Collections.Generic;
using Giprojivmash.WEB.Models.Service;

namespace Giprojivmash.WEB.Models.Home
{
    public class IndexViewModel : LayoutViewModel
    {
        public IList<ServiceFirstLayerViewModel> ServiceFirstLayerList { get; internal set; }
    }
}