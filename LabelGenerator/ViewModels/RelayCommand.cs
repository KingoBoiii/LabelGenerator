using System;
using System.Windows.Input;

namespace LabelGenerator.ViewModels {
    public class RelayCommand : ICommand {
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        private Action m_ExecutionAction;

        /// <summary>
        /// Default constructor, creates an Instance of the RelayCommand class
        /// </summary>
        public RelayCommand(Action callback) {
            m_ExecutionAction = callback;
        }

        public bool CanExecute(object parameter) { return true; }

        public void Execute(object parameter) {
            if (m_ExecutionAction != null) {
                m_ExecutionAction.Invoke();
            }
        }
    }
}
