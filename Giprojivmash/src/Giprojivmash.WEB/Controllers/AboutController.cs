using System.Collections.Generic;
using AutoMapper;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.WEB.Models;
using Giprojivmash.WEB.Models.About;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Giprojivmash.WEB.Controllers
{
    public class AboutController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVacancyService _vacancyService;
        private readonly IMapper _mapper;

        public AboutController(ILogger<HomeController> logger, IMapper mapper, IVacancyService vacancyService)
            : base(logger, mapper)
        {
            _vacancyService = vacancyService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/о-нас")]
        public IActionResult About()
        {
            var model = new AboutPageViewModel();
            model.PageName = "О нас";
            model.PageTitle = "";
            model.Sidebar = InitSidebar();
            return View(model);
        }

        [HttpGet]
        [Route("/вакансии")]
        public IActionResult Vacancy()
        {
            var model = new VacancyPageViewModel();
            model.PageName = "Вакансии";
            model.PageTitle = "Вакансии, работа";
            model.Sidebar = InitSidebar();
            return View(model);
        }

        [HttpGet]
        [Route("/акционерам")]
        public IActionResult Shareholder()
        {
            var model = new ShareholderPageViewModel();
            model.PageName = "Акционерам";
            model.PageTitle = "Информация акционерам";
            model.Sidebar = InitSidebar();
            return View(model);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<>")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out", Justification = "<>")]
        private List<SidebarLineViewModel> InitSidebar()
        {
            var sidebar = new List<SidebarLineViewModel>
            {
                /*
                new SidebarLineViewModel
                {
                    SidebarAction = "About",
                    SidebarName = "О нас",
                },
                new SidebarLineViewModel
                {
                    SidebarAction = "History",
                    SidebarName = "История",
                },
                new SidebarLineViewModel
                {
                    SidebarAction = "Certificate",
                    SidebarName = "Сертификаты",
                },
                */
                new SidebarLineViewModel
                {
                    SidebarAction = "Shareholder",
                    SidebarName = "Акционерам",
                },
                /*
                new SidebarLineViewModel
                {
                    SidebarAction = "Vacancy",
                    SidebarName = "Выкансии",
                },
                */
            };
            return sidebar;
        }
    }
}
