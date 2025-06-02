/**************************************************************************
 *                                                                        *
 *  File:        CustomExceptions.cs                                      *
 *  Copyright:   (c) 2025, Simina Rusu, Codrina Tăbușcă, Tudor Rotariu,   *
 *               Vasile Leșan                                             *
 *  E-mail:      simina-ioana.rusu@student.tuiasi.ro,                     *
 *               codrina-florentina.tabusca@student.tuiasi.ro,            *
 *               tudor-liviu.rotariu@student.tuiasi.ro                    *
 *               vasile.lesan@student.tuiasi.ro                           *
 *  Description: Excepții personalizate pentru calcule geometrice          *
 *                                                                        *
 **************************************************************************/

using System;

namespace Proiect
{
    /// <summary>
    /// Aruncată atunci când două sau mai multe puncte date sunt identice.
    /// </summary>
    public class PuncteIdenticeException : Exception
    {
        public PuncteIdenticeException()
            : base("Două sau mai multe puncte sunt identice și nu se poate continua calculul.")
        { }

        public PuncteIdenticeException(string message)
            : base(message)
        { }

        public PuncteIdenticeException(string message, Exception inner)
            : base(message, inner)
        { }
    }

    /// <summary>
    /// Aruncată atunci când punctele unui triunghi sunt coliniare și nu există aria/cercul circumscriptibil.
    /// </summary>
    public class PuncteColiniareException : Exception
    {
        public PuncteColiniareException()
            : base("Punctele sunt coliniare; nu se poate calcula aria sau cercul circumscris.")
        { }

        public PuncteColiniareException(string message)
            : base(message)
        { }

        public PuncteColiniareException(string message, Exception inner)
            : base(message, inner)
        { }
    }

    /// <summary>
    /// Aruncată atunci când două drepte sunt paralele și nu au punct de intersecție.
    /// </summary>
    public class DrepteParaleleException : Exception
    {
        public DrepteParaleleException()
            : base("Cele două drepte sunt paralele și nu se intersectează.")
        { }

        public DrepteParaleleException(string message)
            : base(message)
        { }

        public DrepteParaleleException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}
