using System.Collections.Generic;
using Giprojivmash.DataModels.Enums;

namespace Giprojivmash.WEB.Models.Contact
{
    public class ContactPageViewModel : LayoutViewModel
    {
        public PositionType PositionType { get; set; }

        public IList<ContactViewModel> ContactList { get; internal set; }

        public IList<ContactDataViewModel> ContactDataList { get; internal set; }

        public IList<SidebarLineViewModel> Sidebar { get; internal set; }
    }
}
