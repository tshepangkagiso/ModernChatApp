using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace ModernChatApp.Core
{
    // This line defines a public class called RelayCommand that implements the ICommand interface.
    public class RelayCommand : ICommand
    {
        // These two lines define private fields for delegates that will be passed to the constructor.
        private Action<object> execute;
        private Func<object, bool> canExecute;

        // This line defines an event called CanExecuteChanged that will be raised when the result of CanExecute changes.
        // The add and remove blocks subscribe and unsubscribe to the RequerySuggested event of the CommandManager respectively.
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // This is the constructor of the RelayCommand class.
        // It takes an Action<object> delegate for the execute method and an optional Func<object, bool> delegate for the canExecute method.
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            // These lines assign the execute and canExecute delegates to the private fields of the RelayCommand class.
            this.execute = execute;
            this.canExecute = canExecute;
        }

        // This method determines whether the command can execute with the given parameter.
        // If canExecute is not null, it returns the result of the canExecute delegate with the given parameter.
        // If canExecute is null, it returns true.
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        // This method executes the command with the given parameter by invoking the execute delegate.
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
    /*
    This code defines a class called RelayCommand that implements the ICommand interface. The purpose of ICommand is to 
    enable an object to act as a command, which can be bound to a control in a user interface such as a button or a menu 
    item.The RelayCommand class is a common implementation of the ICommand interface in the MVVM(Model-View-ViewModel) 
    design pattern.

    The RelayCommand class has two fields: execute and canExecute.execute is a delegate that takes an object parameter and 
    performs an action. canExecute is a delegate that takes an object parameter and returns a Boolean value indicating whether 
    the command can be executed with the given parameter.

    The RelayCommand class also has an event called CanExecuteChanged, which is raised when the result of the CanExecute 
    method changes.In this code, the event is implemented using the CommandManager.RequerySuggested event, which is a built-in 
    event in WPF (Windows Presentation Foundation).

    The constructor of RelayCommand takes two parameters: execute and canExecute. execute is required, while canExecute is 
    optional. When the Execute method of the command is called, it will invoke the execute delegate with the given parameter. 
    When the CanExecute method is called, it will return the result of the canExecute delegate, or true if canExecute is null.

    Overall, this code provides a convenient way to define commands in an MVVM application, which can be bound to controls in a 
    user interface and perform actions when invoked.
*/
}
