using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using TornTop.MVVM.ViewModel;

namespace TornTop.MVVM.View;

public sealed partial class TornWindow : Window {
	public TornWindow() {
		InitializeComponent();
	}

	private void MainNavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args) {
		if (MainNavigationView.DataContext is TornWindowViewModel vm) {
			string? tag = args.SelectedItemContainer?.Tag?.ToString();

			switch (tag) {
				case "Dashboard":
					vm.NavigateTo(new DashboardPage(), tag);
					break;
				case "Chain":
					vm.NavigateTo(new ChainPage(), tag);
					break;
				case "Market":
					vm.NavigateTo(new MarketPage(), tag);
					break;
				case "Shops":
					vm.NavigateTo(new ShopsPage(), tag);
					break;
				case "Messages":
					vm.NavigateTo(new MessagesPage(), tag);
					break;
				case "Travel":
					vm.NavigateTo(new TravelPage(), tag);
					break;
				case "Faction":
					vm.NavigateTo(new FactionPage(), tag);
					break;
				case "Company":
					vm.NavigateTo(new CompanyPage(), tag);
					break;
				case "Calendar":
					vm.NavigateTo(new CalendarPage(), tag);
					break;
				default:
					break;
			}
		}
	}
}