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

        public void PreparePrinting()
        {
            printer.PreparePrinting();
        }

        public bool Print(FrameworkElement element, double printMarginLeft, double printMarginTop)
        {
            return printer.Print(element, printMarginLeft, printMarginTop);
        }
    }
}
