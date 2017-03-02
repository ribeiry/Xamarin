using RestComXamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RestComXamarin.ViewModels
{
    public class CatsViewModel : INotifyPropertyChanged
    {
        private bool Busy;
        public bool IsBusy
        {
            get
            {
                return Busy;
            }
            set
            {
                Busy = value;
                OnPropertyChanged();
                GetCatsCommand.ChangeCanExecute();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Cat> Cats { get; set; }
        public Command GetCatsCommand { get; set; } 

        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]
                                        string propertyName = null) => PropertyChanged?.Invoke(this,
                                            new PropertyChangedEventArgs(propertyName));

        public CatsViewModel()
        {
            Cats = new ObservableCollection<Cat>();
            GetCatsCommand = new Command(async () => await GetCats(), () => !IsBusy);
        }
        async Task GetCats()
        {
            if (!IsBusy)
            {
                Exception error = null;

                try
                {
                    IsBusy = true;
                    var Repositaro = new Repository();
                    var Items = await Repositaro.GetCats();

                    Cats.Clear();
                    foreach(var Cat in Items)
                    {
                        Cats.Add(Cat);
                    }
                }
                catch (Exception ex)
                {
                    error = ex;
                }
                finally
                {
                    if(error != null)
                    {
                        await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error", error.Message, "Ok");
                    }
                    IsBusy = false;
                }
            }

            return;
        }
    }
}
