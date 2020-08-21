using System.Collections.Generic;

namespace Giprojivmash.WEB.Models.Contact
{
    public class ContactPageViewModel : LayoutViewModel
    {
        public IList<ContactViewModel> ContactList { get; internal set; }

        public IList<ContactDataViewModel> ContactDataList { get; internal set; }

        public IList<SidebarLineViewModel> Sidebar { get; internal set; }
    }
}
