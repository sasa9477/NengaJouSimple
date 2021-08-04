using NengaJouSimple.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace NengaJouSimple.ViewModels.Components
{
    public class PrintDialogViewModel : BindableBase, IDialogAware
    {
        private readonly PrintService printService;

        private string message;

        private string title = "通知ダイアログ";

        private FrameworkElement element;

        private double printMarginLeft;

        private double printMarginTop;

        public PrintDialogViewModel(PrintService printService)
        {
            this.printService = printService;

            PrintCommand = new DelegateCommand(Print);

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

        public DelegateCommand PrintCommand { get; }

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
            //Message = parameters.GetValue<string>("message");

            //element = parameters.GetValue<FrameworkElement>("element");

            //printMarginLeft = parameters.GetValue<double>("printMarginLeft");

            //printMarginTop = parameters.GetValue<double>("printMarginTop");
        }

        private void Print()
        {
            printService.Print(element, printMarginLeft, printMarginTop);
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
