using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using NotesApp.Models;
using NotesApp.Services;
using NotesApp.Views;
using System.Threading.Tasks;
using System.Web;

namespace NotesApp.ViewModels
{
     class EditNoteViewModel : BindableObject, IQueryAttributable
    {
        public EditNoteViewModel()
        {
            BackBtn = new Command(GoBack);
            SaveNote = new Command(Save);
            DelNote = new Command(Delete);
            
        }

        public ICommand SaveNote { get; }
        public ICommand DelNote { get; }
        public ICommand BackBtn { get; }


        private Note currentNote = new Note();

        public Note CurrentNote
        {
            get { return currentNote; }
            set
            {
                currentNote.Content = value.Content;
                currentNote.Title = value.Title;
                currentNote.Id = value.Id;
                OnPropertyChanged();
            }
        }

        async void Save()
        {
            System.Diagnostics.Debug.WriteLine(CurrentNote.Content, CurrentNote.Title);
            await NoteStoreService.AddNote(CurrentNote.Content, CurrentNote.Title, CurrentNote.Id);
            GoBack();
        }

        private async void Delete()
        {
            System.Diagnostics.Debug.WriteLine(CurrentNote.Content, CurrentNote.Title);
            await NoteStoreService.RemoveNote(CurrentNote.Id);
            GoBack();
        }

        private async void GoBack()
        {
            await Shell.Current.GoToAsync("//NotesPage");
        }

        public async void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            if (query.ContainsKey("noteData"))
            {
                int Id = Int32.Parse(HttpUtility.UrlDecode(query["noteData"]));
                CurrentNote = await NoteStoreService.GetNote(Id);
                return;
            }
            else if (query.ContainsKey("newNote"))
            {
                CurrentNote = new Note();
                return;
            }
        }
    }
}
