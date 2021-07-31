using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengaJouSimple.Models.Layouts
{
    public class Position
    {
        public Position()
        {
        }

        public Position(double x, double y)
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
    }
}
