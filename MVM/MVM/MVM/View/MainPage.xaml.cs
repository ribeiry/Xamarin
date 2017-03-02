using Xamarin.Forms;
using MVM.Model.Entities;
using MVM.View;

namespace MVM
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new StudentVM();
            lvStudents.ItemSelected += lvStudents_ItemSelected;


        }

        void lvStudents_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Student selectedStudent = (Student)e.SelectedItem;

            if(selectedStudent == null)
               return;
            Navigation.PushAsync(new EstudantePage(selectedStudent));
            lvStudents.SelectedItem = null;

        }
    }
}
