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
 **************************************************************************/

using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Proiect
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
            string mesaj = "A apărut o eroare în execuția programului.";

            // Poți diferenția pe tipul excepției, dacă vrei mesaje foarte specifice:
            if (e is PuncteIdenticeException)
            {
                mesaj += "\n\nTip eroare: Puncte identice.";
            }
            else if (e is PuncteColiniareException)
            {
                mesaj += "\n\nTip eroare: Puncte coliniare.";
            }
            else if (e is DrepteParaleleException)
            {
                mesaj += "\n\nTip eroare: Drepte paralele (fără intersecție).";
            }
            else
            {
                mesaj += $"\n\nTip eroare: {e.GetType().Name}";
            }

            // Informații detaliate pentru debug
            mesaj += $"\nMesaj: {e.Message}";
            mesaj += $"\nFuncție: {functie}";

            MessageBox.Show(mesaj, "Eroare critică", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
