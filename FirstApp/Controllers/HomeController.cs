using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactUs.Models;

namespace ContactUs.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index(int id)
        {
            ViewBag.message = id;
            ViewData["Message2"] = "Hello";

            return View();
        }
        [HttpGet("/codeYad/Privacy/{name}/{id:long}")]
        public IActionResult Privacy(string name, int id, string address)
        {
            return View(model: address);
        }
        [HttpGet("Home/Privacy")]
        public IActionResult Messages(string name)
        {
            ViewData["name"] = name;
            return View(DataBase.DataBase.Messages);
        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("sda", "Test Error");
                return View("Index", message);
            }
            if (message.PhoneNumber.Length == 11)
            {
                TempData["IsSuccess"] = true;
                DataBase.DataBase.Messages.Add(message);
            }
            return Redirect("/home/Messages");
        }
    }
}
