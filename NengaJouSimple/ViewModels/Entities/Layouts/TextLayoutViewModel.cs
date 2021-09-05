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

        public int Id { get; set; }

        public string Text { get; set; }

        public PositionViewModel Position { get; set; }

        public double FontSize { get; set; }

        public DateTime RegisterdDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        public TextLayoutViewModel Clone()
        {
            return new TextLayoutViewModel
            {
                Id = Id,
                Text = Text,
                Position = Position.Clone(),
                FontSize = FontSize,
                RegisterdDateTime = RegisterdDateTime,
                UpdatedDateTime = UpdatedDateTime
            };
        }
    }
}
