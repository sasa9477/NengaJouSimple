using System;
using System.Collections.Generic;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NengaJouSimple.Data.Devices
{
    public class Printer
    {
        private PrintDialog printDialog;

        public void PreparePrinting()
        {
            // ページメディアサイズの設定に時間がかかるため準備メソッドを用意
            printDialog = new PrintDialog();
            printDialog.PrintTicket.PageMediaSize = new PageMediaSize(PageMediaSizeName.JapanHagakiPostcard);
        }

        public bool Print(FrameworkElement element, double printMarginLeft, double printMarginTop)
        {
            // 再度インスタンスの設定が必要
            printDialog = new PrintDialog();
            printDialog.PrintTicket.PageMediaSize = new PageMediaSize(PageMediaSizeName.JapanHagakiPostcard);

            var visualBrush = new VisualBrush(element)
            {
                Transform = new TranslateTransform(printMarginLeft, printMarginTop),
            };

            var canvas = new Canvas
            {
                Width = printDialog.PrintableAreaWidth,
                Height = printDialog.PrintableAreaHeight,
                Background = visualBrush,
            };

            var isClickedPrintButton = printDialog.ShowDialog() ?? false;

            if (isClickedPrintButton)
            {
                printDialog.PrintVisual(canvas, "年賀状");
            }

            return isClickedPrintButton;
        }
    }
}
