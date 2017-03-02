using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MVM.Model.Entities;
using Xamarin.Forms;

namespace MVM
{
    class StudentVM:ObservableBaseObject
    {
        
        public ObservableCollection<Student> Students { get; set; }
        bool isBusy = false;
        public Command LoadDirectoryCommand { get; set; }

        public bool IsBusy
        {
            get { return isBusy;  }

            set { isBusy = value; OnPropertyChanged(); }
        }

        public StudentVM()
        {
            Students = new ObservableCollection<Student>();
            isBusy = false;
            LoadDirectoryCommand = new Command((obj) => LoadDirectory());
        }

        
       async void LoadDirectory()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Task.Delay(3000);

                var loadedDirectory = StudentDirectoryService.LoadStudentDirectory();

                foreach(var student in loadedDirectory.Students)
                {
                    Students.Add(student);
                }
                IsBusy = true;
            }

        }
    }
}
