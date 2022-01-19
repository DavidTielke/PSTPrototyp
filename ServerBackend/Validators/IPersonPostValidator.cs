using FluentValidation;
using ServerBackend.Models;

namespace ServerBackend.Validators
{
    public interface IPersonPostValidator : IValidator<Person> {}
}