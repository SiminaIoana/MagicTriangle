using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    public class Distanta
    {

        private double CalculeazaDistanta(Point p1, Point p2)
        {
            if (p1 == p2)
            {
                throw new ArgumentException("Aceste puncte sunt identice");
            }
            else
            {
                double x1 = p1.X, x2 = p2.X;
                double y1 = p1.Y, y2 = p2.Y;
                double difX = Math.Pow((x1 - x2), 2);
                double difY = Math.Pow((y1 - y2), 2);
                return Math.Sqrt(difX + difY);
            }
        }
    }
}
