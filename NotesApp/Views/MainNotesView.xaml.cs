﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainNotesView : ContentPage
    {
        public MainNotesView()
        {
            InitializeComponent();

        }

        public string testText = "Hello World";

    }
}