using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LabelGenerator.ViewModels {
    public class BaseViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged = (e, sender) => { };

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") {
            this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
