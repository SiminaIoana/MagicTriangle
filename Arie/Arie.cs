using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Proiect
{
    public class Arie
    {

        public double Arie(Point p1, Point p2, Point p3)
        {
            double l1 = CalculeazaDistanta(p1, p2);
            double l2 = CalculeazaDistanta(p2, p3);
            double l3 = CalculeazaDistanta(p3, p1);

            double p = (l1 + l2 + l3) / 2;

            return Math.Sqrt(p * (p - l1) * (p - l2) * (p - l3));
        }

    }
}
