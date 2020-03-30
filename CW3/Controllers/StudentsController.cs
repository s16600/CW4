using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CW3.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        /*
        public IActionResult Index()
        {
            return View();
        }
        */

        [HttpGet]

        public string GetStudent()
        {
            return "Kowalski, Majeski, Andrzejewski";
        }

    }
}