using System;
using CrossPlatformLogger.Logging;
using Xamarin.Forms;

namespace CrossPlatformLogger
{
    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            // TODO register in Dependency Container

            var logsDirectory = GetLogsDirectoryByPlatform();
            var loggerFactory = new FileLoggerFactory(logsDirectory);
            var logger = loggerFactory.Create<App>();
            logger.LogInfo("Hello");

			MainPage = new CrossPlatformLogger.MainPage();
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

        private static string GetLogsDirectoryByPlatform()
        {
            // customize for your needs
#if __ANDROID__
            var localStorage = Android.OS.Environment.ExternalStorageDirectory.ToString();
            return System.IO.Path.Combine(localStorage, "MyApp", "Logs");
#elif __IOS__
            var localStorage = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return System.IO.Path.Combine(localStorage, "..", "Library");
#else
            var localStorage = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            return System.IO.Path.Combine(localStorage, "MyApp");
#endif
        }
    }
}
