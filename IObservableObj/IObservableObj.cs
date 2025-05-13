using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    /// <summary>
    /// Interfata pentru obiectele care vor fi 'observate' si despre care subscriberii vor primii informatii actualizate
    /// Folosita pentru a implementa design patternul Observer, fiind interfata subiectului observat
    /// </summary>
    public interface IObservableObj
    {
        /// <summary>
        /// functie de adaugare a unui subscriber in lista de urmaritori a obiectului observat
        /// </summary>
        /// <param name="subscriber"></param>
        void AddSubscriber(ISubscriber subscriber);

        /// <summary>
        /// Functie pentru stergerea din lista a unui urmaritor
        /// </summary>
        /// <param name="subscriber"></param>
        void RemoveSubscriber(ISubscriber subscriber);

        /// <summary>
        /// Functie pentru notificarea urmaritorilor cu referire la ceea ce s-a intamplat cu obiectul observat
        /// </summary>
        void Notify();

    }
}
