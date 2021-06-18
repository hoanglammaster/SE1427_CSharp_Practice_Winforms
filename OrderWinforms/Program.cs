using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OrderWinforms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static SearchForm searchForm;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            searchForm = new SearchForm();
            Application.Run(searchForm);
        }
    }
}
