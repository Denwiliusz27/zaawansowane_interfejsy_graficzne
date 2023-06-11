using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
//using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, event_args) => { };

        // w przypadku zmiany wartości jakiegoś pola, powiadamia o tym
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
