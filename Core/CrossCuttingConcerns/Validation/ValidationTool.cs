using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool //static olmasının sebebi tek bir instance üretimiyle ihtiyacı karşılamaktır.
    {
        public static void Validate(IValidator validator, object entity) //entity yada dto olabilir.static class ın metodu static olur
        {
            var context = new ValidationContext<object>(entity); //Entity, validator
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}

