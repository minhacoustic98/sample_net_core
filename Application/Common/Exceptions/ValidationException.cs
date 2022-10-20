using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;
using System.Linq;


namespace Application.Common.Exceptions
{
    public class ValidationException: Exception
    {
        public ValidationException()
           : base("One or more validation failures have occurred.")
        {
            Failures = new Dictionary<string, string[]>();
        }

        public ValidationException(List<ValidationFailure> failures): this()
        {
            var propertyName = failures.Select(e => e.PropertyName).Distinct();

            foreach(var prop in propertyName)
            {
                var propertyFailure = failures.Where(x => x.PropertyName == prop)
                                              .Select(x => x.ErrorMessage)
                                              .ToArray();

                Failures.Add(prop, propertyFailure);
            }
        }

        public IDictionary<string, string[]> Failures { get; }

    }
}
