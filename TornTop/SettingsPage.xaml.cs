using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Newtonsoft.Json;
using System;
using TornTop.Model;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;

namespace TornTop;

public sealed partial class SettingsPage : Page {
	public SettingsPage() {
		this.InitializeComponent();
	}

	private async void Page_Loaded(object sender, RoutedEventArgs e) {
		try {
			string folderPath = ApplicationData.Current.RoamingFolder.Path;

			StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(folderPath);

			StorageFile settingsFile = await ApplicationData.Current.LocalFolder.GetItemAsync("Settings.json") as StorageFile;

			if (settingsFile != null) {
				string json = await FileIO.ReadTextAsync(settingsFile);
				var settings = JsonConvert.DeserializeObject<Settings>(json);
				ApiKeyTextBox.Text = settings == null ? "" : settings.ApiKey;
			}
		} catch (Exception ex) {
			var content = new ContentDialog {
				Title = "Error",
				Content = ex.Message,
				XamlRoot = this.Content.XamlRoot,
				CloseButtonText = "OK"
			};

			await content.ShowAsync();
		}
	}

	private async void SaveApiButton_Click(object sender, RoutedEventArgs e) {
		if (string.IsNullOrWhiteSpace(ApiKeyTextBox.Text)) {
			ContentDialog emptyDialog = new() {
				Title = "Field Empty",
				Content = "Please enter your API key first!",
				PrimaryButtonText = "OK",
				XamlRoot = this.Content.XamlRoot
			};

			await emptyDialog.ShowAsync();
			return;
		}

		var settings = new Settings { ApiKey = ApiKeyTextBox.Text.Trim() };
		string json = JsonConvert.SerializeObject(settings, Formatting.Indented);

		StorageFile settingsFile = await ApplicationData.Current.RoamingFolder.CreateFileAsync("Settings.json", CreationCollisionOption.ReplaceExisting);
		await FileIO.WriteTextAsync(settingsFile, json);

		ContentDialog dialog = new() {
			Title = "Saved!",
			Content = "API Key has been saved!",
			PrimaryButtonText = "OK",
			XamlRoot = this.Content.XamlRoot
		};

		await dialog.ShowAsync();
	}

	private void CopyApiButton_Click(object sender, RoutedEventArgs e) {
		DataPackage dataPackage = new();
		dataPackage.SetText(ApiKeyTextBox.Text.Trim());

		Clipboard.SetContent(dataPackage);
	}

	private async void DeleteApiButton_Click(object sender, RoutedEventArgs e) {
		var content = new ContentDialog {
			Title = "Not Implemented",
			Content = "So this is not implemented... come back in 173 years",
			XamlRoot = this.Content.XamlRoot,
			CloseButtonText = "OK"
		};

		await content.ShowAsync();
	}
}