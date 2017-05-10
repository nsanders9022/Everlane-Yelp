using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Everlane.Models; 

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Everlane.Controllers
{
    public class InstagramController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetInstagram()
        {
            var allInstagram = Instagram.GetInstagram();
            return View(allInstagram);
        }


    }
}
