using SchoolPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolPlatform.Commands
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Predicate<T> _canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke((T)parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _execute?.Invoke((T)parameter);
        }

        //private Action<T> commandTask;
        //private Predicate<T> canExecuteTask;

        //public RelayCommand(Action<T> workToDo)
        //    : this(workToDo, DefaultCanExecute)
        //{
        //    commandTask = workToDo;
        //}

        //public RelayCommand(Action<T> workToDo, Predicate<T> canExecute)
        //{
        //    commandTask = workToDo;
        //    canExecuteTask = canExecute;
        //}

        //private static bool DefaultCanExecute(T parameter)
        //{
        //    return true;
        //}

        //public bool CanExecute(object parameter)
        //{
        //    return canExecuteTask != null && canExecuteTask((T)parameter);
        //}

        //public event EventHandler CanExecuteChanged
        //{
        //    add
        //    {
        //        CommandManager.RequerySuggested += value;
        //    }

        //    remove
        //    {
        //        CommandManager.RequerySuggested -= value;
        //    }
        //}

        //public void Execute(object parameter)
        //{
        //    commandTask((T)parameter);
        //}
    }
}
