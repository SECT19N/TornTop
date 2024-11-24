using LiveChartsCore;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.Themes;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Newtonsoft.Json;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using TornAPI;
using TornAPI.CompanyData;
using TornAPI.Enums;
using TornTop.Model;
using Windows.Storage;

namespace TornTop.View;

public sealed partial class CompanyPage : Page {
	Client Client { get; set; }
	Company Company { get; set; }
	List<ISeries> EmployeeEffectivenessSeries { get; set; }
	Axis[] YAxes { get; set; }

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
			Company = await Client.GetCompanyAsync(CompanySelections.Detailed | CompanySelections.Profile | CompanySelections.Employees);

			EmployeesListView.ItemsSource = Company.Employees.Values.OrderByDescending(e => e.Position);

			List<int> workingStatList = [], settledList = [], directorEducationList = [], addictionList = [], inactivityList = [], totalList = [];

			foreach (Employee employee in Company.Employees.Values) {
				workingStatList.Add(employee.Effectiveness.WorkingStats);
				settledList.Add(employee.Effectiveness.SettledIn);
				directorEducationList.Add(employee.Effectiveness.DirectorEducation);
				addictionList.Add(employee.Effectiveness.Addiction);
				inactivityList.Add(employee.Effectiveness.Inactivity);
				totalList.Add(employee.Effectiveness.Total);
			}

			IEnumerable<SolidColorPaint> paints = Enumerable.Range(0, Company.Employees.Count).Select(p => new SolidColorPaint(ColorPalletes.FluentDesign[p].AsSKColor()));

			EmployeeEffectivenessSeries = [
				new StackedColumnSeries<int> {
					Values = workingStatList,
					IgnoresBarPosition = true,
					XToolTipLabelFormatter = (point) => Company.Employees.Values.ElementAt(point.Index).Name,
					YToolTipLabelFormatter = (point) => $"Working Stats {Company.Employees.Values.ElementAt(point.Index).Effectiveness.WorkingStats}",
					DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45)),
					DataLabelsSize = 12,
					DataLabelsPosition = DataLabelsPosition.Middle,
				},
				new StackedColumnSeries<int> {
					Values = settledList,
					IgnoresBarPosition = true,
					XToolTipLabelFormatter = (point) => Company.Employees.Values.ElementAt(point.Index).Name,
				},
				new StackedColumnSeries<int> {
					Values = directorEducationList,
					IgnoresBarPosition = true,
					XToolTipLabelFormatter = (point) => Company.Employees.Values.ElementAt(point.Index).Name,
				},
				new StackedColumnSeries<int> {
					Values = addictionList,
					IgnoresBarPosition = true,
					XToolTipLabelFormatter = (point) => Company.Employees.Values.ElementAt(point.Index).Name,
				},
				new StackedColumnSeries<int> {
					Values = inactivityList,
					IgnoresBarPosition = true,
					XToolTipLabelFormatter = (point) => Company.Employees.Values.ElementAt(point.Index).Name,
				},
			];

			//EmployeeEffectivenessChart.Series = EmployeeEffectivenessSeries;

			SetBars();

			SetTextBlocks();
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

	void SetBars() {
		PopularityProgressBar.Value = Company.Detailed.Popularity;
		EffiecencyProgressBar.Value = Company.Detailed.Efficiency;
		EnvironmentProgressBar.Value = Company.Detailed.Environment;
	}

	void SetTextBlocks() {
		PopularityTextBlock.Text = Company.Detailed.Popularity.ToString();
		EffiecencyTextBlock.Text = Company.Detailed.Efficiency.ToString();
		EnvironmentTextBlock.Text = Company.Detailed.Environment.ToString();
	}

	private void EmployeesButton_Click(object sender, RoutedEventArgs e) {
		string url = "https://www.torn.com/companies.php?step=your&type=1#/option=employees";

		ProcessStartInfo processInfo = new() {
			FileName = url,
			UseShellExecute = true,
		};

		Process.Start(processInfo);
	}
}