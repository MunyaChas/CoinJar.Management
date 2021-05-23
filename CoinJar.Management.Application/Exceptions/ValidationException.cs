using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinJar.Management.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();
            foreach (var item in validationResult.Errors)
            {
                ValidationErrors.Add(item.ErrorMessage);
            }
        }

        public List<string> ValidationErrors { get; set; }
    }
}
