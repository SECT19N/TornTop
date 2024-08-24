using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using Newtonsoft.Json;
using System;
using TornAPI;
using TornAPI.Enums;
using Windows.Storage;

namespace TornTop;

public sealed partial class HomePage : Page {
	public Client Client { get; set; }

	public HomePage() {
		this.InitializeComponent();
	}

	async void GetDataAsync() {
		HomePageModel.User = await Client.GetUserAsync(UserSelections.Skills | UserSelections.Bars | UserSelections.Networth | UserSelections.BattleStats);
	}

	private async void Page_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e) {
		try {
			StorageFile settingsFile = await ApplicationData.Current.LocalFolder.GetItemAsync("Settings.json") as StorageFile;

			string json = await FileIO.ReadTextAsync(settingsFile);
			var settings = JsonConvert.DeserializeObject<Settings>(json);

			Client = new(settings.ApiKey);

			GetDataAsync();
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
}

class NetworthForegroundConverter : IValueConverter {
	public object Convert(object value, Type targetType, object parameter, string language) {
		return new SolidColorBrush(int.Parse(value.ToString()) < 0 ? ColorHelper.FromArgb(0xFF, 0xB3, 0x38, 0x2C) : ColorHelper.FromArgb(0xFF, 0x82, 0xC9, 0x1E));
	}

	public object ConvertBack(object value, Type targetType, object parameter, string language) {
		throw new NotImplementedException();
	}
}