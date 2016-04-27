using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tray
{
    class Program
    {
        private static void menuAboutClick(object sender, EventArgs e)
        {
            MessageBox.Show("About This Application");
        }

        private static void menuExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private static void IconDoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("The icon was double clicked");
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool isFirstInstance;
            using (Mutex mtx = new Mutex(true, "", out isFirstInstance))
            {
                if (isFirstInstance)
                {
                    NotifyIcon ni = new NotifyIcon()
                    {
                        ContextMenu = new ContextMenu(new MenuItem[] {
                            new MenuItem("Запустить", menuAboutClick),
                            new MenuItem("Остановить", menuAboutClick),
                            new MenuItem("Выход", menuExitClick)
                        }),
                        Icon = global::DOER.Gateway.Properties.Resources.tree,
                        Visible = true
                    };
                    ni.DoubleClick += IconDoubleClick;

                    Application.Run();
                    ni.Dispose();
                }
                else
                {
                    // The application is already running
                    // TODO: Display message box or change focus to existing application instance
                }
            }


            //Application.Run(new Form1());
        }
    }
}
