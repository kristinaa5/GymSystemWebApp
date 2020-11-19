using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GymSystemWeb.Models;
using GymSystem;
using Microsoft.EntityFrameworkCore;
using GymSystem.ViewModels;
using GymSystem.DBLayer;

namespace GymSystemWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly GymSystemDBContext context;

        public HomeController(GymSystemDBContext _context)
        {
            context = _context;
        }

        public IActionResult Filter()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Filter([Bind("gender, address, date")] FilterViewModel filter)
        {
            var result = new DbUserTraining(context).getViewModelList(filter);

            return View(result);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

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
