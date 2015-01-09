using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PortalBrowser
{
	public class App : Application
	{
		public App ()
		{
            var page = new NavigationPage() { };
            MainPage = page;
            page.Navigation.PushAsync(new MainPage());
            // The root page of your application
            //MainPage = new PortalBrowser.MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
