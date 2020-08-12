using System.Collections.Generic;
using System.Diagnostics;
using AutoMapper;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Giprojivmash.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceFirstLayerService _serviceFirstLayerService;
        private readonly IServiceSecondLayerService _serviceSecondLayerService;
        private readonly IServiceThirdLayerService _serviceThirdLayerService;
        private readonly IMapper _mapper;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out", Justification = "<>")]
        public HomeController(ILogger<HomeController> logger, IMapper mapper,
        IServiceFirstLayerService serviceFirstLayerService,
        IServiceSecondLayerService serviceSecondLayerService,
        IServiceThirdLayerService serviceThirdLayerService)
        {
            _mapper = mapper;
            _serviceFirstLayerService = serviceFirstLayerService;
            _serviceSecondLayerService = serviceSecondLayerService;
            _serviceThirdLayerService = serviceThirdLayerService;
            _logger = logger;
        }

        public LayoutViewModel LayoutViewModel { get; set; }

        public IActionResult Index()
        {
            return View(/*"Temp"*/);
        }

        [HttpGet]
        public IActionResult Design()
        {
            var model = new ServiceViewModel();
            var serviceFirstLayerList = _serviceFirstLayerService.GetAll();
            var serviceSecondLayerList = _serviceSecondLayerService.GetAll();
            var serviceThirdLayerList = _serviceThirdLayerService.GetAll();

            model.ServiceFirstLayerList = _mapper.Map<List<ServiceFirstLayerViewModel>>(serviceFirstLayerList);
            model.ServiceSecondLayerList = _mapper.Map<List<ServiceSecondLayerViewModel>>(serviceSecondLayerList);
            model.ServiceThirdLayerList = _mapper.Map<List<ServiceThirdLayerViewModel>>(serviceThirdLayerList);
            return View(model);
        }

        [HttpGet]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S4144:Methods should not have identical implementations", Justification = "<>")]
        public IActionResult Services()
        {
            var model = new ServiceViewModel();
            var serviceFirstLayerList = _serviceFirstLayerService.GetAll();
            var serviceSecondLayerList = _serviceSecondLayerService.GetAll();
            var serviceThirdLayerList = _serviceThirdLayerService.GetAll();

            model.ServiceFirstLayerList = _mapper.Map<List<ServiceFirstLayerViewModel>>(serviceFirstLayerList);
            model.ServiceSecondLayerList = _mapper.Map<List<ServiceSecondLayerViewModel>>(serviceSecondLayerList);
            model.ServiceThirdLayerList = _mapper.Map<List<ServiceThirdLayerViewModel>>(serviceThirdLayerList);
            return View(model);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out", Justification = "<>")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
