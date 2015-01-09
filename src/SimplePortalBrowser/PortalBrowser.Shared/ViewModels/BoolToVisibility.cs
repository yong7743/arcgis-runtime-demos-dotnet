using System;

#if NETFX_CORE
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml;
#elif XAMARIN
using Xamarin.Forms;
#else
using System.Windows;
using System.Windows.Data;
#endif

namespace PortalBrowser.ViewModels
{
	public class BoolToVisibility : Common.BaseValueConverter
    {
        protected override object OnConvert(object value, Type targetType, object paramter, string language)
        {
			if (value is bool)
			{
				bool val = (bool)value;
#if XAMARIN
                return val;
#else
                return val ? Visibility.Visible : Visibility.Collapsed;
#endif
			}
			return value;
		}
        protected override object OnConvertBack(object value, Type targetType, object paramter, string language)
        {
			throw new NotImplementedException();
		}
	}
}
