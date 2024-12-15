using Microsoft.UI.Xaml.Data;
using System;

namespace TornTop.Model.Converters;

class TimeStampConverter : IValueConverter {
	public object Convert(object value, Type targetType, object parameter, string language) {
		return DateTimeOffset.FromUnixTimeSeconds(long.Parse(value.ToString())).ToString("g");
	}

	public object ConvertBack(object value, Type targetType, object parameter, string language) {
		throw new NotImplementedException();
	}
}