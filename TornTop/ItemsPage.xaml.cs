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
using Windows.Storage;

namespace TornTop;

public sealed partial class ItemsPage : Page {
	public Client Client { get; set; }
	IEnumerable<TornAPI.TornData.Item> Items { get; set; }


	public ItemsPage() {
		this.InitializeComponent();
	}

	public static async Task<ItemsPage> CreateAsync() {
		ItemsPage instance = new();
		await instance.InitialiazeAsync();
		return instance;
	}

	private async Task InitialiazeAsync() {
		StorageFile settingsFile = await ApplicationData.Current.LocalFolder.GetItemAsync("Settings.json") as StorageFile;

		string json = await FileIO.ReadTextAsync(settingsFile);
		var settings = JsonConvert.DeserializeObject<Settings>(json);

		Client = new(settings.ApiKey);

		await GetDataAsync();
	}

	async Task GetDataAsync() {
		ItemsPageModel.Torn = await Client.GetTornAsync(TornSelections.Items);
	}

	private void OpenItemPageButton_Click(object sender, RoutedEventArgs e) {
		Button selectedButton = sender as Button;

		foreach (var item in ItemsPageModel.Torn.Items) {
			if (selectedButton.Tag == item.Value.Name) {
				string url = @$"https://www.torn.com/imarket.php#/p=shop&step=shop&type=&searchname={selectedButton.Tag.ToString().Replace(" ", "+")}";

				var processInfo = new ProcessStartInfo {
					FileName = url,
					UseShellExecute = true,
				};

				Process.Start(processInfo);
			}
		}
	}

	private void SearchItemTextBox_TextChanged(object sender, TextChangedEventArgs e) {
		Items = ItemsPageModel.Torn.Items.Values.Where(i => i.Name.Contains(SearchItemTextBox.Text.Trim(), StringComparison.CurrentCultureIgnoreCase));

		ItemsListView.ItemsSource = Items;
	}

	private async void Expander_Expanding(Expander sender, ExpanderExpandingEventArgs args) {
		try {
			StorageFile settingsFile = await ApplicationData.Current.LocalFolder.GetItemAsync("Settings.json") as StorageFile;

			string json = await FileIO.ReadTextAsync(settingsFile);
			var settings = JsonConvert.DeserializeObject<Settings>(json);

			Client = new(settings.ApiKey);

			var expander = sender as Expander;

			var item = expander.DataContext as TornAPI.TornData.Item;

			var masterList = ItemsPageModel.Torn.Items;

			var itemKey = masterList.FirstOrDefault(x => x.Value == item).Key;

			var grid = expander.Content as Grid;

			if (grid != null) {
				var bazaarPricesListView = FindChild<ListView>(grid, "BazaarPrices");
				var marketPricesListView = FindChild<ListView>(grid, "MarketPrices");

				if (bazaarPricesListView != null) {
					ItemsPageModel.Market = await Client.GetMarket(MarketSelections.Bazaar, itemKey);
					bazaarPricesListView.ItemsSource = ItemsPageModel.Market.BazaarItems.Take(3) ?? [];
				}

				if (marketPricesListView != null) {
					ItemsPageModel.Market = await Client.GetMarket(MarketSelections.ItemMarket, itemKey);
					marketPricesListView.ItemsSource = ItemsPageModel.Market.MarketItems.Take(3) ?? [];
				}
			}
		} catch (Exception ex) {
			var content = new ContentDialog {
				Title = "Error",
				Content = ex.Message,
				XamlRoot = this.Content.XamlRoot,
				CloseButtonText = "OK"
			};
		}
	}

	private T FindChild<T>(DependencyObject parent, string childName) where T : FrameworkElement {
		if (parent == null) {
			return null;
		}

		T foundChild = null;

		int childrenCount = VisualTreeHelper.GetChildrenCount(parent);

		for (int i = 0; i < childrenCount; i++) {
			var child = VisualTreeHelper.GetChild(parent, i);

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