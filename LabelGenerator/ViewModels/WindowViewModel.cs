using System.Windows;
using System.Windows.Input;

namespace LabelGenerator.ViewModels {
    using LabelGenerator.Models;
    using LabelGenerator.Windows;

    public class WindowViewModel : BaseViewModel {
        private readonly Window m_Window;
        private readonly WindowModel m_Model;

        public string Title {
            get { return m_Model.WindowTitle; }
        }
        public double Width {
            get { return m_Model.WindowWidth; }
        }
        public double Height {
            get { return m_Model.WindowHeight; }
        }

        public object ChildDataContext { 
            get { return m_Model.ChildDataContext; }
            set {
                m_Model.ChildDataContext = value;
                OnPropertyChanged();
            }
        }

        public ICommand ExitCommand { get; set; }
        public ICommand EditTemplateCommand { get; set; }

        /// <summary>
        /// Default constructor, creates an Instance of the WindowViewModel class
        /// </summary>
        public WindowViewModel(Window window) {
            this.m_Model = new WindowModel();

            this.m_Window = window;
            this.m_Window.Loaded += (sender, e) => {
                ChildDataContext = new MainViewViewModel();
            };
            this.m_Window.Closed += (sender, e) => {
                ((MainViewViewModel)ChildDataContext).Closing();
            };


            // Setting up Commands for the Window, MainWindow.
            ExitCommand = new RelayCommand(() => { m_Window.Close(); });
            EditTemplateCommand = new RelayCommand(() => { new EditTemplateWindow().Show(); });
        }
    }
}
