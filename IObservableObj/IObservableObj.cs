/**************************************************************************
 *                                                                        *
 *  File:        IObservableObj.cs                                        *
 *  Copyright:   (c) 2025, Simina Rusu, Codrina Tăbușcă, Tudor Rotariu,   *
 *               Vasile Leșan                                             *
 *  E-mail:      simina-ioana.rusu@student.tuiasi.ro,                     *
 *               codrina-florentina.tabusca@student.tuiasi.ro,            *
 *               tudor-liviu.rotariu@student.tuiasi.ro                    *
 *               vasile.lesan@student.tuiasi.ro                           *
 *  Description: Defines an interface for observable objects in           *
 *               the Observer design pattern.                             *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

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
