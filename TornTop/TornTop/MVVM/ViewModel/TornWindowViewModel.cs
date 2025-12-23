using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using TornTop.MVVM.View;

namespace TornTop.MVVM.ViewModel;

internal partial class TornWindowViewModel : ObservableObject {
	private object _currentView = new DashboardPage();
	private string _viewName = "Dashboard";

	public object CurrentView {
		get => _currentView;
		set {
			if (_currentView != value) {
				_currentView = value;
				OnPropertyChanged(nameof(CurrentView));
			}
		}
	}

	public string ViewName {
		get => _viewName;
		set {
			if (_viewName != value) {
				_viewName = value;
				OnPropertyChanged(nameof(ViewName));
			}
		}
	}

	public void NavigateTo(object view, string viewName) {
		CurrentView = view;
		ViewName = viewName;

		Console.WriteLine(viewName);
		Debug.WriteLine(viewName);
	}
}