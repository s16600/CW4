using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CW3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        /*
        public IActionResult Index()
        {
            return View();
        }
        */

        [HttpGet]
        public string GetStudents(string orderBy)
        {
            return $"Kowalski, Malewski, Andrzejewski sortowanie={orderBy}";
        }

        [HttpGet("{id}")]
        public IActionResult GetStudents(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            } else if (id == 2)
            {
                return Ok("Malewski");
            }
            return NotFound("Nie znaleziono studenta");
        }

    }
}