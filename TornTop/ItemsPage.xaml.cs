using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TornAPI;
using TornAPI.Enums;
using TornAPI.MarketData;
using TornAPI.TornData;
using Windows.Storage;
using Item = TornAPI.TornData.Item;

namespace TornTop;

public sealed partial class ItemsPage : Page {
	Client Client { get; set; }
	Torn Torn { get; set; }
	Market Market { get; set; }

	public ItemsPage() {
		this.InitializeComponent();
	}

	private async void Page_Loaded(object sender, RoutedEventArgs e) {
		try {
			StorageFile settingsFile = await ApplicationData.Current.LocalFolder.GetItemAsync("Settings.json") as StorageFile;

			string json = await FileIO.ReadTextAsync(settingsFile);
			Settings settings = JsonConvert.DeserializeObject<Settings>(json);

			Client = new(settings.ApiKey);

			await GetDataAsync();
		} catch (Exception ex) {
			ContentDialog content = new() {
				Title = "Error",
				Content = ex.Message,
				XamlRoot = this.Content.XamlRoot,
				CloseButtonText = "OK"
			};

			await content.ShowAsync();
		}
	}

	async Task GetDataAsync() {
		Torn = await Client.GetTornAsync(TornSelections.Items);
		ItemsListView.ItemsSource = Torn.Items.Values;
	}

	private void OpenItemPageButton_Click(object sender, RoutedEventArgs e) {
		Button selectedButton = sender as Button;

		foreach (var item in Torn.Items) {
			if (selectedButton.Tag == item.Value.Name) {
				string url = $"https://www.torn.com/imarket.php#/p=shop&step=shop&type=&searchname={selectedButton.Tag.ToString().Replace(" ", "+")}";

				ProcessStartInfo processInfo = new() {
					FileName = url,
					UseShellExecute = true,
				};

				Process.Start(processInfo);
			}
		}
	}

	private void SearchItemTextBox_TextChanged(object sender, TextChangedEventArgs e) {
		ItemsListView.ItemsSource = Torn.Items.Values.Where(i => i.Name.Contains(SearchItemTextBox.Text.Trim(), StringComparison.CurrentCultureIgnoreCase));
	}

	private async void Expander_Expanding(Expander sender, ExpanderExpandingEventArgs args) {
		try {
			StorageFile settingsFile = await ApplicationData.Current.LocalFolder.GetItemAsync("Settings.json") as StorageFile;

			string json = await FileIO.ReadTextAsync(settingsFile);
			Settings settings = JsonConvert.DeserializeObject<Settings>(json);

			Client = new(settings.ApiKey);

			Item item = sender.DataContext as Item;

			int itemKey = Torn.Items.FirstOrDefault(x => x.Value == item).Key;

			Grid grid = sender.Content as Grid;

			if (grid != null) {
				if (FindChild<ListView>(grid, "BazaarPrices") != null) {
					Market = await Client.GetMarket(MarketSelections.Bazaar, itemKey);
					FindChild<ListView>(grid, "BazaarPrices").ItemsSource = Market.BazaarItems.Take(3) ?? [];
				}

				if (FindChild<ListView>(grid, "MarketPrices") != null) {
					Market = await Client.GetMarket(MarketSelections.ItemMarket, itemKey);
					FindChild<ListView>(grid, "MarketPrices").ItemsSource = Market.MarketItems.Take(3) ?? [];
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