using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ServerBackend.Models;

namespace ServerBackend.Validators
{
    public class PersonPostValidator : AbstractValidator<Person>, IPersonPostValidator
    {
        public PersonPostValidator()
        {
            RuleFor(p => p).NotNull();
        }
    }
}
