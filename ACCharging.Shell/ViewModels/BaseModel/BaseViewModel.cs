using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ACCharging.Shell.ViewModels
{
    public class BaseViewModel: BindableBase
    {
        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public DelegateCommand InitializeViewModelCommand { get; set; }

        public BaseViewModel()
        {
            InitializeViewModelCommand = new DelegateCommand(InitViewModel);
        }

        public virtual void InitViewModel()
        {
            //
        }

        public bool HaveErrors => _errors.Count > 0;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate { };
        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
                return _errors[propertyName];
            else
                return null;
        }

        protected override bool SetProperty<T>(ref T storage, T value, Action onChanged, [CallerMemberName] string propertyName = null)
        {
            var result = base.SetProperty(ref storage, value, onChanged, propertyName);
            ValidateProperty(propertyName, value);
            return result;
        }

        protected void ValidateProperty<T>(string propertyName, T value)
        {
            var results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(this);
            context.MemberName = propertyName;
            //Validator.ValidateProperty(value, context);
            Validator.TryValidateProperty(value, context, results);

            if (results.Any())
            {
                _errors[propertyName] = results.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                _errors.Remove(propertyName);
            }

            ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
