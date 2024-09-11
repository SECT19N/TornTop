using Microsoft.UI.Xaml;
using System;
using System.IO;
using Windows.Storage;
using TornTop.View;

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
		protected override async void OnLaunched(LaunchActivatedEventArgs args) {
			if (File.Exists(ApplicationData.Current.RoamingFolder.Path + @"\Settings.json") == false) {
				FileStream fileStream = new(ApplicationData.Current.RoamingFolder.Path + @"\Settings.json", FileMode.Create, FileAccess.Write, FileShare.ReadWrite, bufferSize: 4096, useAsync: true);
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
