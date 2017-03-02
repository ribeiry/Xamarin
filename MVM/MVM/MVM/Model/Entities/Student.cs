using MVM.Storage;

namespace MVM.Model.Entities
{
    public class Student: ObservableBaseObject,IKeyObject
    {
        private string nome;
        private string sobrenome;
        private string classe;
        private string numero;
        private double media;

        public string Key { get; set; }
        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
                OnPropertyChanged();
            }
        }

        public string Sobrenome
        {
            get
            {
                return sobrenome;
            }

            set
            {
                sobrenome = value;
                OnPropertyChanged();
            }
        }

        public string Classe
        {
            get
            {
                return classe;
            }

            set
            {
                classe = value;
                OnPropertyChanged();
            }
        }

        public string Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
                OnPropertyChanged();
            }
        }

        public double Media
        {
            get
            {
                return media;
            }

            set
            {
                media = value;
                OnPropertyChanged();
            }
        }
    }
}
