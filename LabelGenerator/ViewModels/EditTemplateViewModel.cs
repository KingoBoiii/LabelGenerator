using System.Windows;

namespace LabelGenerator.ViewModels {
    using LabelGenerator.Models;

    public class EditTemplateViewModel : BaseViewModel {
        private readonly EditTemplateModel m_Model;

        public string TemplateText {
            get { return m_Model.TemplateText; }
            set {
                if(m_Model.TemplateText != value) {
                    m_Model.TemplateText = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Test { get; set; } = "Hello, world";

        /// <summary>
        /// Default constructor, creates an Instance of the EditTemplateViewModel class
        /// </summary>
        /// <param name="window"></param>
        public EditTemplateViewModel() {
            this.m_Model = new EditTemplateModel();
        }
    }
}
