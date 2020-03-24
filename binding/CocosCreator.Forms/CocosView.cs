using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace CocosCreator.Forms
{
    public class CocosView : View
    {
        public static readonly BindableProperty NativeCallCommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(CocosView), null);

        public ICommand NativeCallCommand
        {
            get { return (ICommand)GetValue(NativeCallCommandProperty); }
            set { SetValue(NativeCallCommandProperty, value); }
        }

        public static void Execute(ICommand command , object parameter)
        {
            if (command == null) return;
            if (command.CanExecute(parameter))
            {
                command.Execute(parameter);
            }
        }
    }
}
