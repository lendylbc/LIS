using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lis.Monitoring.Manager.Dialos;

namespace Lis.Monitoring.Manager {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Startup startup = new Startup();

			LoginDialog loginDialog = new LoginDialog(startup.ApiController);

			loginDialog.ShowDialog();

			if(loginDialog.DialogResult == DialogResult.OK) {
				Application.Run(new MainForm(startup.ApiController, loginDialog.Member));
			} else {
				return;
			}			
		}
	}
}
