using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace TornTop.MVVM.View;

public sealed partial class DashboardBarControl : UserControl {
	public DashboardBarControl() {
		InitializeComponent();
	}

	public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
		nameof(Label),
		typeof(string),
		typeof(DashboardBarControl),
		new PropertyMetadata("Stats")
	);

	public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
		nameof(Icon),
		typeof(Symbol),
		typeof(DashboardBarControl),
		new PropertyMetadata(Symbol.Placeholder)
	);

	public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
		nameof(Value),
		typeof(double),
		typeof(DashboardBarControl),
		new PropertyMetadata(0.0)
	);

	public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register(
		nameof(Maximum),
		typeof(double),
		typeof(DashboardBarControl),
		new PropertyMetadata(0.0)
	);

	public static readonly DependencyProperty BarColorProperty = DependencyProperty.Register(
		nameof(BarColor),
		typeof(Brush),
		typeof(DashboardBarControl),
		new PropertyMetadata(null)
	);

	public string Label {
		get => (string)GetValue(LabelProperty);
		set => SetValue(LabelProperty, value);
	}

	public Symbol Icon {
		get => (Symbol)GetValue(IconProperty);
		set => SetValue(IconProperty, value);
	}

	public double Value {
		get => (double)GetValue(ValueProperty);
		set => SetValue(ValueProperty, value);
	}

	public double Maximum {
		get => (double)GetValue(MaximumProperty);
		set => SetValue(MaximumProperty, value);
	}

	public Brush BarColor {
		get => (Brush)GetValue(BarColorProperty);
		set => SetValue(BarColorProperty, value);
	}
}
