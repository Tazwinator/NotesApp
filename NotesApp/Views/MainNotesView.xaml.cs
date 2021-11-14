using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NotesApp.ViewModels;

namespace NotesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainNotesView : ContentPage
    {
        public MainNotesView()
        {
            InitializeComponent();

            //BindingContext = new MainNotesView();
        }

     /*   int count1 = 0;
        int count2 = 0;


        string testText = "Hello World ";

        public string TestText
        {
            get => testText;
            set
            {
                if (value == testText) return;

                testText = value;
                OnPropertyChanged();
            }
       // }

        private void ClickButton1_Clicked(object sender, EventArgs e)
        {
            count1++;
          //  Label1.Text = $"Hello World {count1}";
       // }

        //private void ClickButton2_Clicked(object sender, EventArgs e)
        //{
        //    count2++;
        //    TestText = $"Hello World {count2}";
        //}*/
    }
}