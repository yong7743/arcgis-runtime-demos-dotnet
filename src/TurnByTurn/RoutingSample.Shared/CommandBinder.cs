using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if __IOS__ || __ANDROID__
using Xamarin.Forms;
using Esri.ArcGISRuntime.Xamarin.Forms;
using DependencyObject = Xamarin.Forms.BindableObject;
using DependencyProperty = Xamarin.Forms.BindableProperty;
#elif NETFX_CORE
using Esri.ArcGISRuntime.UI;
using Windows.UI.Xaml;
#else
using Esri.ArcGISRuntime.UI;
using System.Windows;
#endif

namespace RoutingSample
{
	/// <summary>
	/// Binding helpers
	/// </summary>
	public class CommandBinder
	{
		/// <summary>
		/// This command binding allows you to set the extent on a mapView from your view-model through binding
		/// </summary>
		public static Envelope GetRequestView(DependencyObject obj)
		{
			return (Envelope)obj.GetValue(RequestViewProperty);
		}

		/// <summary>
		/// This command binding allows you to set the extent on a mapView from your view-model through binding
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="extent"></param>
		public static void SetRequestView(DependencyObject obj, Envelope extent)
		{
			obj.SetValue(RequestViewProperty, extent);
		}

        /// <summary>
        /// Identifies the ZoomTo Attached Property.
        /// </summary>
        public static readonly DependencyProperty RequestViewProperty =
#if __IOS__ || __ANDROID__
            DependencyProperty.CreateAttached("RequestView", typeof(Viewpoint), typeof(CommandBinder), null, BindingMode.OneWay, null,
                RequestViewPropertyChanged);
#else
            DependencyProperty.RegisterAttached("RequestView", typeof(Viewpoint), typeof(CommandBinder), new PropertyMetadata(null, RequestViewPropertyChanged));
#endif
        private static void RequestViewPropertyChanged(DependencyObject d,
#if __IOS__ || __ANDROID__
            object oldValue, object newValue)
        {
#else
            DependencyPropertyChangedEventArgs e)
		{
            var newValue = e.NewValue;
#endif
            if (d is MapView)
			{
				MapView mapView = d as MapView;
				if (newValue is Viewpoint)
				{
					mapView.SetViewpoint((Viewpoint)newValue);
				}
			}
		}
	}
}
