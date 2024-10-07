using Microsoft.UI.Xaml.Data;
using System;

namespace TornTop.Model.Converters;

class StatusToColorConverter : IValueConverter {
	public object Convert(object value, Type targetType, object parameter, string language) {
		return value.ToString().ToLower() switch {
			"online" => "#6cad2b",
			"idle" => "#cccc32",
			"offline" => "#555",
			_ => "#555",
		};
	}

	public object ConvertBack(object value, Type targetType, object parameter, string language) {
		throw new NotImplementedException();
	}
}