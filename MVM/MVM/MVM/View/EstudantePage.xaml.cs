using MVM.Model.Entities;
using Xamarin.Forms;

namespace MVM.View
{
    public partial class EstudantePage : ContentPage
    {
        public EstudantePage(Student selectedStudent)
        {
            InitializeComponent();
            this.BindingContext = selectedStudent;

        }
    }
}
