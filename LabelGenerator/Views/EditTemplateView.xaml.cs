using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabelGenerator.Views {
    /// <summary>
    /// Interaction logic for EditTemplateView.xaml
    /// </summary>
    public partial class EditTemplateView : UserControl {
        public EditTemplateView() {
            InitializeComponent();
            this.DataContext = new ViewModels.EditTemplateViewModel();
        }
    }
}
