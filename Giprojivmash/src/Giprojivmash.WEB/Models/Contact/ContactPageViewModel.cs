using System.Collections.Generic;

namespace Giprojivmash.WEB.Models.Contact
{
    public class ContactPageViewModel
    {
        public ContactViewModel ContactViewModel { get; set; }

        public ContactDataViewModel ContactDataViewModel { get; set; }

        public IList<string> ContactMenuList { get; internal set; }

        public IList<string> ActionNameList { get; internal set; }
    }
}
