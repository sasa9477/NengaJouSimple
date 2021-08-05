using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.ViewModels.Entities.Layouts
{
    public class PostalCodeTextLayoutViewModel
    {
        public PostalCodeTextLayoutViewModel()
        {
            MailWard = string.Empty;
            TownWard = string.Empty;
            Position = new PositionViewModel();
            Font = new FontViewModel();
        }

        public string MailWard { get; set; }

        public string TownWard { get; set; }

        public PositionViewModel Position { get; set; }

        public FontViewModel Font { get; set; }

        public double SpaceBetweenMailWardAndTownWard { get; set; }

        public double SpaceBetweenMailWardEachWard { get; set; }

        public double SpaceBetweenTownWardEachWard { get; set; }

    }
}
