using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using TornAPI;
using TornAPI.Enums;
using TornAPI.UserData;
using TornTop.Model;
using Windows.Storage;

namespace TornTop;

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

			User = await Client.GetUserAsync(UserSelections.Bars | UserSelections.Profile | UserSelections.Travel | UserSelections.Networth | UserSelections.BattleStats | UserSelections.Skills | UserSelections.Cooldowns);

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
}