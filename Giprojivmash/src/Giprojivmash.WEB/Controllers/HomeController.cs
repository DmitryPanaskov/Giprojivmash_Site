using System.Collections.Generic;
using System.Diagnostics;
using AutoMapper;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.WEB.Models;
using Giprojivmash.WEB.Models.Home;
using Giprojivmash.WEB.Models.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Giprojivmash.WEB.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IServiceFirstLayerService _serviceFirstLayerService;
        private readonly IServiceSecondLayerService _serviceSecondLayerService;
        private readonly IServiceThirdLayerService _serviceThirdLayerService;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out", Justification = "<>")]
        public HomeController(ILogger<HomeController> logger, IMapper mapper,
            IServiceFirstLayerService serviceFirstLayerService,
            IServiceSecondLayerService serviceSecondLayerService,
            IServiceThirdLayerService serviceThirdLayerService)
            : base(logger, mapper)
        {
            _serviceFirstLayerService = serviceFirstLayerService;
            _serviceSecondLayerService = serviceSecondLayerService;
            _serviceThirdLayerService = serviceThirdLayerService;
            _logger = logger;
            _mapper = mapper;
        }

        public LayoutViewModel LayoutViewModel { get; set; }

        public IActionResult Index()
        {
            var model = new IndexViewModel();
            var serviceFirstLayerList = _serviceFirstLayerService.GetAll();
            model.ServiceFirstLayerList = _mapper.Map<List<ServiceFirstLayerViewModel>>(serviceFirstLayerList);
            return View(model/*"Temp"*/);
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
