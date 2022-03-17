using MotusPloux.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotusPloux.Data
{
    public class WordDataBase
    {
        readonly SQLiteAsyncConnection database;

        public WordDataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Word>().Wait();
        }

        public Task<List<Word>> GetWordsAsync()
        {
            //Get all notes.
            return database.Table<Word>().ToListAsync();
        }

        public Task<Word> GetWordAsync(int id)
        {
            // Get a specific note.
            return database.Table<Word>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveWordAsync(Word word)
        {
            if (word.Id != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(word);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(word);
            }
        }

        public Task<int> DeleteWordAsync(Word word)
        {
            // Delete a note.
            return database.DeleteAsync(word);
        }
    }
}
