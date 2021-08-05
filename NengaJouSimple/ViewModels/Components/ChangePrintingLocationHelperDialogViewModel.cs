using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.ViewModels.Components
{
    public class ChangePrintingLocationHelperDialogViewModel : BindableBase, IDialogAware
    {
        private string title = "ヘルプ";

        public ChangePrintingLocationHelperDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand(CloseDialog);
        }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public DelegateCommand CloseDialogCommand { get; }

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
        }
        private void CloseDialog()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        }
    }
}