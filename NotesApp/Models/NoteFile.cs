using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace NotesApp.Models.Files
{
    static class NoteFile
    {

        

        public static string FullFilePath(this string fileName)
        {
            return $"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NoteStorage", fileName)}";
        }

        public static void CreateNoteFile(this string filePath, string noteText)
        {
            if (Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NoteStorage")))
            {
                File.WriteAllText(filePath, noteText);
            }
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NoteStorage"));
            File.WriteAllText(filePath, noteText);
        }

    }
}
