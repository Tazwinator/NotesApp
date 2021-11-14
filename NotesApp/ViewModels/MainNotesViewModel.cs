using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using NotesApp.Models;

namespace NotesApp.ViewModels
{
    class MainNotesViewModel
    {
        public MainNotesViewModel()
        {

            DisplayNotes();

        }

        private NotesCollection userNotes = new NotesCollection();
        public NotesCollection UserNotes { get { return userNotes; } }

        public void DisplayNotes()
        {
            userNotes.Add(new Note { hey = "Hello World" });
        }


    }
}
