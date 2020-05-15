using System.Windows;

namespace LabelGenerator.Windows {
    /// <summary>
    /// Interaction logic for EditTemplateWindow.xaml
    /// </summary>
    public partial class EditTemplateWindow : Window {
        public EditTemplateWindow() {
            InitializeComponent();
            this.DataContext = new ViewModels.EditTemplateWindowViewModel(this);
        }
    }
}
