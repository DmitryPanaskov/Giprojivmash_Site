using System.Collections.Generic;

namespace Giprojivmash.WEB.Models.Contact
{
    public class GeneralContactPageViewModel : LayoutViewModel
    {
        public ContactViewModel Contact { get; internal set; }

        public IList<ContactDataViewModel> ContactDataList { get; internal set; }

        public IList<SidebarLineViewModel> Sidebar { get; internal set; }
    }
}
