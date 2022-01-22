using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Copyright
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var data = new Model.CopyrightHolderData();
            var view = new View.CopyrightForm();
            var presenter = new Presenter.CopyrightPresenter(view, data);

            Application.Run(view);
        }
    }
}
