using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CW3.Controllers;

namespace CW3.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
    }
}
