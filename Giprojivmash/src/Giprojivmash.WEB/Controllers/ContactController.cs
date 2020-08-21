using System.Collections.Generic;
using AutoMapper;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.WEB.Models;
using Giprojivmash.WEB.Models.Contact;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Giprojivmash.WEB.Controllers
{
    public class ContactController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactService _contactService;
        private readonly IContactDataService _contactDataService;
        private readonly IMapper _mapper;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out", Justification = "<>")]
        public ContactController(ILogger<HomeController> logger, IMapper mapper,
        IContactService contactService,
        IContactDataService contactDataService)
            : base(logger, mapper)
        {
            _mapper = mapper;
            _contactService = contactService;
            _contactDataService = contactDataService;
            _logger = logger;
        }

        [HttpGet]
        [Route("/kontakty/rukovodstvo")]
        public IActionResult Manager()
        {
            var model = new ContactPageViewModel();
            model.PageName = "Контакты";
            model.Sidebar = InitSidebar();
            return View(model);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<>")]
        private List<SidebarLineViewModel> InitSidebar()
        {
            var sidebar = new List<SidebarLineViewModel>
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
            return sidebar;
        }
    }
}
