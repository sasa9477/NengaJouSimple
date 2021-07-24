using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NengaJouSimple.ViewModels.Components
{
    public class AlertDialogViewModel : BindableBase, IDialogAware
    {
        private string message;

        private string title = "通知ダイアログ";

        public AlertDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
        }

        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        public DelegateCommand<string> CloseDialogCommand { get; }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message = parameters.GetValue<string>("Message");
        }

        private void CloseDialog(string parameter)
        {
            ButtonResult buttonResult = parameter?.ToLower() == "true" ? ButtonResult.OK : ButtonResult.Cancel;
            RaiseRequestClose(new DialogResult(buttonResult));
        }

        private void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }
    }
}
