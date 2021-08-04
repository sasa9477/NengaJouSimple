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
        private const string FirstMessage = "始めの一枚目のプリントはテスト用紙を使用してください。\nOKボタンを押すことで印刷を実行します。";

        private const string SecondMessage = "印刷が成功した場合は はがきをプリンターにセットし\n再度印刷を実行してください。\nOKボタンを押すことで印刷を実行します。";

        private const string RetryPrintingMessage = "再度印刷を実行しますか？";

        private const string ExecuteSeqencePrintingMessage = "連続印刷を実行しますか？";

        private readonly PrintService printService;

        private string message;

        private string title = "プリントダイアログ";

        private FrameworkElement printElement;

        private double printMarginLeft;

        private double printMarginTop;

        private bool isPrintSeqenceRequest;

        private string executeButtonText;

        private bool isVisibleChangePrintingLocationHelperDialogShowButton;

        public PrintDialogViewModel(PrintService printService)
        {
            this.printService = printService;

            message = FirstMessage;

            executeButtonText = "OK";

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

        public string ExecuteButtonText
        {
            get { return executeButtonText; }
            set { SetProperty(ref executeButtonText, value); }
        }

        public bool IsVisibleChangePrintingLocationHelperDialogShowButton
        {
            get { return isVisibleChangePrintingLocationHelperDialogShowButton; }
            set { SetProperty(ref isVisibleChangePrintingLocationHelperDialogShowButton, value); }
        }

        public DelegateCommand PrintCommand { get; }

        public DelegateCommand<string> CloseDialogCommand { get; }

        public DelegateCommand ShowChangePrintingLocationHelperDialogCommand { get; }


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
            printElement = parameters.GetValue<FrameworkElement>("printElement");

            printMarginLeft = parameters.GetValue<double>("printMarginLeft");

            printMarginTop = parameters.GetValue<double>("printMarginTop");

            isPrintSeqenceRequest = parameters.GetValue<bool>("isPrintSeqenceRequest");
        }

        private void Print()
        {
            printService.Print(printElement, printMarginLeft, printMarginTop);

            if (Message == FirstMessage)
            {
                Message = SecondMessage;

                IsVisibleChangePrintingLocationHelperDialogShowButton = true;

                return;
            }

            if (Message == SecondMessage)
            {
                ExecuteButtonText = "はい";

                if (!isPrintSeqenceRequest)
                {
                    Message = RetryPrintingMessage;

                    return;
                }

                Message = ExecuteSeqencePrintingMessage;
            }
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
