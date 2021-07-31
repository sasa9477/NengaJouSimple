using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.ViewModels.Entities.Layouts
{
    public class PostalCodeTextLayoutViewModel : TextLayoutViewModel
    {
        public PostalCodeTextLayoutViewModel() : base()
        {
        }

        public double SpaceBetweenMainWardAndTownWard { get; set; }

        public double SpaceBetweenEachWard { get; set; }
    }
}
