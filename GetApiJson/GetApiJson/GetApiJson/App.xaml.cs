using Xamarin.Forms;

namespace GetApiJson
{
    public partial class App : Application
    {
        private MainPage _mainpage;

        public App()
        {
            _mainpage = new MainPage();
            InitializeComponent();

            MainPage = _mainpage;
        }

        protected override void OnStart()
        {

            _mainpage.Load();
           
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
