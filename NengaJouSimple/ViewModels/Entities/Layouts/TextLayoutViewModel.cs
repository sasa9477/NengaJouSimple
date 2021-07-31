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
            Position = new PositionViewModel();
            Text = string.Empty;
            Font = new FontViewModel();
        }

        public int Id { get; set; }

        public PositionViewModel Position { get; set; }

        public string Text { get; set; }

        public FontViewModel Font { get; set; }
    }
}
