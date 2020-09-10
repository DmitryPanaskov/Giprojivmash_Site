using System.Collections.Generic;

namespace Giprojivmash.WEB.Models.About
{
    public class BimPageViewModel : LayoutViewModel
    {
        public IList<SidebarLineViewModel> Sidebar { get; internal set; }
    }
}
