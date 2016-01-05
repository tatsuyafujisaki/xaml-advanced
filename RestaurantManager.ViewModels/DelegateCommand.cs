using System;
using System.Windows.Input;

namespace RestaurantManager.ViewModels
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action execute)
            : this(execute, () => true)
        { }

        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object p)
        {
            return _canExecute?.Invoke() ?? true;
        }

        public void Execute(object p)
        {
            if (CanExecute(null))
            {
                _execute();
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
