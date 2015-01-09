using System;
using System.Globalization;
#if NETFX_CORE
using Windows.UI.Xaml.Data;
#elif XAMARIN
using Xamarin.Forms;
#else
using System.Windows.Data;
#endif

namespace PortalBrowser.Common
{
    /// <summary>
    /// Base converter class for handling converter differences between .NET and Windows Runtime
    /// </summary>
    public abstract class BaseValueConverter
#if !XAMARIN //TODO
        : IValueConverter
#endif
    {
#if NETFX_CORE
		object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
#elif XAMARIN
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
#else
		object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
#endif
        {
#if !NETFX_CORE
			string language = culture.TwoLetterISOLanguageName;
#endif
			return OnConvert(value, targetType, parameter, language);
		}

		protected abstract object OnConvert(object value, Type targetType, object paramter, string language);

#if NETFX_CORE
		object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
#elif XAMARIN
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
#else
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
#endif
        {
#if !NETFX_CORE
            string language = culture.TwoLetterISOLanguageName;
#endif
			return OnConvertBack(value, targetType, parameter, language);
		}

		protected abstract object OnConvertBack(object value, Type targetType, object paramter, string language);

    }
}
