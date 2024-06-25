using FlexiDev.Interface;
using FlexiDev.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlexiDev.Controllers
{
    public class HomeController : Controller
    {
        public ICalculationService _cService;
        public HomeController(ICalculationService calculationService)
        {
            _cService = calculationService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(List<Person> data)
        {
            ResultView result = new ResultView();
            result.AverageKills = _cService.AverageKills(data);
            return View("Result", result);
        }
    }
}
