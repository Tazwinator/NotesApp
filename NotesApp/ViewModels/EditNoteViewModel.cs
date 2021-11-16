using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using NotesApp.Models;
using NotesApp.Views;

namespace NotesApp.ViewModels
{
     class EditNoteViewModel : BindableObject
    {
        public EditNoteViewModel()
        {
            SaveNote = new Command(Save);
        }
        public ICommand SaveNote { get; }

        public NotesCollection UserNotes = new NotesCollection();

        public Note currentNote = new Note();
        public string CurrentNoteText
        {
            get => currentNote.Content;
            set
            {
                if (value == currentNote.Content)
                    return;
                currentNote.Content = value;
                OnPropertyChanged();
            }
        }


        void Save()
        {
            // TODO - BigT my boy, I'm so happy right now I've just managed to do this.
            // Off to go have a beer and play Halo. Now just make it so that it doesn't clog up in memory.
            // Or if you don't need to, the next step would be saving the notes to a file or memory. Good lad ;)
            string CurrentNoteTitle = CurrentNoteText.Substring(0, Math.Min(150, CurrentNoteText.Length));
            UserNotes.Add(new Note { Content = CurrentNoteText, Title = CurrentNoteTitle });
            foreach (var note in UserNotes)
            {
                System.Diagnostics.Debug.WriteLine(note.Content);
                System.Diagnostics.Debug.WriteLine(note.Title);
            }


        }
    }
}
