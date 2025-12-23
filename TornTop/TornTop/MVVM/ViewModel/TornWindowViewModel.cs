using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using TornTop.MVVM.View;

namespace TornTop.MVVM.ViewModel;

internal partial class TornWindowViewModel : ObservableObject {
	private object _currentView = new DashboardPage();

	public object CurrentView {
		get => _currentView;
		set {
			if (_currentView != value) {
				_currentView = value;
				OnPropertyChanged(nameof(CurrentView));
			}
		}
	}

	public void NavigateTo(object view) {
		CurrentView = view;
	}
}