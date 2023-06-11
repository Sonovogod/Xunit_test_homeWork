using Microsoft.AspNetCore.Mvc;
using XUnitStudyProject.Models;

namespace XUnitStudyProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            ViewResult result = View("Main", model);
            result.StatusCode = 200;
            ViewData["Message"] = "Добрый день, это тестовый текст на главной странице";
            return result;
        }

        public IActionResult Privacy()
        {
            ViewData["Policy"] = "Текст политики конфидециальности сайта.";
            return View("Privacy");
        }

        public IActionResult TestPage(int page)
        {
            ViewBag.PageIncrement = ++page;
            return View(new TestPageViewModel{Page = page});
        }

        
    }
}