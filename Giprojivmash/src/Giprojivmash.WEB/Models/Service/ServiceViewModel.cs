using System.Collections.Generic;

namespace Giprojivmash.WEB.Models.Service
{
    public class ServiceViewModel : LayoutViewModel
    {
        public ServiceFirstLayerViewModel CurrentServiceFirstLayer { get; internal set; }

        public IList<ServiceSecondLayerViewModel> ServiceSecondLayerList { get; internal set; }

        public IList<ServiceThirdLayer> ServiceThirdLayerList { get; internal set; }

        public List<SidebarLineViewModel> Sidebar { get; } = new List<SidebarLineViewModel>
        {
            new SidebarLineViewModel
            {
                SidebarAction = "Design",
                SidebarName = "Проектирование",
            },
            new SidebarLineViewModel
            {
                SidebarAction = "InvestmentJustification",
                SidebarName = "Обоснование инвестиций",
            },
            new SidebarLineViewModel
            {
                SidebarAction = "Geodesy",
                SidebarName = "Инженерно-геодезические изыскания",
            },
            new SidebarLineViewModel
            {
                SidebarAction = "Ecology",
                SidebarName = "Инженерно-экологические изыскания",
            },
            new SidebarLineViewModel
            {
                SidebarAction = "IndustrialSafety",
                SidebarName = "Промышленная безопасность",
            },
            new SidebarLineViewModel
            {
                SidebarAction = "SystemSafefty",
                SidebarName = "Системы безопасности",
            },
        };
    }
}
