using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CW3.Controllers;
using CW3.Models;

namespace CW3.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();

        public IEnumerable<Enrollment> GetStudentsEnrollment(string id);
    }
}
