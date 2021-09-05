using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengaJouSimple.ViewModels.Entities.Layouts
{
    public class PositionViewModel
    {
        public PositionViewModel()
        {
        }

        public PositionViewModel(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public override string ToString()
        {
            return $"{{X={X}, Y={Y}}}";
        }

        public PositionViewModel Clone()
        {
            return new PositionViewModel
            {
                X = X,
                Y = Y
            };
        }
    }
}
