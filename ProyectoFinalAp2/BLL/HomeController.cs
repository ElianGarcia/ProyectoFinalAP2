using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinalAp2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult BootBox()
        {
            return View();
        }
    }
}
