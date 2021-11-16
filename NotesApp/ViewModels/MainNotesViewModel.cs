using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using NotesApp.Models;
using Xamarin.Forms;

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

        void DisplayNotes()
        {
            userNotes.Add(new Note { Content = "Hello World" });
        }


    }
}
