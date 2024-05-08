
using System.ComponentModel.DataAnnotations;

namespace Test.FilterValidations
{
    public class MinMaxValidation : ValidationAttribute
    {
        private readonly int _min;
        private readonly int _max;
        public MinMaxValidation(int min,int max)
        {
            _min = min;
            _max = max;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Perform your custom validation logic here
            // For demonstration purposes, let's assume we want to validate that the value is a positive integer
            if (value is string str)
            {
                if(str.Length < _min)
                {
                    return new ValidationResult($"The value must be bigger thans {_min}");

                }
                else if(str.Length > _max)
                {
                    return new ValidationResult($"The value must be smaller thans {_max}");
                }
            }

            // Validation passed
            return ValidationResult.Success;
        }
    }

}
