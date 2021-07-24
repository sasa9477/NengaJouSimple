using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Extensions
{
    public static class IDialogServiceExtensions
    {
        public static ButtonResult ShowInformationDialog(this IDialogService dialogService, string message)
        {
            var buttonResult = ButtonResult.None;

            dialogService.ShowDialog("AlertDialog", new DialogParameters($"Message={message}"), result =>
            {
                buttonResult = result.Result;
            });

            return buttonResult;
        }

        public static ButtonResult ShowConfirmDialog(this IDialogService dialogService, string message)
        {
            var buttonResult = ButtonResult.None;

            dialogService.ShowDialog("ConfirmDialog", new DialogParameters($"Message={message}"), result =>
            {
                buttonResult = result.Result;
            });

            return buttonResult;
        }
    }
}
