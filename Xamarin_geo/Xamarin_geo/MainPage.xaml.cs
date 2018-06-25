using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin_geo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            if (locator.IsGeolocationAvailable)
            {
                if (locator.IsGeolocationEnabled)
                {
                    if (!locator.IsListening)
                    {
                        await locator.StartListeningAsync(new TimeSpan(5), 20);
                    }

                locator.PositionChanged += (cambio, args) =>
                {
                    var loc = args.Position;
                    txtlat.Text = loc.Latitude.ToString();
                    txtlon.Text = loc.Longitude.ToString();
                };
                }
            }
        }
    }
}
