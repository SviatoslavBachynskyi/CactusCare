using System;
using Autofac;
using FluentValidation;

namespace CactusCare.BLL
{
    public class AutofacValidatorFactory : IValidatorFactory
    {
        private readonly IComponentContext _container;

        public AutofacValidatorFactory(IComponentContext container)
        {
            this._container = container;
        }

        public IValidator<T> GetValidator<T>()
        {
            return (IValidator<T>)GetValidator(typeof(T));
        }

        public IValidator GetValidator(Type type)
        {
            var genericType = typeof(IValidator<>).MakeGenericType(type);
            if (_container.TryResolve(genericType, out var validator))
                return (IValidator)validator;

            return null;
        }
    }
}