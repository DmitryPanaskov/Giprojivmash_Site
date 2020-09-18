using System.Collections.Generic;

namespace Giprojivmash.WEB.Models.About
{
    public class AboutPageViewModel : LayoutViewModel
    {
        public IList<SidebarLineViewModel> Sidebar { get; internal set; }
    }
}
