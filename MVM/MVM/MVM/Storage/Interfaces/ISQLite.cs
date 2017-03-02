using SQLite;

namespace MVM.Storage.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
