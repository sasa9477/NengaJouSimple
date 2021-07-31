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
        public TextLayout()
        {
            TextLayoutKind = TextLayoutKind.PostalCode;
            Position = new Position();
            Font = new Font();
        }

        public TextLayoutKind TextLayoutKind { get; set; }

        public Position Position { get; set; }

        public Font Font { get; set; }
    }
}
