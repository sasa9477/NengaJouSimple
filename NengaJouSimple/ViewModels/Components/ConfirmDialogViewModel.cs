using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NengaJouSimple.ViewModels.Components
{
    public class ConfirmDialogViewModel : BindableBase, IDialogAware
    {
        private string message;

        private string title = "確認";

        public ConfirmDialogViewModel()
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
            Message = parameters.GetValue<string>("message");
        }

        private void CloseDialog(string parameter)
        {
            var buttonResult = parameter switch
            {
                "true" => ButtonResult.Yes,
                "false" => ButtonResult.No,
                _ => ButtonResult.None
            };

            RaiseRequestClose(new DialogResult(buttonResult));
        }

        private void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }
    }
}
