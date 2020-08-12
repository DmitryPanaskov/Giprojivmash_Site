using System.Threading.Tasks;
using AutoMapper;
using Giprojivmash.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Giprojivmash.WEB.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceFirstLayerService _serviceFirstLayerService;
        private readonly IServiceSecondLayerService _serviceSecondLayerService;
        private readonly IServiceThirdLayerService _serviceThirdLayerService;
        private readonly IMapper _mapper;

        public BaseController(ILogger<HomeController> logger, IMapper mapper,
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

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            return base.OnActionExecutionAsync(context, next);
        }
    }
}
