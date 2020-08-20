using AutoMapper;
using Giprojivmash.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Giprojivmash.WEB.Controllers
{
    public class ContactController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactService _contactService;
        private readonly IContactDataService _contactDataService;
        private readonly IMapper _mapper;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out", Justification = "<>")]
        public ContactController(ILogger<HomeController> logger, IMapper mapper,
        IContactService contactService,
        IContactDataService contactDataService)
            : base(logger, mapper)
        {
            _mapper = mapper;
            _contactService = contactService;
            _contactDataService = contactDataService;
            _logger = logger;
        }

        [HttpGet]
        [Route("/kontakty/rukovdstvo")]
        public IActionResult Managers()
        {
            return View();
        }
    }
}
