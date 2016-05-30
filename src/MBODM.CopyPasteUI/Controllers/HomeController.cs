using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBODM.CopyPasteUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MBODM.CopyPasteUI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new HomeViewModel());
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }
    }
}
