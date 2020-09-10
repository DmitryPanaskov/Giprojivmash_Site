using AutoMapper;
using Giprojivmash.WEB.Models.Portfolio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Giprojivmash.WEB.Controllers
{
    public class PortfolioController : BaseController
    {
        public PortfolioController(ILogger<HomeController> logger, IMapper mapper)
            : base(logger, mapper)
        {
        }

        [HttpGet]
        [Route("/портфолио")]
        public IActionResult Portfolio()
        {
            var model = new PortfolioPageViewModel();
            model.PageTitle = "1";
            return View(model);
        }

        [HttpGet]
        [Route("/портфолио/кристалл")]
        public IActionResult Kristall()
        {
            var model = new PortfolioPageViewModel();
            model.PageTitle = "2";
            return View(model);
        }

        [HttpGet]
        [Route("/портфолио/хойники")]
        public IActionResult Hoiniki()
        {
            var model = new PortfolioPageViewModel();
            model.PageTitle = "3";
            return View(model);
        }

        [HttpGet]
        [Route("/портфолио/химзавод")]
        public IActionResult Himzavod()
        {
            var model = new PortfolioPageViewModel();
            model.PageTitle = "4";
            return View(model);
        }
    }
}
