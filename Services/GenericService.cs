using Test.Extentions;
using Test.Models;

namespace Test.Services
{
    public class GenericService
    {
        public Response<Person> GenericData(string name)
        {
            if (!name.MinMaxLength(2, 5))
            {
                return new Response<Person> { Status = 400, Message = $"Name Not Valid (Min-2 Max-5)" };
            }
            if (!name.MinLength(4))
            {
                return new Response<Person> { Status = 400, Message = $"Name is short {name} {name.Length}" };
            }
            return new Response<Person>
            {
                Status = 201,
                Body = new Person
                {
                    Name = name,
                    Description = "DEsc",
                    Id = Guid.NewGuid().ToString()
                }
            };

        }
    }
}
