using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IndiceEconomicoAPI.Controllers
{
    public class MoedasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}