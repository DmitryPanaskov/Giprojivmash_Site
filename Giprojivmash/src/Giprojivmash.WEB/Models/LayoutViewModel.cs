using System.Collections.Generic;

namespace Giprojivmash.WEB.Models
{
    public class LayoutViewModel : BaseViewModel
    {
        public IList<string> ServicesMenu { get; internal set; }

        public string Telephone { get; set; }

        public string SubTelephone { get; set; }

        public string Fax { get; set; }

        public string SubFax { get; set; }

        public string Email { get; set; }

        public string SubEmail { get; set; }

        public string VK { get; set; }

        public string SubVK { get; set; }
    }
}
