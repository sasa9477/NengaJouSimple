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
            Font = new FontViewModel();
        }

        public string Text { get; set; }

        public PositionViewModel Position { get; set; }

        public FontViewModel Font { get; set; }
    }
}
