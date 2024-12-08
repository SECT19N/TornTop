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
using TornAPI.MarketData;
using TornAPI.TornData;
using TornTop.Model;
using Windows.Storage;
using System.Collections.Generic;
using Item = TornAPI.TornData.Item;

namespace TornTop.View;

public sealed partial class ItemsPage : Page {
	Client Client { get; set; }
	Torn Torn { get; set; }
	Market Market { get; set; }

	public ItemsPage() {
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
			Torn = await Client.GetTornAsync(TornSelections.Items);
			
			ItemsListView.ItemsSource = Torn.Items.Values;
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

	private void OpenItemPageButton_Click(object sender, RoutedEventArgs e) {
		Button selectedButton = sender as Button;

		foreach (KeyValuePair<int, Item> item in Torn.Items) {
			if (selectedButton.Tag.ToString() == item.Value.Name) {
				string url = $"https://www.torn.com/page.php?sid=ItemMarket#/market/view=search&itemID={item.Key}";

				ProcessStartInfo processInfo = new() {
					FileName = url,
					UseShellExecute = true,
				};

				Process.Start(processInfo);
			}
		}
	}

	private async void SearchItemTextBox_TextChanged(object sender, TextChangedEventArgs e) {
		if (Torn is null) {
			await GetDataAsync();
		}

		ItemsListView.ItemsSource = Torn.Items.Values.Where(i => i.Name.Contains(SearchItemTextBox.Text.Trim(), StringComparison.CurrentCultureIgnoreCase));
	}

	private void TextBlock_EffectiveViewportChanged(FrameworkElement sender, EffectiveViewportChangedEventArgs args) {
		TextBlock textBlock = sender as TextBlock;

		if (args.BringIntoViewDistanceX == 0 && args.BringIntoViewDistanceY == 0) {
			string itemKey = "N/A";

			if (textBlock.Tag is not null) {
				itemKey = Torn.Items.FirstOrDefault(i => i.Value.Name.Equals(textBlock.Tag.ToString())).Key.ToString();

				textBlock.Text = $"[ID: {itemKey}]";
			} else {
				textBlock.Text = $"[ID: {itemKey}]";
			}
		}
	}

	private async void Expander_Expanding(Expander sender, ExpanderExpandingEventArgs args) {
		try {
			StorageFile settingsFile = await ApplicationData.Current.RoamingFolder.GetItemAsync("Settings.json") as StorageFile;

			string json = await FileIO.ReadTextAsync(settingsFile);
			Settings settings = JsonConvert.DeserializeObject<Settings>(json);

			Client = new(settings.ApiKey);

			Item item = sender.DataContext as Item;

			int itemKey = Torn.Items.FirstOrDefault(x => x.Value == item).Key;

			StackPanel stackPanel = sender.Content as StackPanel;

			ListView bazaarPricesListView = FindChild<ListView>(stackPanel, "BazaarPrices");
			ListView marketPricesListView = FindChild<ListView>(stackPanel, "MarketPrices");

			if (stackPanel != null) {
				if (bazaarPricesListView != null) {
					Market = await Client.GetMarket(MarketSelections.Bazaar, itemKey);
					bazaarPricesListView.ItemsSource = Market.BazaarItems.Take(3) ?? [];
				}

				if (marketPricesListView != null) {
					Market = await Client.GetMarket(MarketSelections.ItemMarket, itemKey);
					marketPricesListView.ItemsSource = Market.MarketItems.Take(3) ?? [];
				}
			}
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