﻿namespace Pezza.Common.Validators
{
    using FluentValidation;
    using Pezza.Common.Entities;

    public class AddressValidator : AbstractValidator<AddressBase>
    {
        public AddressValidator()
        {
            this.RuleFor(x => x.Address)
            .NotEmpty()
            .MaximumLength(500);

            this.RuleFor(x => x.City)
            .NotEmpty()
            .MaximumLength(100);

            this.RuleFor(x => x.Province)
            .NotEmpty()
            .MaximumLength(100);

            this.RuleFor(x => x.PostalCode)
            .NotEmpty()
            .Matches(@"^\d$")
            .MaximumLength(8);
        }
    }

    public class AddressUpdateValidator : AbstractValidator<AddressBase>
    {
        public AddressUpdateValidator()
        {
            this.RuleFor(x => x.Address)
            .MaximumLength(500);

            this.RuleFor(x => x.City)
            .MaximumLength(100);

            this.RuleFor(x => x.Province)
            .MaximumLength(100);

            this.RuleFor(x => x.PostalCode)
            .Matches(@"^\d$")
            .MaximumLength(8);
        }
    }
}
