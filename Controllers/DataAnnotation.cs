using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DataAnnotation : Controller
    {
        [HttpPost]
            public IActionResult getStudent(Student s)
        {
            Student s1= new Student();
            s1.name = "sadsad";
            return Ok(new { studentId = 1 });
        }
    }

}
