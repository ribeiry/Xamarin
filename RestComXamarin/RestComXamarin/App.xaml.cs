using Xamarin.Forms;

namespace RestComXamarin
{
    public partial class App : Application
    {
        public App()
        {
            var content = new View.CatsPage();
            MainPage = new NavigationPage(content);
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
