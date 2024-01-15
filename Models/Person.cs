
using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Person 
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Person Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
