using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Newtonsoft.Json;
using System;
using System.IO;
using TornTop.Model;
using TornTop.View;
using Windows.Storage;

namespace TornTop.View;

public sealed partial class MainWindow : Window {
	public MainWindow() {
		this.InitializeComponent();
		CheckKey();
	}

	private async void CheckKey() {
		if (File.Exists(ApplicationData.Current.RoamingFolder.Path + "/Settings.json")) {
			StorageFile settingsFile = await ApplicationData.Current.RoamingFolder.GetItemAsync("Settings.json") as StorageFile;

			string json = await FileIO.ReadTextAsync(settingsFile);
			Settings settings = JsonConvert.DeserializeObject<Settings>(json);

			if (settings != null && settings.ApiKey != null) {
				HomeButton.IsSelected = true;
			} else {
				SettingsButton.IsSelected = true;
			}
		} else {
			SettingsButton.IsSelected = true;
		}
	}

	private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args) {
		NavigationViewItem selectedItem = args.SelectedItem as NavigationViewItem;

		switch (selectedItem.Tag) {
			case "Home":
				NavigationFrame.Navigate(typeof(HomePage));
				NavigationViewHeaderText.Text = "Home";
				break;
			case "Items":
				NavigationFrame.Navigate(typeof(ItemsPage));
				NavigationViewHeaderText.Text = "Items";
				break;
			case "CityShops":
				NavigationFrame.Navigate(typeof(CityShopsPage));
				NavigationViewHeaderText.Text = "City Shops";
				break;
			case "Company":
				NavigationFrame.Navigate(typeof(CompanyPage));
				NavigationViewHeaderText.Text = "Company";
				break;
			case "Settings":
				NavigationFrame.Navigate(typeof(SettingsPage));
				NavigationViewHeaderText.Text = "Settings";
				break;
		}
	}
}