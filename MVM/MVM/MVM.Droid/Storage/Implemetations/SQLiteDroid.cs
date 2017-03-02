using MVM.Droid.Storage.Implemetations;
using MVM.Storage.Interfaces;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly:Dependency(typeof(SQLiteDroid))]
namespace MVM.Droid.Storage.Implemetations
{
    public class SQLiteDroid:ISQLite
    {
        public  SQLiteDroid()
        {
            
        }
        public SQLiteConnection GetConnection()
        {
            SQLitePCL.Batteries.Init();
            var SQLiteFileName = "TodoSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, SQLiteFileName);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}