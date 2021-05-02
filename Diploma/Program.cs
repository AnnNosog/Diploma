using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ChiefWorm());
            //Application.Run(new ReportForm());
            //Application.Run(new RegUserWorm());
            Application.Run(new InputForm());
            //Application.Run(new Worker1Form(10));
        }
    }
}
