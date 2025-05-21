/**************************************************************************
 *                                                                        *
 *  File:        ErrorHandler.cs                                          *
 *  Copyright:   (c) 2025, Simina Rusu, Codrina Tăbușcă, Tudor Rotariu,   *
 *               Vasile Leșan                                             *
 *  E-mail:      simina-ioana.rusu@student.tuiasi.ro,                     *
 *               codrina-florentina.tabusca@student.tuiasi.ro,            *
 *               tudor-liviu.rotariu@student.tuiasi.ro                    *
 *               vasile.lesan@student.tuiasi.ro                           *
 *  Description: Utility class to display detailed error messages in a    *
 *               message box with caller info for easier debugging.       *
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
using System.Runtime.CompilerServices;
using System.Windows.Forms;


namespace Proiect.Utils
{
    public static class ErrorHandler
    {
        /// <summary>
        /// Afișează un mesaj de eroare detaliat într-o fereastră pop-up, incluzând informații despre excepția apărută și funcția apelantă.
        /// </summary>
        /// <param name="e">Excepția care a fost prinsă și conține detaliile erorii.</param>
        /// <param name="functie">Numele funcției din care a fost apelată metoda (populat automat).</param>
        public static void MesajEroare(Exception e, [CallerMemberName] string functie = "")
        {
            string mesaj = $"A apărut o eroare în execuția programului.";

            // informatii detaliate pentru debug
            mesaj += $"\n\nMesaj: {e.Message}";
            mesaj += $"\nTip: {e.GetType().Name}";
            mesaj += $"\nFuncție: {functie}";

            MessageBox.Show(mesaj, "Eroare critică", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
