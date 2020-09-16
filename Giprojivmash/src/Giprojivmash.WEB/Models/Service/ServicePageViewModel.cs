using System.Collections.Generic;
using Giprojivmash.DataModels.Enums;

namespace Giprojivmash.WEB.Models.Service
{
    public class ServicePageViewModel : LayoutViewModel
    {
        public string Title { get; set; }

        public IList<SidebarLineViewModel> Sidebar { get; internal set; }

        public ServiceType ServiceType { get; set; }
    }
}
