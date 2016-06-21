using Esri.ArcGISRuntime.Mapping;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RoutingSample
{
	public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();

            // Set binding context to self for binding to Map property
            BindingContext = this;
        }

        private Map _map;

        /// <summary>
        /// Gets the Map rendered in the MapView
        /// </summary>
        public Map Map
        {
            get
            {
                if (_map == null)
                {
                    _map = new Map(Basemap.CreateTopographic());
                }
                return _map;
            }
        }
    }
}
