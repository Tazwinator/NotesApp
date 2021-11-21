using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using NotesApp.Models;
using NotesApp.Services;
using System.Windows.Input;
using System.Threading.Tasks;
using NotesApp.Views;

namespace NotesApp.ViewModels
{
    class MainNotesViewModel : BindableObject
    {
        public MainNotesViewModel()
        {
            RefreshPage = new Command(Refresh);
            NewNote = new Command(LoadNoteEditor);

            Refresh();
        }

        public ICommand RefreshPage { get; set; }
        public ICommand NewNote { get; set; }


        private NotesCollection userNotes = new NotesCollection();
        public NotesCollection UserNotes
        {
            get { return userNotes; }
            set
            {
                userNotes = value;
                OnPropertyChanged();
            }
        }

        public async void Refresh()
        {
            UserNotes.Clear();

            var notes = await NoteStoreService.GetNotes();
            foreach (var note in notes)
            {
                UserNotes.Add(note);
                System.Diagnostics.Debug.Write(note.Content);
            }
        }

        public async static void LoadNoteEditor(object item = null)
        {
            System.Diagnostics.Debug.Write(item);
            if (item == null)
            {          
                await Shell.Current.GoToAsync($"//EditNotePage?newNote=true");
                return;
            }
            Note note = item as Note;
            await Shell.Current.GoToAsync($"//EditNotePage?noteData={note.Id}");
            
            System.Diagnostics.Debug.Write(note.Id);
        }

    }
}
