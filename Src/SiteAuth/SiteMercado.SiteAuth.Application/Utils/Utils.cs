using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace SiteMercado.SiteAuth.Application.Utils
{
    /// <summary>
    /// Utils class.
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Validate this command.
        /// </summary>
        /// <typeparam name="T">Model type to validate.</typeparam>
        /// <param name="validator">Validator implementation.</param>
        /// <param name="model">Model to validate.</param>
        /// <returns>Validation result.</returns>
        public static async Task<ValidationResult> ValidateCommandAsync<T>(AbstractValidator<T> validator, T model)
        {
            ValidationResult result = await validator.ValidateAsync(model);

            if (result.Errors.Where(e => e.Severity == Severity.Error).Any())
            {
                throw new ValidationException(result.Errors);
            }

            return result;
        }
    }
}
