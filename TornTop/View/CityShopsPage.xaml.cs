using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TornAPI;
using TornAPI.Enums;
using TornAPI.TornData;
using TornTop.Model;
using Windows.Storage;

namespace TornTop.View;

public sealed partial class CityShopsPage : Page {
	Client Client { get; set; }
	Torn Torn { get; set; }

	public CityShopsPage() {
		this.InitializeComponent();
	}

	private async void Page_Loaded(object sender, RoutedEventArgs e) {
		try {
			StorageFile settingsFile = await ApplicationData.Current.RoamingFolder.GetItemAsync("Settings.json") as StorageFile;

			string json = await FileIO.ReadTextAsync(settingsFile);
			Settings settings = JsonConvert.DeserializeObject<Settings>(json);

			Client = new(settings.ApiKey);

			await GetDataAsync();
		} catch (HttpRequestException ex) {
			ContentDialog dialog = new() {
				Title = "Host Not Found",
				Content = "Can't connect to API Host, Message: " + ex.Message,
				XamlRoot = this.Content.XamlRoot,
				CloseButtonText = "OK"
			};

			await dialog.ShowAsync();
		} catch (Exception ex) {
			ContentDialog dialog = new() {
				Title = "Error",
				Content = ex.Message,
				XamlRoot = this.Content.XamlRoot,
				CloseButtonText = "OK"
			};

			await dialog.ShowAsync();
		}
	}

	async Task GetDataAsync() {
		try {
			Torn = await Client.GetTornAsync(TornSelections.CityShops);

			CityShopsListView.ItemsSource = Torn.CityShops.Values;
		} catch (HttpRequestException ex) {
			ContentDialog dialog = new() {
				Title = "Host Not Found",
				Content = "Can't connect to API Host, Message: " + ex.Message,
				XamlRoot = this.Content.XamlRoot,
				CloseButtonText = "OK"
			};

			await dialog.ShowAsync();
		} catch (Exception ex) {
			ContentDialog dialog = new() {
				Title = "Error",
				Content = ex.Message,
				XamlRoot = this.Content.XamlRoot,
				CloseButtonText = "OK"
			};

			await dialog.ShowAsync();
		}
	}

	private void OpenShopPageButton_Click(object sender, RoutedEventArgs e) {
		Button pressedButton = sender as Button;

		string shopUrl = pressedButton.Tag switch {
			"Big Al's Gun Shop" => "bigalgunshop.php",
			"Sally's Sweet Shop" => "shops.php?step=candy",
			"TC Clothing" => "shops.php?step=clothes",
			"Bits 'n' Bobs" => "shops.php?step=clothes",
			"the Jewelry Store" => "shops.php?step=jewelry",
			"the Super Store" => "shops.php?step=super",
			"Cyber Force" => "shops.php?step=cyberforce",
			"the Docks" => "shops.php?step=docks",
			"the Post Office" => "shops.php?step=postoffice",
			"the Pawn Shop" => "shops.php?step=pawnshop",
			"the Pharmacy" => "shops.php?step=pharmacy",
			"Nikeh Sports" => "shops.php?step=nikeh",
			"the Recycling Center" => "shops.php?step=recyclingcenter",
			"the Print Shop" => "shops.php?step=printstore",
			_ => "city.php",
		};

		shopUrl = "https://www.torn.com/" + shopUrl;

		ProcessStartInfo processInfo = new() {
			FileName = shopUrl,
			UseShellExecute = true
		};

		Process.Start(processInfo);
	}

	private async void Expander_Expanding(Expander sender, ExpanderExpandingEventArgs args) {
		try {
			StorageFile settingsFile = await ApplicationData.Current.RoamingFolder.GetItemAsync("Settings.json") as StorageFile;

			string json = await FileIO.ReadTextAsync(settingsFile);
			Settings settings = JsonConvert.DeserializeObject<Settings>(json);

			Client = new(settings.ApiKey);

			CityShop cityShop = sender.DataContext as CityShop;

			Grid grid = sender.Content as Grid;

			ListView child = FindChild<ListView>(grid, "ShopInventory");

			if (grid != null) {
				if (child != null) {
					Torn = await Client.GetTornAsync(TornSelections.CityShops);
					child.ItemsSource = Torn.CityShops.Values.FirstOrDefault(s => s.Name == cityShop.Name).Inventory.Values;
				}
			}
		} catch (Exception ex) {
			ContentDialog content = new() {
				Title = "Error",
				Content = ex.Message,
				XamlRoot = this.Content.XamlRoot,
				CloseButtonText = "OK"
			};
		}
	}

	private static T FindChild<T>(DependencyObject parent, string childName) where T : FrameworkElement {
		if (parent == null) {
			return null;
		}

		T foundChild = null;

		int childrenCount = VisualTreeHelper.GetChildrenCount(parent);

		for (int i = 0; i < childrenCount; i++) {
			DependencyObject child = VisualTreeHelper.GetChild(parent, i);

			T childElement = child as T;

			if (childElement != null && childElement.Name == childName) {
				foundChild = childElement;
				break;
			}

			foundChild = FindChild<T>(child, childName);

			if (foundChild != null) {
				break;
			}
		}

		return foundChild;
	}
}