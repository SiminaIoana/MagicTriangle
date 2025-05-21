using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;


namespace Proiect.Utils
{
    public static class ErrorHandler
    {
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
