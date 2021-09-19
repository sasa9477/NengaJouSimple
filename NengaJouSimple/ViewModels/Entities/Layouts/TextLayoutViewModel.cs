using NengaJouSimple.Models;
using NengaJouSimple.Models.Layouts;
using NengaJouSimple.ViewModels.Entities.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace NengaJouSimple.ViewModels.Entities.Layouts
{
    public class TextLayoutViewModel
    {
        public TextLayoutViewModel()
        {
            Text = string.Empty;
            Position = new PositionViewModel();
        }

        public TextLayoutKind TextLayoutKind { get; set; }

        public string Text { get; set; }

        public PositionViewModel Position { get; set; }

        public double FontSize { get; set; }

        public AddressCardLayoutViewModel AddressCardLayout { get; set; }

        public TextLayoutViewModel Clone()
        {
            return new TextLayoutViewModel
            {
                TextLayoutKind = TextLayoutKind,
                Text = Text,
                Position = Position.Clone(),
                FontSize = FontSize,
                AddressCardLayout = AddressCardLayout.Clone()
            };
        }
    }
}
