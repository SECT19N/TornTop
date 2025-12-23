using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using TornTop.MVVM.ViewModel;

namespace TornTop.MVVM.View;

public sealed partial class TornWindow : Window {
	public TornWindow() {
		InitializeComponent();
		// MainNavigationView.DataContext = 
	}

	private void MainNavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args) {
		if (MainNavigationView.DataContext is TornWindowViewModel vm) {
			string? tag = args.SelectedItemContainer?.Tag?.ToString();

			switch (tag) {
				case "Dashboard":
					vm.NavigateTo(new DashboardPage());
					break;
				case "Market":
					vm.NavigateTo(new MarketPage());
					break;
			}
		}
    }
}