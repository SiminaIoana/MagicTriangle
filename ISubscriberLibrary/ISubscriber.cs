/**************************************************************************
 *                                                                        *
 *  File:        ISubscriber.cs                                           *
 *  Copyright:   (c) 2025, Simina Rusu, Codrina Tăbușcă, Tudor Rotariu,   *
 *               Vasile Leșan                                             *
 *  E-mail:      simina-ioana.rusu@student.tuiasi.ro,                     *
 *               codrina-florentina.tabusca@student.tuiasi.ro,            *
 *               tudor-liviu.rotariu@student.tuiasi.ro                    *
 *               vasile.lesan@student.tuiasi.ro                           *
 *  Description: Defines an interface for subscribers in the              *
 *               Observer design pattern.                                 *
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
