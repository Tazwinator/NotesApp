using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NotesApp.ViewModels;
using NotesApp.Models;

namespace NotesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainNotesView : ContentPage
    {
        public MainNotesView()
        {
            InitializeComponent();
        }

        private void LoadNoteEditor(object sender, ItemTappedEventArgs e)
        {
            MainNotesViewModel.LoadNoteEditor(e.Item);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            InitializeComponent();

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            Navigation.PopAsync();
        }
    }
}