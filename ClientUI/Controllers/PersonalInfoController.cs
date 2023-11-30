using ClientUI.APIClient;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientUI.Controllers
{
    public class PersonalInfoController : Controller
    {
        private IAPIClientService<PersonalInfo> _iAPIClientService;

        public PersonalInfoController(IAPIClientService<PersonalInfo> iAPIClientService)
        {
            _iAPIClientService = iAPIClientService;
        }
        public async Task<IActionResult> Index()
        {
            string _subURL = "PersonalInfo/GetAll";
            var members = await _iAPIClientService.GetAll(_subURL);
            return View(members.Take(100));
        }
    }
}
