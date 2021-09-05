using NengaJouSimple.Models.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace NengaJouSimple.Models.Layouts
{
    public class TextLayout : EntityBase
    {
        public TextLayoutKind TextLayoutKind { get; set; }

        public string Text { get; set; }

        public Position Position { get; set; }

        public double FontSize { get; set; }

        public AddressCard AddressCard { get; set; }
    }
}
