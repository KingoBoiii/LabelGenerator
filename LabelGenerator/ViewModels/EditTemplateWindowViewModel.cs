using System.Windows;
using System.Diagnostics;
using System.Windows.Input;

namespace LabelGenerator.ViewModels {
    using LabelGenerator.Models;

    public class EditTemplateWindowViewModel : BaseViewModel {
        private readonly Window m_Window;
        private readonly EditTemplateWindowModel m_Model;

        public object ChildDataContext {
            get { return m_Model.ChildDataContext; }
            set {
                m_Model.ChildDataContext = value;
                OnPropertyChanged();
            }
        }

        public ICommand ExitCommand { get; set; }

        // System.Windows.Data Error: 40 : BindingExpression path error: 'ChildDataContext' property not found on 'object' ''EditTemplateViewModel' (HashCode=35088084)'

        /// <summary>
        /// Default constructor, creates an Instance of the EditTemplateWindowViewModel class
        /// </summary>
        /// <param name="window"></param>
        public EditTemplateWindowViewModel(Window window) {
            this.m_Window = window;
            this.m_Window.Loaded += (sender, e) => {
                ChildDataContext = new EditTemplateViewModel();
            };
            this.m_Window.Closed += (sender, e) => {
                // ((EditTemplateViewModel)ChildDataContext).Closing();
            };
            this.m_Model = new EditTemplateWindowModel();

            ExitCommand = new RelayCommand(() => { this.m_Window.Close(); });
        }
    }
}
