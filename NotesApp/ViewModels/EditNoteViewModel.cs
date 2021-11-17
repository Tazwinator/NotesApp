using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using NotesApp.Models;
using NotesApp.Models.Files;
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

        //public NotesCollection UserNotes = new NotesCollection();

        public static Note currentNote = new Note();
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
            string fileName = $"{currentNote.Content.Substring(0, Math.Min(20, currentNote.Content.Length))}.txt";
            fileName.FullFilePath().CreateNoteFile(currentNote.Content);

            /*UserNotes.Add(new Note { Content = CurrentNoteText, Title = CurrentNoteTitle });
            foreach (var note in UserNotes)
            {
                System.Diagnostics.Debug.WriteLine(note.Content);
                System.Diagnostics.Debug.WriteLine(note.Title);
            }*/


        }
    }
}
