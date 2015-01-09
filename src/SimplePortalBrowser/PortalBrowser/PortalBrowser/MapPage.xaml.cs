using Esri.ArcGISRuntime.Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PortalBrowser
{
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
			InitializeComponent ();
            (BindingContext as ViewModels.MapVM).PortalItem = MainPage.SelectedPortalItem;
        }
	}
}
