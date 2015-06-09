using Esri.ArcGISRuntime.Portal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PortalBrowser
{
    public partial class MainPage : TabbedPage
    {
        public static ArcGISPortalItem SelectedPortalItem { get; private set; }

        public MainPage()
        {
            InitializeComponent();
        }
        public void PortalItem_Tapped(object sender, ItemTappedEventArgs e)
        {
            SelectedPortalItem = (ArcGISPortalItem)e.Item;
            Navigation.PushAsync(new MapPage());                      
        }
	}
}
