using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using TornAPI;
using TornAPI.Enums;
using TornAPI.UserData;
using TornTop.Model;
using Windows.Storage;
using System.Collections.Generic;

namespace TornTop.View;

public sealed partial class HomePage : Page {
	Client Client { get; set; }
	User User { get; set; }

	public HomePage() {
		this.InitializeComponent();
	}

	private async void Page_Loaded(object sender, RoutedEventArgs e) {
		try {
			StorageFile settingsFile = await ApplicationData.Current.RoamingFolder.GetItemAsync("Settings.json") as StorageFile;

			string json = await FileIO.ReadTextAsync(settingsFile);
			var settings = JsonConvert.DeserializeObject<Settings>(json);

			Client = new(settings.ApiKey);

			User = await Client.GetUserAsync(UserSelections.Bars | UserSelections.Messages | UserSelections.Profile | UserSelections.Travel | UserSelections.Networth | UserSelections.BattleStats | UserSelections.Skills | UserSelections.Cooldowns);

			MessagesListView.ItemsSource = User.Messages.Values.OrderByDescending(m => m.TimeStamp);

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
			var content = new ContentDialog {
				Title = "Error",
				Content = ex.Message,
				XamlRoot = this.Content.XamlRoot,
				CloseButtonText = "OK"
			};

			await content.ShowAsync();
		}
	}

	void SetBars() {
		EnergyBar.Value = User.Energy.Current;
		EnergyBar.Maximum = User.Energy.Maximum;
		CurrentEnergyTextBlock.Text = User.Energy.Current.ToString();
		MaxEnergyTextBlock.Text = User.Energy.Maximum.ToString();

		NerveBar.Value = User.Nerve.Current;
		NerveBar.Maximum = User.Nerve.Maximum;
		CurrentNerveTextBlock.Text = User.Nerve.Current.ToString();
		MaxNerveTextBlock.Text = User.Nerve.Maximum.ToString();

		HappyBar.Value = User.Happy.Current;
		HappyBar.Maximum = User.Happy.Maximum;
		CurrentHappyTextBlock.Text = User.Happy.Current.ToString();
		MaxHappyTextBlock.Text = User.Happy.Maximum.ToString();

		LifeBar.Value = User.Life.Current;
		LifeBar.Maximum = User.Life.Maximum;
		CurrentLifeTextBlock.Text = User.Life.Current.ToString();
		MaxLifeTextBlock.Text = User.Life.Maximum.ToString();

		TravelProgressBar.Maximum = User.Travel.ArrivalTime - User.Travel.Departed;
		TravelProgressBar.Value = User.Travel.ArrivalTime - User.Travel.Departed - User.Travel.TimeLeft;
		ArrivalTimeTextBlock.Text = User.Travel.TimeLeft == 0 ? "Landed" : $"Landing at {DateTime.Now.AddSeconds(User.Travel.TimeLeft):h:mm tt}";
		DestinationTextBlock.Text = User.Travel.Destination;
	}

	void SetTextBlocks() {
		StrengthTextBlock.Text = User.Strength.ToString();
		DefenseTextBlock.Text = User.Defense.ToString();
		SpeedTextBlock.Text = User.Speed.ToString();
		DexterityTextBlock.Text = User.Dexterity.ToString();

		RacingSkill.Text = User.Racing.ToString();
		RevivingSkill.Text = User.Reviving.ToString();
		HuntingSkill.Text = User.Hunting.ToString();

		SearchForCashSkill.Text = User.SearchForCash.ToString();
		BootleggingSkill.Text = User.Bootlegging.ToString();
		GraffitiSkill.Text = User.Graffiti.ToString();
		ShopliftingSkill.Text = User.Shoplifting.ToString();
		PickpocketSkill.Text = User.Pickpocket.ToString();
		CardSkimmingSkill.Text = User.CardSkimming.ToString();
		BurglarySkill.Text = User.Burglary.ToString();
		HustlingSkill.Text = User.Hustling.ToString();
		DisposalSkill.Text = User.Disposal.ToString();
		CrackingSkill.Text = User.Cracking.ToString();
		ForgerySkill.Text = User.Forgery.ToString();

		TotalNetworth.Text = "$" + User.Networth.Total.ToString("N0");

		PendingNetworth.Text = "$" + User.Networth.Pending.ToString("N0");
		WalletNetworth.Text = "$" + User.Networth.Wallet.ToString("N0");
		BankNetworth.Text = "$" + User.Networth.Bank.ToString("N0");
		PointsNetworth.Text = "$" + User.Networth.Points.ToString("N0");
		CaymanNetworth.Text = "$" + User.Networth.Cayman.ToString("N0");
		VaultNetworth.Text = "$" + User.Networth.Vault.ToString("N0");
		PiggyBankNetworth.Text = "$" + User.Networth.PiggyBank.ToString("N0");
		ItemsNetworth.Text = "$" + User.Networth.Items.ToString("N0");
		DisplayCaseNetworth.Text = "$" + User.Networth.DisplayCase.ToString("N0");
		BazaarNetworth.Text = "$" + User.Networth.Bazaar.ToString("N0");
		TradeNetworth.Text = "$" + User.Networth.Trade.ToString("N0");
		ItemMarketNetworth.Text = "$" + User.Networth.ItemMarket.ToString("N0");
		PropertiesNetworth.Text = "$" + User.Networth.Properties.ToString("N0");
		StockMarketNetworth.Text = "$" + User.Networth.StockMarket.ToString("N0");
		AuctionHouseNetworth.Text = "$" + User.Networth.AuctionHouse.ToString("N0");
		CompanyNetworth.Text = "$" + User.Networth.Company.ToString("N0");
		BookieNetworth.Text = "$" + User.Networth.Bookie.ToString("N0");
		EnlistedCarsNetworth.Text = "$" + User.Networth.EnlistedCars.ToString("N0");
		LoanNetworth.Text = "$" + User.Networth.Loan.ToString("N0");

		UnpaidFeesNetworth.Foreground = new SolidColorBrush(User.Networth.UnpaidFees < 0 ? ColorHelper.FromArgb(0xFF, 0xB3, 0x38, 0x2C) : ColorHelper.FromArgb(0xFF, 0x82, 0xC9, 0x1E));

		UnpaidFeesNetworth.Text = "$" + User.Networth.UnpaidFees.ToString("N0");
	}


	private void GymButton_Click(object sender, RoutedEventArgs e) {
		string url = "https://www.torn.com/gym.php";

		ProcessStartInfo processInfo = new() {
			FileName = url,
			UseShellExecute = true,
		};

		Process.Start(processInfo);
	}

	private void CrimesButton_Click(object sender, RoutedEventArgs e) {
		string url = "https://www.torn.com/loader.php?sid=crimes#/";

		ProcessStartInfo processInfo = new() {
			FileName = url,
			UseShellExecute = true,
		};

		Process.Start(processInfo);
	}

	private void TravelButton_Click(object sender, RoutedEventArgs e) {
		string url = User.Status.Color != "blue" ? "https://www.torn.com/travelagency.php" : "https://www.torn.com/index.php";

		ProcessStartInfo processInfo = new() {
			FileName = url,
			UseShellExecute = true,
		};

		Process.Start(processInfo);
	}

	private void OpenMessageButton_Click(object sender, RoutedEventArgs e) {
		Button selectedButton = sender as Button;

		foreach (KeyValuePair<string, Message> message in User.Messages) {
			if (selectedButton.Tag.ToString() == message.Value.TimeStamp.ToString()) {
				string url = $"https://www.torn.com/messages.php#/p=read&ID={message.Key}&suffix=inbox";

				ProcessStartInfo processInfo = new() {
					FileName = url,
					UseShellExecute = true,
				};

				Process.Start(processInfo);
			}
		}
	}

	private void MessageIcon_Loaded(object sender, RoutedEventArgs e) {
		FontIcon fontIcon = sender as FontIcon;

		foreach (KeyValuePair<string, Message> message in User.Messages) {
			if (fontIcon.Tag.ToString() == message.Value.TimeStamp.ToString()) {
				if (message.Value.Read == true) {
					fontIcon.Glyph = "\uEB4D";
				} else {
					fontIcon.Glyph = "\uEB4C";
				}
			}
		}
	}
}