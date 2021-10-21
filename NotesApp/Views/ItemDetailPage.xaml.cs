using NotesApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace NotesApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}