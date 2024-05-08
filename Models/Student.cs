using Test.FilterValidations;

namespace Test.Models
{

    public class Student
    {
        public int id { get; set; }

        [MinMaxValidation(2,5)]
        public string name { get; set; }
    }
}
