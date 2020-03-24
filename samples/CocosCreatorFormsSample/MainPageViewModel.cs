using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CocosCreatorFormsSample
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand NativeCallCommand { get; set; }
        public MainPageViewModel()
        {
            NativeCallCommand = new Command(OnExecuteNativeCallCommand);
        }

        private void OnExecuteNativeCallCommand(object obj)
        {
            CocosCreator.Forms.JSBrigde.EvaluateScript("cc.TestNativeCallJS()");
        }
    }
}
