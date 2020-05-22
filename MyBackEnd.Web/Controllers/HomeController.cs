using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBackEnd.DataAccess.Concrete.EntityFramework.Contexts;
using MyBackEnd.Entities.Concrete;
using MyBackEnd.Web.Models;

namespace MyBackEnd.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        MyDataContext db;

        public HomeController(ILogger<HomeController> logger,MyDataContext _db)
        {
            _logger = logger;
            db = _db;
        }

        public IActionResult Index()
        {
            
            List<Product> test = db.Products.ToList();
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
