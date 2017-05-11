using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Everlane.Models;

namespace Everlane.Controllers
{
    public class YelpController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetReviews(string newBusiness, string newZipcode)
        {
            var businessList = Yelp.GetReviews(newBusiness, newZipcode);

            return Json(businessList);

        }
    }
}
