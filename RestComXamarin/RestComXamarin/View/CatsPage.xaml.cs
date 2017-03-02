using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RestComXamarin.View
{
    public partial class CatsPage : ContentPage
    {
        public CatsPage()
        {
            InitializeComponent();
            ListViewCats.ItemSelected += ListViewCats_ItemSelected;
        }

        private async void ListViewCats_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var SelectedCat = e.SelectedItem as Models.Cat;
            if(SelectedCat != null)
            {
                await Navigation.PushAsync(new View.DetailsPage(SelectedCat));
                ListViewCats.SelectedItem = null;
            }
        }
    }
}
