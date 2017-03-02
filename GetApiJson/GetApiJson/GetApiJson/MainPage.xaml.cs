using GetApiJson.Services;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace GetApiJson
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Country> Countries { get; set; }
        private RestClient _client;
        public Command RefreshCommand { get; set; }
        public MainPage()
        {
            RefreshCommand = new Command(() => Load());
            Countries = new ObservableCollection<Country>();
            _client = new RestClient();
            InitializeComponent();
        }

        public async void Load()
        {
            var result =  await _client.GetCountries();

            Countries.Clear();

            foreach(var item in result)
            {
                Countries.Add(item);
            }
            IsBusy = false;
        }
    }
}
