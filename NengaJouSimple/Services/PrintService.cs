using NengaJouSimple.Data.Devices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NengaJouSimple.Services
{
    public class PrintService
    {
        private readonly Printer printer;

        public PrintService(Printer printer)
        {
            this.printer = printer;
        }

        public async Task PreparePrinting()
        {
            await printer.PreparePrinting();
        }

        public bool ConfirmPrinting()
        {
            return printer.ConfirmPrinting();
        }

        public void Print(FrameworkElement element, double printMarginLeft, double printMarginTop)
        {
            printer.Print(element, printMarginLeft, printMarginTop);
        }
    }
}
