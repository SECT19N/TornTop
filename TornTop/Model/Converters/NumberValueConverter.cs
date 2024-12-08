using Microsoft.UI.Xaml.Data;
using System;

namespace TornTop.Model.Converters;

class NumberValueConverter : IValueConverter {
	public object Convert(object value, Type targetType, object parameter, string language) {
		string prefixText = parameter is null ? string.Empty : parameter.ToString();

		return $"{prefixText}{((IFormattable)value).ToString("N0", null)}";
	}

	public object ConvertBack(object value, Type targetType, object parameter, string language) {
		throw new NotImplementedException();
	}
}