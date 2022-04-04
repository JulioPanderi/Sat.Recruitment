using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Api.Domain.Extensions
{
    public static class ModelExtensions
    {
        public static string ErrorsToString(this IEnumerable<ValidationResult> source, string messageEmptyCollection = null)
        {
            StringBuilder result = new StringBuilder();

            if (source.Count() > 0)
            {
                //result.AppendLine("We found the next validations errors:");
                source.ToList()
                    .ForEach(
                        s => result.AppendFormat("  {0} --> {1}{2}", s.MemberNames.FirstOrDefault(), s.ErrorMessage, Environment.NewLine)
                    );
            }
            else
            {
                result.AppendLine(messageEmptyCollection ?? string.Empty);
            }
            return result.ToString();
        }

        public static IEnumerable<ValidationResult> ValidateObject(this object source)
        {
            ValidationContext valContext = new ValidationContext(source, null, null);
            var result = new List<ValidationResult>();
            Validator.TryValidateObject(source, valContext, result, true);

            return (result.Count == 0 ? null : result);
        }
    }
}