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
            model.PageTitle = "Портфолио";
            model.PageKeyword = "посмотреть, проектирование, увидеть, портфолио, работы, реконструкция, модернизация, улучшение, портфолио гипроживмаш, работы гипроживмаш";
            model.PageName = "Портфолио";
            model.PageDescription = "Портфолио ОАО Гипроживмаш, услуги и работы выполненные проектным институтом, в Гомеле, Беларуси";
            return View(model);
        }

        [HttpGet]
        [Route("/портфолио/возведение-и-реконструкция-кристалл-холдинг")]
        public IActionResult Kristall()
        {
            var model = new PortfolioPageViewModel();
            model.PageTitle = "Возведение и реконструкция КРИСТАЛЛ-ХОЛДИНГ";
            model.PageKeyword = "возведение, реконструкция, модернизация, кристалл-холдинг, гомель, кристалл, холдинг,";
            model.PageName = "Возведение и реконструкция КРИСТАЛЛ-ХОЛДИНГ";
            model.PageDescription = "ОАО Гипроживмаш выполнял услуги и работы по возведению и реконструкции КРИСТАЛЛ-ХОЛДИНГ";
            return View(model);
        }

        [HttpGet]
        [Route("/портфолио/модернизация-хойникский-завод-жби")]
        public IActionResult Hoiniki()
        {
            var model = new PortfolioPageViewModel();
            model.PageTitle = "Модернизация Хойникский завод ЖБИ";
            model.PageKeyword = "модернизация, улучшение, завод, жби, хойники";
            model.PageName = "Модернизация Хойникский завод ЖБИ";
            model.PageDescription = "ОАО Гипроживмаш выполнял услуги и работы по модернизации и реконструкции Хойникский завод ЖБИ (железо бетонных изделий)";
            return View(model);
        }

        [HttpGet]
        [Route("/портфолио/реконструкция-здания-тепловой-электро-станции-гомельский-химический-завод")]
        public IActionResult Himzavod()
        {
            var model = new PortfolioPageViewModel();
            model.PageTitle = "Реконструкция Гомельский химический завод";
            model.PageKeyword = "реконструкция,тэс, тепло, элеткро, станция модернизация, химзавод, гомельский химический завод";
            model.PageName = "Реконструкция Гомельский химический завод";
            model.PageDescription = "ОАО Гипроживмаш выполнял услуги и работы по модернизации и реконструкции Гомельский химический завод, химзавод в Гомеле";
            return View(model);
        }

        [HttpGet]
        [Route("/портфолио/строительство-завода-гомельдрев-речица")]
        public IActionResult Gomeldrev()
        {
            var model = new PortfolioPageViewModel();
            model.PageTitle = "Строительство Гомельдрев в Речице";
            model.PageKeyword = "строительство, проектирование, гомельдрев, гомель, речица";
            model.PageName = "Строительство Гомельдрев в Речице";
            model.PageDescription = "ОАО Гипроживмаш выполнял услуги и работы по модернизации, строительству и реконструкции Гомельдрев в Речице";
            return View(model);
        }
    }
}
