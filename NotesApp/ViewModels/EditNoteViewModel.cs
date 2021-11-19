using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using NotesApp.Models;
using NotesApp.Services;
using NotesApp.Views;
using System.Threading.Tasks;

namespace NotesApp.ViewModels
{
     class EditNoteViewModel : BindableObject
    {
        public EditNoteViewModel()
        {
            SaveNote = new Command(Save);
            DelNote = new Command(Delete);
        }
        public ICommand SaveNote { get; }
        public ICommand DelNote { get; }


        private static Note currentNote = new Note();
        public string CurrentNoteContent
        {
            get => currentNote.Content;
            set
            {
                if (value == currentNote.Content)
                    return;
                currentNote.Content = value;
                currentNote.Title = currentNote.Content.Substring(0, Math.Min(20, currentNote.Content.Length));
                OnPropertyChanged();
            }
        }

        public string CurrentNoteTitle
        {
            get => currentNote.Title;
        }

        async void Save()
        {
            System.Diagnostics.Debug.WriteLine(CurrentNoteContent, CurrentNoteTitle);
            await NoteStoreService.AddNote(CurrentNoteContent, CurrentNoteTitle);

        }

        void Delete()
        {
            System.Diagnostics.Debug.WriteLine(CurrentNoteContent, CurrentNoteTitle);
            //await NoteStoreService.;
        }
    }
}
