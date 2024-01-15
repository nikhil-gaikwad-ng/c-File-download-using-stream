using Microsoft.AspNetCore.Mvc;
using Test.Extentions;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GenericController : Controller
    {
        private readonly GenericService _service;
       
        public GenericController() { 
            this._service = new GenericService();
        }

        [HttpGet]
        [ProducesResponseType(typeof(Response<Person>), 200)]
        public IActionResult GenericData(string name)
        {
            Response<Person> result= this._service.GenericData(name);
            return StatusCode(result.Status, result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Person), 200)]
        public IActionResult GenericData(Person person)
        {
            return StatusCode(200,person);
        }












        //[HttpGet]
        //public T GetQueryString<T>(string name)
        //{

        //        try
        //        {
        //            if (name.Length > 4)
        //            {
        //               return (T)Convert.ChangeType(new Response
        //                {
        //                    Status = 201,
        //                    Data = new Person
        //                    {

        //                        Name = name,
        //                        Description = "DEsc",
        //                        Id = Guid.NewGuid().ToString()

        //                    }
        //                }, typeof(T));
        //        }

        //            return (T)Convert.ChangeType(new Response { Status = 400, Data = new Error { Message = $"Name is Short {name.Length}" } }, typeof(T));
        //        }
        //        catch
        //        {
        //            //Could not convert.  Pass back default value...
        //            return default(T);
        //        }


        //}
    }
}
