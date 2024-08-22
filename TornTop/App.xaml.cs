using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TornTop {
	/// <summary>
	/// Provides application-specific behavior to supplement the default Application class.
	/// </summary>
	public partial class App : Application {
		/// <summary>
		/// Initializes the singleton application object.  This is the first line of authored code
		/// executed, and as such is the logical equivalent of main() or WinMain().
		/// </summary>
		public App() {
			this.InitializeComponent();
		}

		/// <summary>
		/// Invoked when the application is launched.
		/// </summary>
		/// <param name="args">Details about the launch request and process.</param>
		protected override async void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args) {
			if (File.Exists(ApplicationData.Current.LocalFolder.Path + @"\Settings.json") == false) {
				var fileStream = new FileStream(ApplicationData.Current.LocalFolder.Path + @"\Settings.json", FileMode.Create, FileAccess.Write, FileShare.ReadWrite, bufferSize: 4096, useAsync: true);
				await fileStream.DisposeAsync();
				fileStream.Close();
			}

			m_window = new MainWindow {
				ExtendsContentIntoTitleBar = true
			};

			m_window.Activate();
		}

		private Window m_window;
	}
}
