﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.WEB.Models.Enums;
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
        [Route("/uslugi/proektirovanie")]
        public IActionResult Design()
        {
            var model = InitializeServiceViewModel(ServiceType.Design);
            ViewData["Title"] = "Оказание услуг по проектированию в Беларуси, РБ, Минск, Брест, Витебск, Гродно, Гомель, Могилев";
            return View("Service", model);
        }

        [HttpGet]
        [Route("/uslugi/obosnovanie-investiciy")]
        public IActionResult InvestmentJustification()
        {
            var model = InitializeServiceViewModel(ServiceType.InvestmentJustification);
            ViewData["Title"] = "Оказание услуг по разработке обоснования инвестиций в Беларуси, РБ, Минск, Брест, Витебск, Гродно, Гомель, Могилев";
            return View("Service", model);
        }

        [HttpGet]
        [Route("/uslugi/inzhenerno-geodezicheskie-izyskaniya")]
        public IActionResult Geodesy()
        {
            var model = InitializeServiceViewModel(ServiceType.Geodesy);
            ViewData["Title"] = "Оказание услуг по проведению инженерно-геодезических работ (изысканий) в Беларуси, РБ, Минск, Брест, Витебск, Гродно, Гомель, Могилев";
            return View("Service", model);
        }

        [HttpGet]
        [Route("/uslugi/inzhenerno-ekologicheskie-izyskaniya")]
        public IActionResult Ecology()
        {
            var model = InitializeServiceViewModel(ServiceType.Ecology);
            ViewData["Title"] = "Оказание услуг по проведению инженерно-экологических работ (изысканий) в Беларуси, РБ, Минск, Брест, Витебск, Гродно, Гомель, Могилев";
            return View("Service", model);
        }

        [HttpGet]
        [Route("/uslugi/promyshlennaya-bezopasnost")]
        public IActionResult IndustrialSafety()
        {
            var model = InitializeServiceViewModel(ServiceType.IndustrialSafety);
            ViewData["Title"] = "Оказание услуг в области промышленной безопасности в Беларуси, РБ, Минск, Брест, Витебск, Гродно, Гомель, Могилев";
            return View("Service", model);
        }

        [HttpGet]
        [Route("/uslugi/sistemy-bezopasnosti")]
        public IActionResult SystemSafefty()
        {
            var model = InitializeServiceViewModel(ServiceType.SystemSafefty);
            ViewData["Title"] = "Оказание услуг по проектированию систем пожарабезопасности, системы охраны и безопасности в Беларуси, РБ, Минск, Брест, Витебск, Гродно, Гомель, Могилев";
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
            model.ServiceFirstLayerList = _mapper.Map<List<ServiceFirstLayerViewModel>>(serviceFirstLayerList);
            model.ServiceSecondLayerList = _mapper.Map<List<ServiceSecondLayerViewModel>>(serviceSecondLayerList);
            model.ServiceThirdLayerList = _mapper.Map<List<ServiceThirdLayerViewModel>>(serviceThirdLayerList);
            model.ActionNameList = new List<string> { "Design", "InvestmentJustification", "Geodesy", "Ecology", "IndustrialSafety", "SystemSafefty" };
            return model;
        }
    }
}
