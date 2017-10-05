using Android.App;
using Android.Widget;
using Android.OS;
using HockeyApp.Android;
using HockeyApp.Android.Metrics;

using TestLibrary;

using System.Security.Cryptography;

namespace MatXiTest.Droid
{
	[Activity(Label = "MatXiTest", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			CrashManager.Register(this, "59a2597b38d54127be846d91b1e5d6a4");
			MetricsManager.Register(Application, "59a2597b38d54127be846d91b1e5d6a4");

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.myButton);

            ECCurve curve = ECCurve.CreateFromValue("");

            Class1 cls = new Class1();

			button.Click += delegate { 
				button.Text = string.Format("{0} clicks!", count++);

				MetricsManager.TrackEvent("button_clicked");

				throw new System.Exception();
			};
		}
	}
}

