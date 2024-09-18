using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using TornAPI;
using TornAPI.CompanyData;
using System;
using Newtonsoft.Json;
using System.Net.Http;
using TornTop.Model;
using Windows.Storage;
using System.Threading.Tasks;
using TornAPI.Enums;
using TornAPI.TornData;

namespace TornTop.View;

public sealed partial class CompanyPage : Page {
	Client Client { get; set; }
	Company Company { get; set; }

	public CompanyPage() {
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
			Company = await Client.GetCompanyAsync(CompanySelections.Applications);

			EmployeesListView.ItemsSource = Company.Employees.Values;
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
}