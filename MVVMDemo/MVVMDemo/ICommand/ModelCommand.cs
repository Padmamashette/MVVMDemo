using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMDemo.Command
{
    public class ModelCommand : ICommand
    {
        // Fields 
        #region Fields
        readonly Action<object> _execute;
        private Func<bool> canExecuteEvaluator;
        private Action openProjectUI;
        private ICommand importExternalDataCommand;
        #endregion

        // Constructors 
        #region Constructors
        public ModelCommand() { }
        public ModelCommand(Action<object> execute)
            : this(execute, null)
        {

        }
        public ModelCommand(Action<object> execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");
            canExecuteEvaluator = canExecute;
        }

        public ModelCommand(Action openProjectUI)
        {
            this.openProjectUI = openProjectUI;
        }

        public ModelCommand(ICommand importExternalDataCommand)
        {
            this.importExternalDataCommand = importExternalDataCommand;
        }
        #endregion

        //Members
        #region ICommand Members [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {

            bool result = true;
            try
            {
                object targetClass = _execute.Target;
                if (this.canExecuteEvaluator == null)
                {
                    result = true;
                }
                else
                {
                    result = this.canExecuteEvaluator.Invoke();

                }
            }
            catch (Exception e)
            {
                string msg = e.ToString();
            }
            return result;
        }
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        public void Execute(object parameter)
        {
            _execute?.Invoke(parameter);
        }
        #endregion // ICommand Members
    }
}
