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
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Messages()
        {
            return View(DataBase.DataBase.Messages);
        }


        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            DataBase.DataBase.Messages.Add(message);
            return Redirect("/home/Messages");
        }
    }
}
