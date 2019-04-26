using ACCharging.Common;
using ACCharging.Core.Models;
using ACCharging.Core.Services;
using Prism.Commands;
using System;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using Unity.Attributes;

namespace ACCharging.Shell.ViewModels
{
    public class NewUserWindowViewModel : BaseWindowViewModel
    {
        private string _userName;
        [Required(ErrorMessage = "Please input user name")]
        [RegularExpression("^[A-Za-z0-9]+$", ErrorMessage = "Only number and English letters")]
        public string UserName
        {
            get => _userName;
            set
            {
                
                SetProperty(ref _userName, value);
            }
        }

        private string _password;
        [Required(ErrorMessage = "Please input password")]
        [MaxLength(10, ErrorMessage = "must less than 10 characters")]
        public string Password
        {
            get => _password;
            set
            {
               
                SetProperty(ref _password, value);
            }
        }

        private UserGender _gender = UserGender.Male;
        public UserGender Gender
        {
            get => _gender;
            set => SetProperty(ref _gender, value);
        }

        private string _mobile;
        public string Mobile
        {
            get => _mobile;
            set => SetProperty(ref _mobile, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        [Dependency]
        public UserService UserService { get; set; }

        public DelegateCommand<Window> SaveCommand { get; set; }
        public DelegateCommand<Window> CancelCommand { get; set; }

        public NewUserWindowViewModel()
        {
            SaveCommand = new DelegateCommand<Window>(SaveNewUser);
            CancelCommand = new DelegateCommand<Window>(CancelNewUser);
        }

        private async void SaveNewUser(Window window)
        {
            UserModel user = new UserModel
            {
                UserName = UserName,
                Password = !string.IsNullOrEmpty(Password) ? CryptographyHelper.Encrypt(Password) : "",
                Gender = (UserGender)Enum.Parse(typeof(UserGender), Gender.ToString()),
                Mobile = Mobile,
                Email = Email
            };

            // validate UserModel
            UserModelValidator validator = new UserModelValidator();
            FluentValidation.Results.ValidationResult results = await validator.ValidateAsync(user);
            if (!results.IsValid)
            {
                // have errors
                foreach (FluentValidation.Results.ValidationFailure failure in results.Errors)
                {
                    // add error message into error list
                    //_errors.Add($"{failure.PropertyName}: {failure.ErrorMessage}");
                }
            }


            ValidateProperty("UserName", UserName);
            ValidateProperty("Password", Password);

            if (!HaveErrors)
            {
                await UserService.NewUser(user);

                if (window != null)
                    window.Close();
            }
        }

        private void CancelNewUser(Window window)
        {
            if (window != null)
                window.Close();
        }
    }
}
