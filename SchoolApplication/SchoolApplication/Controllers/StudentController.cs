using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Models;

namespace SchoolApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private List<Student> _students = new List<Student>();

        public StudentController()
        {
            _students.Add(new Student { FirstName = "John", LastName = "Smith", IdNumber = 1234 });
            _students.Add(new Student { FirstName = "Jack", LastName = "Johnson", IdNumber = 5678 });
        }
        [HttpGet]
        public IActionResult GetStudents(string LastName, string FirstName, int? IdNumber)
        {
            if (LastName!= null)
                _students = _students.Where(x => x.LastName == LastName).ToList();
            if(FirstName != null)
                _students = _students.Where(x => x.FirstName == FirstName).ToList();
            if (IdNumber.HasValue)
                _students = _students.Where(x => x.IdNumber == IdNumber).ToList();

            return new OkObjectResult(_students);
        }
    }
}
