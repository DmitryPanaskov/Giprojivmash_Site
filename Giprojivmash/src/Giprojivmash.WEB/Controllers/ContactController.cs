using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.DataModels.Enums;
using Giprojivmash.WEB.Models;
using Giprojivmash.WEB.Models.Contact;
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
        [Route("/контакты")]
        public IActionResult General()
        {
            var model = new GeneralContactPageViewModel();
            model.Contact = _mapper.Map<ContactViewModel>(_contactService.GetAll().First(m => m.PositionType == PositionType.General));
            model.ContactDataList = _mapper.Map<List<ContactDataViewModel>>(_contactDataService.GetContactDataListByPositionType(PositionType.General));
            model.PageName = "Контакты";
            model.PageTitle = "Контакты, схема проезда, карта, приемная, телефон, время работы, обед";
            model.Sidebar = InitSidebar();
            return View("General", model);
        }

        [HttpGet]
        [Route("/контакты/руководство")]
        public IActionResult Manager()
        {
            var model = InitializeContactPageViewModel(PositionType.Manager);
            model.PageName = "Руководство";
            model.Sidebar = InitSidebar();
            return View("Contact", model);
        }

        [HttpGet]
        [Route("/контакты/главные-инженеры-проектов")]
        public IActionResult ChiefProjectEngineer()
        {
            var model = InitializeContactPageViewModel(PositionType.ChiefProjectEngineer);
            model.PageName = "Главные инженеры проектов";
            model.Sidebar = InitSidebar();
            return View("Contact", model);
        }

        [HttpGet]
        [Route("/контакты/отделы")]
        public IActionResult Department()
        {
            var model = InitializeContactPageViewModel(PositionType.HeadOfDepartment);
            model.PositionType = PositionType.HeadOfDepartment;
            model.PageName = "Отделы";
            model.PageTitle = "Телефон бухгалтерии и главного бухгалтера, отдела кадров, планово-производственного отдела, планово-экономического отдела, юриста, отдела качества," +
                " генерального плана, архитектурного-планировочного, строительного, сметно-экономического,  электроснабжения," +
                "слаботочных систем, водоснабжение , канализация, теплоснабжение, газоснабжение, вентиляция, генплана, отдела";
            model.Sidebar = InitSidebar();
            return View("Contact", model);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<>")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out", Justification = "<>")]
        private List<SidebarLineViewModel> InitSidebar()
        {
            var sidebar = new List<SidebarLineViewModel>
            {
                new SidebarLineViewModel
                {
                    SidebarAction = "General",
                    SidebarName = "Контакты",
                },
                new SidebarLineViewModel
                {
                    SidebarAction = "Manager",
                    SidebarName = "Руководство",
                },
                new SidebarLineViewModel
                {
                    SidebarAction = "ChiefProjectEngineer",
                    SidebarName = "Главные инженеры проектов",
                },
                new SidebarLineViewModel
                {
                    SidebarAction = "Department",
                    SidebarName = "Отделы",
                },
            };
            return sidebar;
        }

        private ContactPageViewModel InitializeContactPageViewModel(PositionType position)
        {
            var model = new ContactPageViewModel();
            model.ContactList = _mapper.Map<List<ContactViewModel>>(_contactService.GetAll().Where(m => m.PositionType == position));
            model.ContactDataList = _mapper.Map<List<ContactDataViewModel>>(_contactDataService.GetContactDataListByPositionType(position));
            return model;
        }
    }
}
