using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FaceRecognizer.ViewModel
{
    public class NavigationViewModel : ObservedObject
    {
        public void CloseApp(object obj)
        {
            MainWindow win = obj as MainWindow;
            win.Close();
        }
        private ICommand _closeCommand;
        public ICommand CloseAppCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new RelayCommand(
                        p =>
                        {
                            CloseApp(p);
                        },
                        p => true);
                }
                return _closeCommand;
            }
        }
    }
}
