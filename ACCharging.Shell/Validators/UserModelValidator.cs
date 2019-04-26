using ACCharging.Core.Models;
using FluentValidation;
using System;
using System.Linq;

namespace ACCharging.Shell
{
    public class UserModelValidator : AbstractValidator<UserModel>
    {
        public UserModelValidator()
        {
            RuleFor(u => u.UserName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 10).WithMessage("Length ({TotalLength}) of {PropertyName} Invalid")
                .Must(BeAValidName).WithMessage("{PropertyName} Contains Invalid Characters");

            RuleFor(u => u.Mobile)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(11).WithMessage("Length ({TotalLength}) of {PropertyName} Invalid")
                .Must(BeAValidMobile).WithMessage("{PropertyName} Contains Invalid Characters");
        }

        private bool BeAValidMobile(string mobile)
        {
            return mobile.All(Char.IsNumber);
        }

        private bool BeAValidName(string userName)
        {
            userName = userName.Replace(" ", "");
            userName = userName.Replace("-", "");
            return userName.All(Char.IsLetter);
        }
    }
}
