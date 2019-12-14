using System.Threading.Tasks;
using CactusCare.Abstractions.Services;
using FluentValidation;
using FluentValidation.Results;

namespace CactusCare.BLL.Services
{
    public class FluentValidationService : IValidationService
    {
        private readonly IValidatorFactory _validatorFactory;

        public FluentValidationService(IValidatorFactory validatorFactory)
        {
            this._validatorFactory = validatorFactory;
        }

        public Task<ValidationResult> ValidateAsync<T>(T entity) where T : class
        {
            var validator = this._validatorFactory.GetValidator(entity.GetType());
            return validator.ValidateAsync(entity);
        }
    }
}