using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Giprojivmash.WEB.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;

        public BaseController(ILogger<HomeController> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
        }
    }
}
