using System.Collections.Generic;

namespace Giprojivmash.WEB.Models.About
{
    public class VacancyPageViewModel : LayoutViewModel
    {
        public IList<VacancyViewModel> Vacancies { get; internal set; }

        public IList<SidebarLineViewModel> Sidebar { get; internal set; }
    }
}
