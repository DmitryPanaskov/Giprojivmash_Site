using System.Diagnostics;
using AutoMapper;
using Giprojivmash.WEB.Models;
using Giprojivmash.WEB.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Giprojivmash.WEB.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out", Justification = "<>")]
        public HomeController(ILogger<HomeController> logger, IMapper mapper)
            : base(logger, mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public LayoutViewModel LayoutViewModel { get; set; }

        public IActionResult Index()
        {
            var model = new IndexViewModel();
            model.PageTitle = "Проектный институ в Гомеле";
            model.PageName = "ОАО Гипроживмаш";
            model.PageKeyword = "Самый лучший, надежный, специалисты, проектный институт, " +
                "Гомель, Беларуси, РБ, проектирование, разработка строительной документации, гиприк, геодезия, экология, сметная";
            model.PageDescription = "Лучший проектный институт в РБ находится в Гомеле -" +
                " ОАО Гипроживмаш занимаемя проектирование, сметной документации, обоснованием инвестиций, геодезий, экологией, безопасностью";
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
