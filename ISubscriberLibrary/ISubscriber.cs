using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Proiect
{
    /// <summary>
    /// Interfata implementeaza un 'contract' prin care urmaritorii vor primii notificaru cu privire la modificarile subiectului/obiectului observat
    /// </summary>
    public interface ISubscriber
    {
        void Update(Point p1, Point p2, Point p3, int numberOfPoints);
    }
}
