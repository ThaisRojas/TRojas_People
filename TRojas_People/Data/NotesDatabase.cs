using SQLite;
using TRojas_People.Models;

namespace TRojas_People.Data
{
    public class NotesDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public NotesDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Persona>().Wait();
        }

        public Task<List<Persona>> GetNotesAsync()
        {
            return _database.Table<Persona>().ToListAsync();
        }

        public Task<int> SaveNoteAsync(Persona note)
        {
            if (note.Id != 0)
                return _database.UpdateAsync(note);
            else
                return _database.InsertAsync(note);
        }

        public Task<int> DeleteNoteAsync(Persona note)
        {
            return _database.DeleteAsync(note);
        }
    }
}

