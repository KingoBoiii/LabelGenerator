using System.Windows;
using System.Windows.Input;

namespace LabelGenerator.ViewModels {
    using LabelGenerator.Data;
    using LabelGenerator.Utils;
    using LabelGenerator.Models;

    public class EditTemplateWindowViewModel : BaseViewModel {
        private readonly Window m_Window;
        private readonly EditTemplateWindowModel m_Model;

        public string TemplateText {
            get { return m_Model.TemplateText; }
            set {
                if(m_Model.TemplateText != value) {
                    m_Model.TemplateText = value;
                    AppData.Instance.Template = TemplateText;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand NewCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        /// <summary>
        /// Default constructor, creates an Instance of the EditTemplateWindowViewModel class
        /// </summary>
        /// <param name="window"></param>
        public EditTemplateWindowViewModel(Window window) {
            this.m_Window = window;
            this.m_Model = new EditTemplateWindowModel();
            this.TemplateText = AppData.Instance.Template;

            NewCommand = new RelayCommand(() => {
                TemplateText = "";
            });
            OpenCommand = new RelayCommand(() => {
                FileUtil.OpenDialog(out string filepath, "Text Files (*.txt)|*.txt");
                string data = FileUtil.ReadFile(filepath);

                TemplateText = data;
            });
            SaveCommand = new RelayCommand(() => {
                FileUtil.WriteFile(AppData.Instance.TemplateFileName, TemplateText);
            });
            ExitCommand = new RelayCommand(() => { this.m_Window.Close(); });
        }
    }
}
