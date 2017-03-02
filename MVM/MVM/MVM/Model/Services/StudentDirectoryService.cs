using MVM.Model.Entities;
using System.Collections.ObjectModel;
using System;
using MVM.Storage;
using System.Linq;

namespace MVM
{
    class StudentDirectoryService
    {
        public static StudentDirectory LoadStudentDirectory()
        {
            DatabaseManager db = new DatabaseManager();
            ObservableCollection<Student> students = new ObservableCollection<Student>(db.GetAllItens<Student>());
            StudentDirectory studentDirectory = new StudentDirectory();

            if (students.Any())
            {
                studentDirectory.Students = students;
                return studentDirectory;
            }

            students = new ObservableCollection<Student>();

            string[] name = { "Jose", "Pedro", "Maria", "Felipe", "Ana", "Maria" };
            string[] sobrenome = {"Silva","Ribeiro","Santos","Garcia","Gonzalez" };

            Random rd = new Random(DateTime.Now.Millisecond);

            students = new ObservableCollection<Student>();

            for(int i=0; i< 20; i++)
            {
                Student estudante = new Student();
                estudante.Nome = name[rd.Next(0, 5)];
                estudante.Sobrenome = $"{sobrenome[rd.Next(0,5)]}{sobrenome[rd.Next(0, 5)] }";
                string classe = rd.Next(456, 458).ToString();
                estudante.Classe = classe;
                estudante.Numero = rd.Next(12384748, 32384748).ToString();
                estudante.Media = rd.Next(100, 1000) / 10;
                estudante.Key = estudante.Numero;

                students.Add(estudante);

                db.SaveValue<Student>(estudante);
            }

            studentDirectory.Students = students;
            return studentDirectory;
        }
    }
}
