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

        private Window m_EditTemplateWindow;

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
                if (m_EditTemplateWindow != null) {
                    m_EditTemplateWindow.Close();
                }

                ((MainViewViewModel)ChildDataContext).Closing();
                ChildDataContext = null;
            };


            // Setting up Commands for the Window, MainWindow.
            ExitCommand = new RelayCommand(() => {
                if (m_EditTemplateWindow != null) {
                    m_EditTemplateWindow.Close();
                }
                m_Window.Close();
            });
            EditTemplateCommand = new RelayCommand(() => { 
                m_EditTemplateWindow = new EditTemplateWindow();
                m_EditTemplateWindow.Closed += (sender, e) => { m_EditTemplateWindow = null; };
                m_EditTemplateWindow.Show();
            });
        }
    }
}
