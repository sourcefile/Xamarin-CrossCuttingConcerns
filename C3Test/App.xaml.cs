using System;
using Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using C3Test.Configuration;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace C3Test
{
    public partial class App : Application
    {

        public static IContainer Container { get; private set; }
        public App()
        {
            InitializeComponent();

            Container = Bootstrap.Configure();
            MainPage = new NavigationPage(Bootstrap.GetFirstScreen());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
