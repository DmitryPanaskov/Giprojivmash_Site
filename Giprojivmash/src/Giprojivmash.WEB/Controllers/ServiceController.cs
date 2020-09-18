using System.Collections.Generic;
using AutoMapper;
using Giprojivmash.DataModels.Enums;
using Giprojivmash.WEB.Models;
using Giprojivmash.WEB.Models.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Giprojivmash.WEB.Controllers
{
    public class ServiceController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out", Justification = "<>")]
        public ServiceController(ILogger<HomeController> logger, IMapper mapper)
            : base(logger, mapper)
        {
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("/услуги/проектирование")]
        public IActionResult Design()
        {
            var model = new ServicePageViewModel();
            model.ServiceType = ServiceType.Design;
            model.PageTitle = "Оказание услуг по проектированию в Беларуси, РБ, Минск, Брест, Витебск, Гродно, Гомель, Могилев";
            model.PageKeyword = "проектирование, зданий, сооружений, кто делает, обоснование, услуги по проектированию, гомель, брест, витебск, гродно, гомель, минск, область, беларусь, рб";
            model.PageName = "Проектирование";
            model.PageDescription = "Проектная организация в Гомеле - ОАО Гипроживмаш предлагает услуги проектирования, разработку проектной документации, канализации, отопления, вентиляции";
            model.Sidebar = InitSidebar();
            return View("Service", model);
        }

        [HttpGet]
        [Route("/услуги/обоснование-инвестиций")]
        public IActionResult InvestmentJustification()
        {
            var model = new ServicePageViewModel();
            model.ServiceType = ServiceType.InvestmentJustification;
            model.PageTitle = "Оказание услуг по разработке обоснования инвестиций в Беларуси, РБ, Минск, Брест, Витебск, Гродно, Гомель, Могилев";
            model.PageKeyword = "обоснование инвестиций, кто делает, обоснование, услуги по обоснованию инвестиций, гомель, брест, витебск, гродно, гомель, минск, область, беларусь, рб";
            model.PageName = "Обоснование инвестиций";
            model.PageDescription = "ОАО Гипроживмаш предлагает услуги обоснования инвестиций в строительстве в Гомеле, разработка обоснований инвестиций это первый шаг к строительству";
            model.Sidebar = InitSidebar();
            return View("Service", model);
        }

        [HttpGet]
        [Route("/услуги/инженерно-геодезические-изыскания")]
        public IActionResult Geodesy()
        {
            var model = new ServicePageViewModel();
            model.ServiceType = ServiceType.Geodesy;
            model.PageTitle = "Оказание услуг по проведению инженерно-геодезических работ (изысканий) в Беларуси, РБ, Минск, Брест, Витебск, Гродно, Гомель, Могилев";
            model.PageName = "Инженерно-геодезические изыскания";
            model.PageKeyword = "инженерно-геодезические изыскания, кто делает, геодезия, сервис, услуги геодезии, гомель, брест, витебск, гродно, гомель, минск, область, беларусь, рб";
            model.PageDescription = "ОАО Гипроживмаш предлагает сервис и услуги по инженерно-геодезическим изысканиям, услуги геодезии в Гомеле";
            model.Sidebar = InitSidebar();
            return View("Service", model);
        }

        [HttpGet]
        [Route("/услуги/экологическое проектирование")]
        public IActionResult Ecology()
        {
            var model = new ServicePageViewModel();
            model.ServiceType = ServiceType.Ecology;
            model.PageTitle = "Оказание услуг по проведению инженерно-экологических работ (изысканий) в Беларуси, РБ, Минск, Брест, Витебск, Гродно, Гомель, Могилев";
            model.PageName = " экологическое проектирование";
            model.PageKeyword = " экологическое проектирование, экология, сервис, услуги экологии, гомель, брест, витебск, гродно, гомель, минск, область, беларусь, рб";
            model.PageDescription = "ОАО Гипроживмаш предлагает сервис и услуги по экологическому проектирование, услуги экологии в Гомеле";
            model.Sidebar = InitSidebar();
            return View("Service", model);
        }

        [HttpGet]
        [Route("/услуги/промышленная-безопасность")]
        public IActionResult IndustrialSafety()
        {
            var model = new ServicePageViewModel();
            model.ServiceType = ServiceType.IndustrialSafety;
            model.PageTitle = "Оказание услуг в области промышленной безопасности в Беларуси, РБ, Минск, Брест, Витебск, Гродно, Гомель, Могилев";
            model.PageName = "Промышленная безопасность";
            model.PageKeyword = "промышленная безопасность,кто делает,  услуги по промышленной безопасности, гомель, брест, витебск, гродно, гомель, минск, область, беларусь, рб";
            model.PageDescription = "ОАО Гипроживмаш предлагает услуги в сфере проектирования промышленной безопасности, проектирование опасного производства, радиционных объектов";
            model.Sidebar = InitSidebar();
            return View("Service", model);
        }

        [HttpGet]
        [Route("/услуги/системы-безопасности")]
        public IActionResult SystemSafefty()
        {
            var model = new ServicePageViewModel();
            model.ServiceType = ServiceType.SystemSafefty;
            model.PageTitle = "Оказание услуг по проектированию систем пожарабезопасности, системы охраны и безопасности в Беларуси, РБ, Минск, Брест, Витебск, Гродно, Гомель, Могилев";
            model.PageName = "Системы безопасности";
            model.PageKeyword = "системы безопасности,кто делает, услуги по системам безопасности, камеры, охрана объекта, сигнализация, извещатели," +
                " пожарная безопасность, план эвакуации, пожарные извещатели, гомель, брест, витебск, гродно, гомель, минск, область, беларусь, рб";
            model.PageDescription = "ОАО Гипроживмаш предлагает услуги в сфере проектирования систем безопасности, охрана объектов, заводов, пожарная охрана и безопасноть";
            model.Sidebar = InitSidebar();
            return View("Service", model);
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
                    SidebarName = "Экологическое проектирование",
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
