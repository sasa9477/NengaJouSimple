using System;
using System.Printing;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NengaJouSimple.Data.Devices
{
    public class Printer
    {
        private PrintDialog printDialog;

        private bool isInitializedPrinting;

        public Task PreparePrinting()
        {
            // ページメディアサイズの設定に時間がかかるため準備メソッドを用意
            
            printDialog = new PrintDialog();
            
            printDialog.PrintTicket.PageMediaSize = new PageMediaSize(PageMediaSizeName.JapanHagakiPostcard);

            return Task.CompletedTask;
        }

        public bool ConfirmPrinting()
        {
            // メインスレッドで FrameworkElementを VisualBrushに変換するため、再度インスタンスを作成する

            printDialog = new PrintDialog();
            
            printDialog.PrintTicket.PageMediaSize = new PageMediaSize(PageMediaSizeName.JapanHagakiPostcard);

            isInitializedPrinting = printDialog.ShowDialog() ?? false;

            return isInitializedPrinting;
        }

        public void Print(FrameworkElement printElement, double printMarginLeft, double printMarginTop)
        {
            if (!isInitializedPrinting)
            {
                throw new InvalidOperationException("Call ConfirmPrinting method, before call Print method.");
            }

            var visualBrush = new VisualBrush(printElement)
            {
                Transform = new TranslateTransform(printMarginLeft, printMarginTop),
            };

            var canvas = new Canvas
            {
                Width = printDialog.PrintableAreaWidth,
                Height = printDialog.PrintableAreaHeight,
                Background = visualBrush,
            };

            printDialog.PrintVisual(canvas, "年賀状");
        }
    }
}
