using Esri.ArcGISRuntime.Portal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
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
            string json = "{\"basemapGalleryGroupQuery\":\"title:\\\"United States Basemaps\\\" AND owner:Esri_cy_US\",\"colorSetsGroupQuery\":\"title:\\\"Esri Colors\\\" AND owner:esri_en\",\"customBaseUrl\":\"maps.arcgis.com\",\"defaultBasemap\":{\"baseMapLayers\":[{\"url\":\"http://services.arcgisonline.com/ArcGIS/rest/services/World_Topo_Map/MapServer\",\"resourceInfo\":{\"currentVersion\":10.01,\"copyrightText\":\"Sources: Esri, DeLorme, NAVTEQ, TomTom, Intermap, AND, USGS, NRCAN, Kadaster NL, and the GIS User Community\",\"spatialReference\":{\"wkid\":102100},\"singleFusedMapCache\":true,\"tileInfo\":{\"rows\":256,\"cols\":256,\"dpi\":96,\"format\":\"JPEG\",\"compressionQuality\":90,\"origin\":{\"x\":-2.0037508342787E7,\"y\":2.0037508342787E7},\"spatialReference\":{\"wkid\":102100},\"lods\":[{\"level\":0,\"resolution\":156543.033928,\"scale\":5.91657527591555E8},{\"level\":1,\"resolution\":78271.5169639999,\"scale\":2.95828763795777E8},{\"level\":2,\"resolution\":39135.7584820001,\"scale\":1.47914381897889E8},{\"level\":3,\"resolution\":19567.8792409999,\"scale\":7.3957190948944E7},{\"level\":4,\"resolution\":9783.93962049996,\"scale\":3.6978595474472E7},{\"level\":5,\"resolution\":4891.96981024998,\"scale\":1.8489297737236E7},{\"level\":6,\"resolution\":2445.98490512499,\"scale\":9244648.868618},{\"level\":7,\"resolution\":1222.99245256249,\"scale\":4622324.434309},{\"level\":8,\"resolution\":611.49622628138,\"scale\":2311162.217155},{\"level\":9,\"resolution\":305.748113140558,\"scale\":1155581.108577},{\"level\":10,\"resolution\":152.874056570411,\"scale\":577790.554289},{\"level\":11,\"resolution\":76.4370282850732,\"scale\":288895.277144},{\"level\":12,\"resolution\":38.2185141425366,\"scale\":144447.638572},{\"level\":13,\"resolution\":19.1092570712683,\"scale\":72223.819286},{\"level\":14,\"resolution\":9.55462853563415,\"scale\":36111.909643},{\"level\":15,\"resolution\":4.77731426794937,\"scale\":18055.954822},{\"level\":16,\"resolution\":2.38865713397468,\"scale\":9027.977411},{\"level\":17,\"resolution\":1.19432856685505,\"scale\":4513.988705},{\"level\":18,\"resolution\":0.597164283559817,\"scale\":2256.994353},{\"level\":19,\"resolution\":0.298582141647617,\"scale\":1128.497176}]},\"fullExtent\":{\"xmin\":-2.00375070671618E7,\"ymin\":-1.99718688804086E7,\"xmax\":2.00375070671618E7,\"ymax\":1.99718688804086E7,\"spatialReference\":{\"wkid\":102100}},\"supportedImageFormatTypes\":\"PNG24,PNG,JPG,DIB,TIFF,EMF,PS,PDF,GIF,SVG,SVGZ,AI,BMP\",\"capabilities\":\"Map,Query,Data\"}}],\"title\":\"Topographic\"},\"defaultExtent\":{\"xmin\":-15000000,\"ymin\":2700000,\"xmax\":-6200000,\"ymax\":6500000,\"spatialReference\":{\"wkid\":102100}},\"description\":null,\"featuredGroups\":[{\"owner\":\"Federal_User_Community\",\"title\":\"National Maps for USA\"},{\"owner\":\"esri\",\"title\":\"Esri Maps and Data\"},{\"owner\":\"esri\",\"title\":\"Community Basemaps\"},{\"owner\":\"esri\",\"title\":\"Landsat Community\"},{\"owner\":\"esri_en\",\"title\":\"Web Application Templates\"},{\"owner\":\"ArcGISTeamLocalGov\",\"title\":\"ArcGIS for Local Government\"}],\"featuredItemsGroupQuery\":\"title:\\\"Featured Maps and Apps for United States\\\" AND owner:Esri_cy_US\",\"galleryTemplatesGroupQuery\":\"title:\\\"Gallery Templates\\\" AND owner:esri_en\",\"helpBase\":\"http://doc.arcgis.com/en/arcgis-online/\",\"helpMap\":{\"v\":\"1.0\",\"m\":{\"120000503\":\"administer/view-status.htm\",\"120000905\":\"administer/configure-open-data.htm\",\"120000897\":\"administer/configure-roles.htm\",\"120000468\":\"create-maps/configure-pop-ups.htm\",\"120000473\":\"create-maps/configure-time.htm\",\"120000470\":\"create-maps/change-symbols.htm\",\"120000464\":\"create-maps/make-your-first-map.htm\",\"120000467\":\"create-maps/add-layers.htm#FILE\",\"120000902\":\"share-maps/publish-features.htm\",\"120000900\":\"share-maps/review-addresses.htm\",\"120000923\":\"share-maps/share-maps.htm\",\"120000455\":\"share-maps/share-items.htm\",\"120000454\":\"share-maps/add-items.htm\",\"120000456\":\"share-maps/supported-items.htm\",\"120000899\":\"use-maps/take-maps-offline.htm\",\"120000516\":\"reference/troubleshoot.htm#WEB_STORAGE\",\"120000815\":\"reference/about-cityengine-web-viewer.htm\",\"120000814\":\"reference/faq.htm\",\"120000817\":\"reference/troubleshoot-cityengine-web-viewer.htm\",\"120000816\":\"reference/use-cityengine-web-viewer.htm\",\"120000461\":\"reference/videos.htm\",\"120000463\":\"reference/show-desktop-content.htm\",\"120000465\":\"reference/search.htm\",\"120000466\":\"reference/troubleshoot-account.htm\",\"120000469\":\"reference/shapefiles.htm\",\"120000592\":\"reference/manage-trial.htm\",\"120000471\":\"reference/kml.htm\",\"120000597\":\"reference/arcgis-server-services.htm\",\"120000966\":\"reference/scene-viewer-requirements.htm\",\"120000978\":\"reference/multifactor.htm\",\"120000980\":\"reference/profile.htm#MFA\",\"120000969\":\"share-maps/add-items.htm#REG_APP\",\"120000460\":\"index.html\"}},\"helperServices\":{\"geocode\":[{\"url\":\"https://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer\",\"northLat\":\"Ymax\",\"southLat\":\"Ymin\",\"eastLon\":\"Xmax\",\"westLon\":\"Xmin\"}],\"defaultElevationLayers\":[{\"url\":\"https://elevation3d.arcgis.com/arcgis/rest/services/WorldElevation3D/Terrain3D/ImageServer\",\"id\":\"globalElevation\",\"layerType\":\"ArcGISTiledElevationServiceLayer\"}],\"route\":{\"url\":\"https://route.arcgis.com/arcgis/rest/services/World/Route/NAServer/Route_World\"},\"geometry\":{\"url\":\"https://utility.arcgisonline.com/arcgis/rest/services/Geometry/GeometryServer\"},\"printTask\":{\"url\":\"https://utility.arcgisonline.com/arcgis/rest/services/Utilities/PrintingTools/GPServer/Export%20Web%20Map%20Task\"},\"closestFacility\":{\"url\":\"https://route.arcgis.com/arcgis/rest/services/World/ClosestFacility/NAServer/ClosestFacility_World\"},\"asyncClosestFacility\":{\"url\":\"https://logistics.arcgis.com/arcgis/rest/services/World/ClosestFacility/GPServer/FindClosestFacilities\"},\"traffic\":{\"url\":\"https://traffic.arcgis.com/arcgis/rest/services/World/Traffic/MapServer\"},\"serviceArea\":{\"url\":\"https://route.arcgis.com/arcgis/rest/services/World/ServiceAreas/NAServer/ServiceArea_World\"},\"asyncServiceArea\":{\"url\":\"https://logistics.arcgis.com/arcgis/rest/services/World/ServiceAreas/GPServer/GenerateServiceAreas\"},\"syncVRP\":{\"url\":\"https://logistics.arcgis.com/arcgis/rest/services/World/VehicleRoutingProblemSync/GPServer/EditVehicleRoutingProblem\"},\"asyncVRP\":{\"url\":\"https://logistics.arcgis.com/arcgis/rest/services/World/VehicleRoutingProblem/GPServer/SolveVehicleRoutingProblem\"},\"asyncLocationAllocation\":{\"url\":\"https://logistics.arcgis.com/arcgis/rest/services/World/LocationAllocation/GPServer\"},\"elevation\":{\"url\":\"https://elevation.arcgis.com/arcgis/rest/services/Tools/Elevation/GPServer\"},\"hydrology\":{\"url\":\"https://hydro.arcgis.com/arcgis/rest/services/Tools/Hydrology/GPServer\"},\"elevationSync\":{\"url\":\"https://elevation.arcgis.com/arcgis/rest/services/Tools/ElevationSync/GPServer\"},\"asyncRoute\":{\"url\":\"https://logistics.arcgis.com/arcgis/rest/services/World/Route/GPServer\"},\"geoenrichment\":{\"url\":\"https://geoenrich.arcgis.com/arcgis/rest/services/World/GeoenrichmentServer\"}},\"homePageFeaturedContent\":\"title:\\\"Featured Maps\\\" AND owner:Esri_cy_US\",\"homePageFeaturedContentCount\":12,\"httpPort\":80,\"httpsPort\":443,\"ipCntryCode\":\"US\",\"isPortal\":false,\"layerTemplatesGroupQuery\":\"title:\\\"Esri Layer Templates\\\" AND owner:esri_en\",\"name\":null,\"portalHostname\":\"www.arcgis.com\",\"portalMode\":\"multitenant\",\"portalName\":\"ArcGIS Online\",\"portalThumbnail\":null,\"rotatorPanels\":[{\"innerHTML\":\"<div><div class='item whiteTxt' style='background-image:url(CDN_SERVER/images/slide-1.jpg);display:block;' title='Create and Collaborate on Maps and Apps'><div class='contentWidth'><h1>Create and Collaborate on Maps and Apps<\\/h1><p>ArcGIS Online is a cloud-based, collaborative content management system for maps, apps, data, and other geographic information.<\\/p><a target='_blank' class='extralarge button green' href='/about/'>Learn More &raquo;<\\/a><\\/div><\\/div><\\/div>\"},{\"innerHTML\":\"<div><div class='item whiteTxt' style='background-image:url(CDN_SERVER/images/slide-2.jpg);display:block;' title='Your Maps, Your Way'><div class='contentWidth'><h1>Your Maps, Your Way<\\/h1><p>Create, store, and manage your own maps, apps, and data with a personal ArcGIS Online account.<\\/p><a target='_blank' class='extralarge button blue' href='/about/features.html'>Learn More &raquo;<\\/a><\\/div><\\/div><\\/div>\"},{\"innerHTML\":\"<div><div class='item whiteTxt' style='background-image:url(CDN_SERVER/images/slide-3.jpg);display:block;' title='The Geospatial Platform for Your Organization'> <div class='contentWidth'> <h1>The Geospatial Platform for Your Organization<\\/h1><p>Host your organization's geographic information in Esri's cloud with an ArcGIS Online subscription.<\\/p><a target='_blank' class='extralarge button green' href='/about/features.html#your-data-in-the-cloud'>Learn More &raquo;<\\/a><\\/div><\\/div><\\/div>\"},{\"innerHTML\":\"<div><div class='item whiteTxt' style='background-image:url(CDN_SERVER/images/slide-4.jpg);display:block;' title='Intelligent Web Maps'><div class='contentWidth'><h1>Intelligent Web Maps<\\/h1><p>Turn your data into information by creating content-rich, beautiful maps that tell your story.<\\/p><a class='extralarge button yellow' href='webmap/viewer.html?useExisting=1'>Get Started &raquo;<\\/a><\\/div><\\/div><\\/div>\"},{\"innerHTML\":\"<div><div class='item whiteTxt' style='background-image:url(CDN_SERVER/images/slide-5.jpg);display:block;' title='Any Map, Anywhere'><div class='contentWidth'><h1>Any Map, Anywhere<\\/h1><p>Whether in the board room, at your desk, or in in the field, access the same map on all your devices.<\\/p><a href='http://itunes.apple.com/us/app/arcgis/id379687930'><img src='CDN_SERVER/images/App_Store_Badge_en.png' alt='Download on the App Store'/><\\/a>&nbsp;&nbsp;&nbsp;<a href='http://play.google.com/store/apps/details?id=com.esri.android.client'><img src='http://www.android.com/images/brand/android_app_on_play_logo_small.png' alt='Android app on Google Play' /><\\/a><br/><br/><a href='http://www.windowsphone.com/en-US/apps/7cb003be-990a-e011-9264-00237de2db9e'><img src='CDN_SERVER/images/Download-en-Small.png' alt='Download for Windows Phone'/>&nbsp;&nbsp;&nbsp;<a href='http://www.amazon.com/gp/product/B007OWF3BI/ref=mas_pm_ArcGIS'><img class='badge esriLeadingMargin2' src='CDN_SERVER/images/amazon.png' alt='Available at Amazon Appstore for Android' /><\\/a><\\/a><\\/div><\\/div><\\/div>\"},{\"innerHTML\":\"<div><div class='item whiteTxt' style='background-image:url(CDN_SERVER/images/slide-6.jpg);display:block;' title='Develop Browser and Mobile Apps'><div class='contentWidth'><h1>Develop Browser and Mobile Apps<\\/h1><p>Build mapping applications with powerful APIs that work with your data.<\\/p><a target='_blank' class='extralarge button green' href='http://developers.arcgis.com'>Learn More &raquo;<\\/a><\\/div><\\/div><\\/div>\"}],\"staticImagesUrl\":\"http://static.arcgis.com/images\",\"stylesGroupQuery\":\"title:\\\"Esri Styles\\\" AND owner:esri_en\",\"supportsHostedServices\":true,\"supportsOAuth\":true,\"symbolSetsGroupQuery\":\"title:\\\"Esri Symbols\\\" AND owner:esri_en\",\"templatesGroupQuery\":\"title:\\\"Web Application Templates\\\" AND owner:esri_en\",\"thumbnail\":null}";
           // json = "{\"items\":[\"item1\",\"item2\"]}";
           //using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
           //{
           //    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(TestContract2));
           //    var result = (TestContract2)jsonSerializer.ReadObject(stream);
           //}

            
        }
        public void PortalItem_Tapped(object sender, ItemTappedEventArgs e)
        {
            SelectedPortalItem = (ArcGISPortalItem)e.Item;
            Navigation.PushAsync(new MapPage());
           
            
        }

        [DataContract]
        public class TestContract
        {
            [DataMember]
            public IEnumerable<string> items { get; set; }
        }
        [DataContract]
        public class TestContract2
        {   [DataMember(Name = "id", IsRequired = false)]
            public string Id { get; internal set; }

            [DataMember(Name = "access")]
            internal string AccessInternal { get; set; }

            [DataMember(Name = "allSSL", IsRequired = false)]
            public bool IsAllSSL { get; internal set; }

            [DataMember(Name = "basemapGalleryGroupQuery", IsRequired = false)]
            public string BasemapGalleryGroupQuery { get; internal set; }

            [DataMember(Name = "canListApps", IsRequired = false)]
            public bool CanListApps { get; internal set; }

            [DataMember(Name = "canListData", IsRequired = false)]
            public bool CanListData { get; internal set; }

            [DataMember(Name = "canListPreProvisionedItems", IsRequired = false)]
            public bool CanListPreProvisionedItems { get; internal set; }

           [DataMember(Name = "canProvisionDirectPurchase", IsRequired = false)]
            public bool CanProvisionDirectPurchase { get; internal set; }

            [DataMember(Name = "canSearchPublic", IsRequired = false)]
            public bool CanSearchPublic { get; internal set; }

            [DataMember(Name = "canSharePublic", IsRequired = false)]
            public bool CanSharePublic { get; internal set; }

            [DataMember(Name = "canSignInArcGIS", IsRequired = false)]
            public bool CanSignInArcGIS { get; internal set; }

            [DataMember(Name = "canSignInIDP", IsRequired = false)]
            public bool CanSignInIdp { get; internal set; }

            [DataMember(Name = "colorSetsGroupQuery", IsRequired = false)]
            public string ColorSetsGroupQuery { get; internal set; }

            [DataMember(Name = "commentsEnabled", IsRequired = false)]
            public bool IsCommentsEnabled { get; internal set; }

            [DataMember(Name = "created", IsRequired = false)]
            internal double Created { get; set; }

           [DataMember(Name = "culture", IsRequired = false)]
            public string Culture { get; internal set; }

            [DataMember(Name = "customBaseUrl", IsRequired = false)]
            public string CustomBaseUrl { get; internal set; }

            /// <summary>
            /// Gets the default basemap to be used by the client application for the specified culture when creating new maps.
            /// </summary>
           [DataMember(Name = "defaultBasemap", IsRequired = false)]
           public Esri.ArcGISRuntime.WebMap.Basemap DefaultBasemap { get; internal set; }
           //
           ////The default extent to be used by the client application for the specified culture when creating new maps (if applicable).
           //[DataMember(Name = "defaultExtent", IsRequired = false)]
           //internal ExtentInfo ExtentInfo { get; set; }

            /// <summary>
            /// Gets the description of the organization.
            /// In the case of non-organizational users of ArcGIS Online or a multi-tenant portal, this will be null.
            /// </summary>
            [DataMember(Name = "description")]
            public string Description { get; internal set; }

            /// <summary>
            /// Gets the featured groups to possibly display on the group page or to feature for an organization.
            /// </summary>
            /// <remarks>This property returns an enumeration of <see cref="GroupInfo"/> that provide access to the owner and title for each featured group.
            /// To get the enumeration of <see cref="ArcGISPortalGroup"/>, you can use the method <see cref="GetFeaturedGroupsAsync()"/></remarks>
            /// <seealso cref="GetFeaturedGroupsAsync()"/>
            [DataMember(Name = "featuredGroups", IsRequired = false)]
            public GroupInfo[] FeaturedGroups { get; internal set; }

            /// <summary>
            /// Gets the query used to determine which group should drive the gallery of featured items displayed in the client application for the specified culture.
            /// The query specified in this setting should be used as the query string parameter for a call to the groups.
            /// The first group returned should be selected.
            /// If the selected group has a null featuredItemsId property then the client should display the items that are shared with the group.
            /// If the featuredItemsId is non-null then the client should display the items that are related to the featured items item 
            /// </summary>
            /// <seealso cref="SearchFeaturedItemsAsync()"/>
            [DataMember(Name = "featuredItemsGroupQuery", IsRequired = false)]
            public string FeaturedItemsGroupQuery { get; internal set; }

            /// <summary>
            /// Gets the query used to determine which group should drive the featured content displayed on the home page of client application for the specified culture.
            /// The query specified in this setting should be used as the query string parameter for a call to the groups.
            /// The first group returned should be selected, and those items shared with the group should be displayed in the home page gallery. 
            /// Ex: "title:'Featured Maps' AND owner:esri" 
            /// For a logged in user who is part of an organization this property will always be set from the account properties and will be null if not set by the organizational account administrators. 
            /// </summary>
            /// <value>
            /// The featured content of the home page.
            /// </value>
            /// <seealso cref="SearchHomePageFeaturedContentAsync()"/>
            [DataMember(Name = "homePageFeaturedContent", IsRequired = false)]
            public string HomePageFeaturedContent { get; internal set; }

            /// <summary>
            /// Gets the number of items to show per page for the featured content screens (max=100).
            /// </summary>
            [DataMember(Name = "homePageFeaturedContentCount", IsRequired = false)]
            public int HomePageFeaturedContentCount { get; internal set; }

            /// <summary>
            /// Gets the port used by the portal for HTTP communication
            /// </summary>
            [DataMember(Name = "httpPort", IsRequired = false)]
            public int HttpPort { get; internal set; }

            /// <summary>
            /// Gets the port used by the portal for HTTPS communication
            /// </summary>
            [DataMember(Name = "httpsPort", IsRequired = false)]
            public int HttpsPort { get; internal set; }

            /// <summary>
            /// Gets the query used to determine which group should drive the list of layer templates in map viewers for a given culture.
            /// The query specified in this setting should be used as the query string parameter for a call to the groups.
            /// The first group returned should be selected. 
            /// Ex: "title:'Esri Layer Templates' AND owner:esri" 
            /// </summary>
            [DataMember(Name = "layerTemplatesGroupQuery", IsRequired = false)]
            public string LayerTemplatesGroupQuery { get; internal set; }

            [DataMember(Name = "modified", IsRequired = false)]
            internal double Modified { get; set; }

            /// <summary>
            /// Gets the name of the organization.
            /// In the case of non-organizational users of ArcGIS Online or a multi-tenant portal, this will be null 
            /// </summary>
            [DataMember(Name = "name")]
            public string Name { get; internal set; }

            /// <summary>
            /// Gets the portal hostname.
            /// </summary>
            [DataMember(Name = "portalHostname", IsRequired = false)]
            public string PortalHostname { get; internal set; }

            [DataMember(Name = "portalMode")]
            internal string PortalModeInternal { get; set; }

            /// <summary>
            /// Gets the name of the portal.
            /// In the case of organization subscriptions within multi-tenant portals, name and portalName wil be different.
            /// In the case of single-tenant Portals, name and portalName will be logically the same. 
            /// </summary>
            /// <value>
            /// The name of the portal.
            /// </value>
            [DataMember(Name = "portalName")]
            public string PortalName { get; internal set; }

            /// <summary>
            /// Gets the background image path.
            /// </summary>
            [DataMember(Name = "backgroundImage", IsRequired = false)]
            internal string BackgroundImagePath { get; set; }

            /// <summary>
            /// Gets the portal thumbnail path.
            /// In the case of multi-tenant Portals portalThumbnail and thumbnail will be different for organizational users.
            /// In the case of single-tenant Portals they will be logically the same.
            /// </summary>
            [DataMember(Name = "portalThumbnail", IsRequired = false)]
            internal string PortalThumbnailPath { get; set; }

            /// <summary>
            /// Gets the query used to determine which group should drive the symbol sets in map viewers for a given culture.
            /// The query specified in this setting should be used as the query string parameter for a call to the groups.
            /// The first group returned should be selected, and those items shared with the group should be displayed as symbol sets. 
            /// Ex: "title:'Esri Symbols' AND owner:esri" 
            /// </summary>
            [DataMember(Name = "symbolSetsGroupQuery", IsRequired = false)]
            public string SymbolSetsGroupQuery { get; internal set; }

            /// <summary>
            /// Gets the query used to determine which group should drive the gallery of web application templates displayed in the client application for the specified culture.
            /// The query specified in this setting should be used as the query string parameter for a call to the groups.
            /// The first group returned should be selected, and those items shared with the group should be displayed in the client’s web application template gallery (if applicable). 
            /// Ex: "title:'ESRI Featured Content' AND owner:esri_webapi" 
            /// </summary>
            [DataMember(Name = "templatesGroupQuery", IsRequired = false)]
            public string TemplatesGroupQuery { get; internal set; }

            /// <summary>
            /// Gets the URL key of the organization.
            /// </summary>
            [DataMember(Name = "urlKey", IsRequired = false)]
            public string UrlKey { get; internal set; }

            /// <summary>
            /// Gets the thumbnail image path for the organization.
            /// In the case of non-organizational users of ArcGIS Online or a multi-tenant portal, this will be null. 
            /// </summary>
            [DataMember(Name = "thumbnail", IsRequired = false)]
            internal string ThumbnailPath { get; set; }

            /// <summary>
            /// Gets various services needed by clients.
            /// </summary>
            [DataMember(Name = "helperServices", IsRequired = false)]
            public HelperServices HelperServices { get; internal set; }

            /// <summary>
            /// Gets the ISO Country Code of IP address of client (Online only - Not used in Portal). 
            /// </summary>
            /// <remarks>
            /// Returns '--' or Null if IP cannot be located. 
            /// </remarks>
            [DataMember(Name = "ipCntryCode", IsRequired = false)]
            public string IPCountryCode { get; internal set; }

            /// <summary>
            /// Gets the bing key to use for webmaps using Bing. 
            /// </summary>
            [DataMember(Name = "bingKey", IsRequired = false)]
            public string BingKey { get; internal set; }

            /// <summary>
            /// Gets the a flag indicating whether the bing key can be shared to the public and will be returned as part of a <see cref="ArcGISPortalInfo"/> description.
            /// This requires the 'access' of the portal/org to be set to 'public'.
            /// The CanShareBingPublic property is not returned publicly but only shown to users within the organization. 
            /// </summary>
            [DataMember(Name = "canShareBingPublic", IsRequired = false)]
            public bool? CanShareBingPublic { get; internal set; }

            /// <summary>
            /// Gets a value indicating whether the portal supports OAuth.
            /// </summary>
            [DataMember(Name = "supportsOAuth", IsRequired = false)]
            public bool SupportsOAuth { get; internal set; }

            /// <summary>
            /// Gets a value indicating whether hosted services are supported.
            /// </summary>
            [DataMember(Name = "supportsHostedServices", IsRequired = false)]
            public bool SupportsHostedServices { get; internal set; }

            /// <summary>
            /// Gets a value indicating whether the portal is on premises.
            /// </summary>
            [DataMember(Name = "isPortal", IsRequired = false)]
            public bool IsPortal { get; internal set; }

            /// <summary>
            /// Gets the maximum validity in minutes of tokens issued for users of the organization. -1 is the default and is a special value that indicates infinite timeout or permanent tokens.
            /// For tokens granted using OAuth2 authorization grant, it represents the maximum validity of refresh tokens.
            /// For access tokens, the maximum validity is the lower of two weeks or this value.
            /// </summary>
            [DataMember(Name = "maxTokenExpirationMinutes", IsRequired = false)]
            public int MaxTokenExpiration { get; internal set; }

            /// <summary>
            /// Gets the region for the organization.
            /// </summary>
            [DataMember(Name = "region", IsRequired = false)]
            public string Region { get; internal set; }

            [DataMember(Name = "units", IsRequired = false)]
            internal string UnitsInternal { get; set; }

            /// <summary>
            /// Gets a value indicating whether only simple where clauses that are complaint with SQL92 can be used when querying layers and tables.
            /// The recommended security setting is true.
            /// </summary>
            /// <value>
            /// <c>true</c> if only simple where clauses that are complaint with SQL92 can be used; otherwise, <c>false</c>.
            /// </value>
            [DataMember(Name = "useStandardizedQuery", IsRequired = false)]
            public bool UseStandardizedQuery { get; internal set; }     // Getting user here avoids a new query on community/self for getting CurrentUser

            [DataMember(Name = "user", IsRequired = false)]
            internal ArcGISPortalUser User { get; set; }
        }
	}
}
