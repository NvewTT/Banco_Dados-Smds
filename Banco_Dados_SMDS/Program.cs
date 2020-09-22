using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Banco_Dados_SMDS.View;

namespace Banco_Dados_SMDS
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Conect conect = new Conect();
            Principal principal = new Principal();
            if(conect.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Principal());
            }

            

            
        }
    }
}
