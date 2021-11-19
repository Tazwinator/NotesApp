using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using NotesApp.Models;
using NotesApp.Services;

namespace NotesApp.ViewModels
{
    class MainNotesViewModel : BindableObject
    {
        public MainNotesViewModel()
        {

            DisplayNotes();

        }

        private NotesCollection userNotes = new NotesCollection();
        public NotesCollection UserNotes { get { return userNotes; } }

        async void DisplayNotes()
        {

            var notes = await NoteStoreService.GetNotes();
            foreach (var note in notes)
            {
                userNotes.Add(note);
            }
        }


    }
}
