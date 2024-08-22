using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using TornAPI;
using TornAPI.Enums;
using TornAPI.UserData;
using Windows.Storage;

namespace TornTop;

public sealed partial class HomePage : Page {
	public Client Client { get; set; }

	public HomePage() {
		this.InitializeComponent();
	}

	public static async Task<HomePage> CreateAsync() {
		HomePage instance = new();
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
		HomePageModel.User = await Client.GetUserAsync(UserSelections.Skills | UserSelections.Bars | UserSelections.Networth | UserSelections.BattleStats);
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

class NetworthTextConverter : IValueConverter {
	public object Convert(object value, Type targetType, object parameter, string language) {
		return $"${((IFormattable)value).ToString("N0", null)}";
	}

	public object ConvertBack(object value, Type targetType, object parameter, string language) {
		throw new NotImplementedException();
	}
}