using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Newtonsoft.Json;
using System;
using System.IO;
using Windows.Storage;

namespace TornTop;

public sealed partial class MainWindow : Window {
	public MainWindow() {
		this.InitializeComponent();
		CheckKey();
	}

	private async void CheckKey() {
		if (File.Exists(ApplicationData.Current.LocalFolder.Path + "/Settings.json")) {
			StorageFile settingsFile = await ApplicationData.Current.LocalFolder.GetItemAsync("Settings.json") as StorageFile;

			string json = await FileIO.ReadTextAsync(settingsFile);
			var settings = JsonConvert.DeserializeObject<Settings>(json);

			if (settings != null && settings.ApiKey != null) {
				HomeButton.IsSelected = true;
			} else {
				SettingsButton.IsSelected = true;
			}
		} else {
			SettingsButton.IsSelected = true;
		}
	}

	private async void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args) {
		NavigationViewItem selectedItem = args.SelectedItem as NavigationViewItem;

		switch (selectedItem.Tag) {
			case "Home":
				var homePage = await HomePage.CreateAsync();
				NavigationFrame.Navigate(typeof(HomePage), homePage);
				NavigationViewHeaderText.Text = "Home";
				break;
			case "Items":
				var itemsPage = await ItemsPage.CreateAsync();
				NavigationFrame.Navigate(typeof(ItemsPage), itemsPage);
				NavigationViewHeaderText.Text = "Items";
				break;
			case "Settings":
				var settingsPage = await SettingsPage.CreateAsync();
				NavigationFrame.Navigate(typeof(SettingsPage), settingsPage);
				NavigationViewHeaderText.Text = "Settings";
				break;
		}
	}
}