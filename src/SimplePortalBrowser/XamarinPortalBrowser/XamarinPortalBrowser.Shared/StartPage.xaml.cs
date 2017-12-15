
using Esri.ArcGISRuntime.Portal;
using PortalBrowser.ViewModels;
using System;
using Xamarin.Forms;

namespace XamarinPortalBrowser
{
    public partial class StartPage : TabbedPage
    {
        //public MapVM mapVM;
        public StartPage()
        {
            //mapVM = new MapVM();
            InitializeComponent();
            
           
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            MapVM mapVM = new MapVM();
           
            try
            {
                this.Navigation.PushAsync(new MapPage(mapVM));
                if (e.Item != null)
                    mapVM.PortalItem = e.Item as PortalItem;
            }
            catch (Exception ex)
            { }
            
        }
    }
}
