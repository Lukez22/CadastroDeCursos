using System;
using System.ComponentModel.DataAnnotations;

namespace web_api_cursos
{
    public class DataNoPassadoAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) 
        {
            if (value == null) return ValidationResult.Success;

            DateTime data = (DateTime)value;

            if(data.Date < DateTime.Today)
                return new ValidationResult("A data não pode ser no passado");

            return ValidationResult.Success;
        }
    }
}