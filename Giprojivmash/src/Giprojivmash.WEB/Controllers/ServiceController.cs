using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Giprojivmash.BLL.Interfaces;
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
        private readonly IServiceFirstLayerService _serviceFirstLayerService;
        private readonly IServiceSecondLayerService _serviceSecondLayerService;
        private readonly IServiceThirdLayerService _serviceThirdLayerService;
        private readonly IMapper _mapper;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out", Justification = "<>")]
        public ServiceController(ILogger<HomeController> logger, IMapper mapper,
        IServiceFirstLayerService serviceFirstLayerService,
        IServiceSecondLayerService serviceSecondLayerService,
        IServiceThirdLayerService serviceThirdLayerService)
            : base(logger, mapper)
        {
            _mapper = mapper;
            _serviceFirstLayerService = serviceFirstLayerService;
            _serviceSecondLayerService = serviceSecondLayerService;
            _serviceThirdLayerService = serviceThirdLayerService;
            _logger = logger;
        }

        [HttpGet]
        [Route("/услуги/проектирование")]
        public IActionResult Design()
        {
            var model = InitializeServiceViewModel(ServiceType.Design);
            model.PageTitle = "Оказание услуг по проектированию в Беларуси, РБ, Минск, Брест, Витебск, Гродно, Гомель, Могилев";
            model.PageName = "Проектирование";
            return View("Service", model);
        }

        [HttpGet]
        [Route("/услуги/обоснование-инвестиций")]
        public IActionResult InvestmentJustification()
        {
            var model = InitializeServiceViewModel(ServiceType.InvestmentJustification);
            model.PageTitle = "Оказание услуг по разработке обоснования инвестиций в Беларуси, РБ, Минск, Брест, Витебск, Гродно, Гомель, Могилев";
            model.PageName = "Обоснование инвестиций";
            return View("Service", model);
        }

        [HttpGet]
        [Route("/услуги/инженерно-геодезические-изыскания")]
        public IActionResult Geodesy()
        {
            var model = InitializeServiceViewModel(ServiceType.Geodesy);
            model.PageTitle = "Оказание услуг по проведению инженерно-геодезических работ (изысканий) в Беларуси, РБ, Минск, Брест, Витебск, Гродно, Гомель, Могилев";
            model.PageName = "Инженерно-геодезические изыскания";
            return View("Service", model);
        }

        [HttpGet]
        [Route("/услуги/инженерно-экологические-изыскания")]
        public IActionResult Ecology()
        {
            var model = InitializeServiceViewModel(ServiceType.Ecology);
            model.PageTitle = "Оказание услуг по проведению инженерно-экологических работ (изысканий) в Беларуси, РБ, Минск, Брест, Витебск, Гродно, Гомель, Могилев";
            model.PageName = "Инженерно-экологические изыскания";
            return View("Service", model);
        }

        [HttpGet]
        [Route("/услуги/промышленная-безопасность")]
        public IActionResult IndustrialSafety()
        {
            var model = InitializeServiceViewModel(ServiceType.IndustrialSafety);
            model.PageTitle = "Оказание услуг в области промышленной безопасности в Беларуси, РБ, Минск, Брест, Витебск, Гродно, Гомель, Могилев";
            model.PageName = "Промышленная безопасность";
            return View("Service", model);
        }

        [HttpGet]
        [Route("/услуги/системы-безопасности")]
        public IActionResult SystemSafefty()
        {
            var model = InitializeServiceViewModel(ServiceType.SystemSafefty);
            model.PageTitle = "Оказание услуг по проектированию систем пожарабезопасности, системы охраны и безопасности в Беларуси, РБ, Минск, Брест, Витебск, Гродно, Гомель, Могилев";
            model.PageName = "Системы безопасности";
            return View("Service", model);
        }

        private ServicePageViewModel InitializeServiceViewModel(ServiceType service)
        {
            var model = new ServicePageViewModel();
            var serviceFirstLayerList = _serviceFirstLayerService.GetAll();
            var serviceSecondLayerList = _serviceSecondLayerService.GetAll();
            var serviceThirdLayerList = _serviceThirdLayerService.GetAll();
            var currentFirstService = serviceFirstLayerList.ElementAt((int)service);

            model.CurrentServiceFirstLayer = _mapper.Map<ServiceFirstLayerViewModel>(currentFirstService);
            model.ServiceSecondLayerList = _mapper.Map<List<ServiceSecondLayerViewModel>>(serviceSecondLayerList);
            model.ServiceThirdLayerList = _mapper.Map<List<ServiceThirdLayer>>(serviceThirdLayerList);
            model.Sidebar = InitSidebar();
            return model;
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
