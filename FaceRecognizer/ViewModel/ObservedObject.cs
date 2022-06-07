using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognizer.ViewModel
{
    public abstract class ObservedObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(params string[] nazwyWlasnosci)
        {
            if (PropertyChanged != null)
            {
                foreach (string nazwaWlasnoci in nazwyWlasnosci)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nazwaWlasnoci));
                }
            }
        }

    }
}
