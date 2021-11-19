using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NotesApp.Models
{
    class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
