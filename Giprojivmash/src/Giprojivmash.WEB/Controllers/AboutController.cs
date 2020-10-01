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
            model.PageTitle = "О нас";
            model.PageKeyword = "чем занимается гипроживмаш, лучший проектный институт в РБ, Гомель, проектный институт";
            model.PageDescription = "ОАО Гипроживмаш - это первый проектный институт в Гомеле, в Беларуси, мы занимаеся разработкой проектной документации";
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
            model.PageKeyword = "вакансии, проектный институт ОАО Гипроживмаш";
            model.PageDescription = "Актуальные вакансии ОАО Гипроживмаш, работа в ОАО Гипроживмаш, зарплата в ОАО Гипроживмаш, требуются сотрудники ОАО Гипроживмаш";
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
            model.PageDescription = "Акционерное общество Гипроживмаш, документы для акционерво, информация для акционеров ОАО Гипроживмаш, баланс, прибыль и убытки Гипроживмаш";
            model.Sidebar = InitSidebar();
            return View(model);
        }

        [HttpGet]
        [Route("/bim-технология")]
        public IActionResult Bim()
        {
            var model = new BimPageViewModel();
            model.PageName = "BIM технология";
            model.PageTitle = "BIM (информационное моделирование объектов)";
            model.PageKeyword = "BIM, информационное моделирование объектов, гомель, беларусь, технология будущего, разработка BIM";
            model.PageDescription = "BIM (информационное моделирование объектов) в Гомеле как технология будущего которая" +
                " имеет ряд преимуществ, которые позвояляют экономить на проетировании и строительстве";
            model.Sidebar = InitSidebar();
            return View(model);
        }

        [HttpGet]
        [Route("/история")]
        public IActionResult History()
        {
            var model = new HistoryPageViewModel();
            model.PageName = "История";
            model.PageTitle = "История и летопись";
            model.PageKeyword = "история,старое здание, Гипроживмаш на Ленина, Гипросельмаш";
            model.PageDescription = "Самый лучший, самый надежный и самый старый проектный институт в Гомеле и" +
                " в Республике Беларусь прозднует свое 50-летие, на странице история и летопись нашего предприятия";
            model.Sidebar = InitSidebar();
            return View(model);
        }

        [HttpGet]
        [Route("/лицензии-и-сертификаты")]
        public IActionResult Certificate()
        {
            var model = new CertificatePageViewModel();
            model.PageName = "Лицензии и сертификаты";
            model.PageTitle = "Лицензии и сертификаты ОАО Гипроживмаш, сертификат качества, сертификат соответствия, разрешение на выполнение услуг";
            model.PageKeyword = "лицензия и сертификаты, допуск, разрешение, аттестат, проектирование, РБ, Гомель";
            model.PageDescription = "Лецензии и сертификаты разврешения на работу и допуски к работам ОАО Гипроживмаш";
            model.Sidebar = InitSidebar();
            return View(model);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<>")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out", Justification = "<>")]
        private List<SidebarLineViewModel> InitSidebar()
        {
            var sidebar = new List<SidebarLineViewModel>
            {
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
                    SidebarName = "Лицензии и сертификаты",
                },
                new SidebarLineViewModel
                {
                    SidebarAction = "Bim",
                    SidebarName = "BIM технология",
                },
                new SidebarLineViewModel
                {
                    SidebarAction = "Shareholder",
                    SidebarName = "Акционерам",
                },
                new SidebarLineViewModel
                {
                    SidebarAction = "Vacancy",
                    SidebarName = "Вакансии",
                },
            };
            return sidebar;
        }
    }
}
