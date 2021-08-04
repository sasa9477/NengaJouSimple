﻿using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NengaJouSimple.Extensions
{
    public static class IDialogServiceExtensions
    {
        public static ButtonResult ShowInformationDialog(this IDialogService dialogService, string message)
        {
            var buttonResult = ButtonResult.None;

            var dialogParameters = new DialogParameters();

            dialogParameters.Add("message", message);

            dialogService.ShowDialog("AlertDialog", dialogParameters, result =>
            {
                buttonResult = result.Result;
            });

            return buttonResult;
        }

        public static ButtonResult ShowConfirmDialog(this IDialogService dialogService, string message)
        {
            var buttonResult = ButtonResult.None;

            var dialogParameters = new DialogParameters();

            dialogParameters.Add("message", message);

            dialogService.ShowDialog("ConfirmDialog", dialogParameters, result =>
            {
                buttonResult = result.Result;
            });

            return buttonResult;
        }

        public static ButtonResult ShowPrintDialog(this IDialogService dialogService)
        {
            dialogService.ShowDialog("PrintDialog");

            return ButtonResult.None;
        }

        public static ButtonResult ShowChangePrintingLocationHelperDialog(this IDialogService dialogService)
        {
            var buttonResult = ButtonResult.None;

            dialogService.ShowDialog("ChangePrintingLocationHelperDialog", null, result =>
            {
                buttonResult = result.Result;
            });

            return buttonResult;
        }
    }
}
