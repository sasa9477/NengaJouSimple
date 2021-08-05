using NengaJouSimple.Extensions;
using NengaJouSimple.Services;
using NengaJouSimple.ViewModels.Components.DialogResults;
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
        private const string FirstMessage = "始めの一枚目のプリントはテスト用紙を使用してください。\n出力用紙設定が はがきになっていることを確認してください。\nOKボタンを押すことで印刷を実行します。";

        private const string SecondMessage = "印刷が成功した場合は「はがき」をプリンターにセットし\n再度印刷を実行してください。\nOKボタンを押すことで印刷を実行します。";

        private const string RetryPrintingMessage = "再度印刷を実行しますか？";

        private const string ExecuteSeqencePrintingMessage = "連続印刷を実行しますか？";

        private readonly IDialogService dialogService;

        private readonly PrintService printService;

        private string message;

        private string title = "プリントダイアログ";

        private FrameworkElement printElement;

        private double printMarginLeft;

        private double printMarginTop;

        private bool isPrintSeqenceRequest;

        private string executeButtonText;

        private bool isVisibleChangePrintingLocationHelperDialogShowButton;

        private bool isConfirmedPrinting;

        private bool isPrintExecuted;

        public PrintDialogViewModel(
            IDialogService dialogService,
            PrintService printService)
        {
            this.dialogService = dialogService;

            this.printService = printService;

            message = FirstMessage;

            executeButtonText = "OK";

            PrintCommand = new DelegateCommand(Print);

            CancelAndCloseDialogCommand = new DelegateCommand(CancelAndCloseDialog);

            ShowChangePrintingLocationHelperDialogCommand = new DelegateCommand(ShowChangePrintingLocationHelperDialog);
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

        public DelegateCommand CancelAndCloseDialogCommand { get; }

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

            if (Message == ExecuteSeqencePrintingMessage)
            {
                CloseAndExecuteSeqencePrinting();
            }

            if (!isConfirmedPrinting)
            {
                isConfirmedPrinting = printService.ConfirmPrinting();

                if (!isConfirmedPrinting)
                {
                    CancelAndCloseDialog();

                    return;
                }
            }

            printService.Print(printElement, printMarginLeft, printMarginTop);

            if (Message == FirstMessage)
            {
                Message = SecondMessage;

                IsVisibleChangePrintingLocationHelperDialogShowButton = true;

                return;
            }

            if (Message == SecondMessage)
            {
                isPrintExecuted = true;

                ExecuteButtonText = "はい";

                if (!isPrintSeqenceRequest)
                {
                    Message = RetryPrintingMessage;

                    return;
                }

                Message = ExecuteSeqencePrintingMessage;
            }
        }

        private void ShowChangePrintingLocationHelperDialog()
        {
            dialogService.ShowChangePrintingLocationHelperDialog();
        }

        private void CancelAndCloseDialog()
        {
            var dialogParameters = new DialogParameters();

            dialogParameters.Add("printDialogResult", isPrintExecuted ? PrintDialogResult.Done : PrintDialogResult.Cancel);

            RaiseRequestClose(new DialogResult(ButtonResult.None, dialogParameters));
        }

        private void CloseAndExecuteSeqencePrinting()
        {
            var dialogParameters = new DialogParameters();

            dialogParameters.Add("printDialogResult", PrintDialogResult.ExecuteSeqencePrinting);

            RaiseRequestClose(new DialogResult(ButtonResult.None, dialogParameters));
        }

        private void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }
    }
}
