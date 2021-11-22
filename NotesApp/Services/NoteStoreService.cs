using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using SQLite;
using NotesApp.Models;
using System.Threading.Tasks;

namespace NotesApp.Services
{
    static class NoteStoreService
    {

        readonly static string storeDirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NoteStorage");
        readonly static string storeFilePath = Path.Combine(storeDirPath, "_db.db");

        static SQLiteAsyncConnection _db;
        
        private static void dirCheck()
        {
            if (Directory.Exists(storeDirPath))
            {
                return;
            }

            Directory.CreateDirectory(storeDirPath);

            return;

        }

         public static async Task Init()
        {
            dirCheck();

            _db = new SQLiteAsyncConnection(storeFilePath);

            await _db.CreateTableAsync<Note>();

            Console.Write("Table Created!");

            return;
        }

        public static async Task AddNote(string noteText, string noteTitle, int Id = 0)
        {
            await Init();
            var dbNote = new Note
            {
                Content = noteText,
                Title = noteTitle,
                Id = Id
            };
            if (Id == 0)
            {
                await _db.InsertAsync(dbNote);
                Console.Write("Note added");
                return;
            }

            await _db.UpdateAsync(dbNote);

        }

        public static async Task RemoveNote(int id)
        {
            await Init();
            await _db.DeleteAsync<Note>(id);
            Console.Write("Note removed");
        }

        public static async Task<Note> GetNote(int id)
        {
            await Init();
            var query = _db.Table<Note>().Where(x => x.Id == id);
            Note note = await query.FirstAsync();
            return note;
        }

        public static async Task<IEnumerable<Note>> GetNotes()
        {
            await Init();

            var notes = await _db.Table<Note>().ToListAsync();

            return notes;

        }

    }
}
