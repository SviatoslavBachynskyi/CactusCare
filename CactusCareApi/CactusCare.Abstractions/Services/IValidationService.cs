using System.Threading.Tasks;
using FluentValidation.Results;

namespace CactusCare.Abstractions.Services
{
    public interface IValidationService
    {
        Task<ValidationResult> ValidateAsync<T>(T entity) where T : class;
    }
}