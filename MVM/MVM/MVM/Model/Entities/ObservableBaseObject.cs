using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVM
{
    public class ObservableBaseObject : INotifyPropertyChanged
    {
        public ObservableBaseObject()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged = delegate {


        };

        public void OnPropertyChanged([CallerMemberName] string nome = "")
        {
            if (PropertyChanged == null)
                return;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nome));
        }
            
    }
}
