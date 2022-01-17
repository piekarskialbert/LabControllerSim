using ICSharpCode.AvalonEdit.Document;
using LabControllerSim.Core;
using LabControllerSim.Models;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LabControllerSim.ViewModels
{
    public class FileViewModel
    {
        public DocumentModel Document { get; private set; }

        // Komendy do maniplowania plikiem
        public ICommand NewCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand OpenComand { get; }


        public FileViewModel(DocumentModel document)
        {
  
            Document = document;
            Document.EditorDocument = new TextDocument();
            Document.EditorDocument.Text = NewFilePattern(); // Po otworzeniu programu pokaż wzór nowego pliku
            NewCommand = new RelayCommand(NewFile);
            SaveCommand = new RelayCommand(SaveFile, () => !Document.isEmpty);
            SaveAsCommand = new RelayCommand(SaveFileAs);
            OpenComand = new RelayCommand(OpenFile);
        }

        // Metoda tworząca nowy plik
        public void NewFile()
        {
            Document.FileName = string.Empty;
            Document.FilePath = string.Empty;
            Document.EditorDocument.Text = NewFilePattern();
        }

        // Metoda zwracająca wzór kodu nowo utworzonego pliku
        string NewFilePattern()
        {
            return @"#include <stdio.h>
#include <unistd.h>

int main()
{

	//Deklaracja zmiennych użytkownika:

	
    while (1)
    {    
    	//Kod użytkownika:
    	
		
		
    }
}
";
        }
        
        // Metoda zapisująca istniejący plik
        public void SaveFile()
        {
            File.WriteAllText(Document.FilePath, Document.EditorDocument.Text);
        }

        // Metoda zapisująca nowy plik
        public void SaveFileAs()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "C file (*.c)|*.c";
            if (saveFileDialog.ShowDialog() == true)
            {
                DockFile(saveFileDialog);
                File.WriteAllText(saveFileDialog.FileName, Document.EditorDocument.Text);
            }
        }

        // Metoda otwierająca istniejący plik
        public void OpenFile()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                DockFile(openFileDialog);
                Document.EditorDocument.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        // Metoda przypisująca do zmiennych dokumentu ścieżke i nazwe wybranego pliku w dialogu
        private void DockFile<T>(T dialog) where T : FileDialog
        {
            Document.FilePath = dialog.FileName;
            Document.FileName = dialog.SafeFileName;
        }

        // Metoda sprawdzająca czy plik po zapisaniu uległ zmianie
        public bool CheckChanges()
        {
            if (Document.EditorDocument.Text == File.ReadAllText(Document.FilePath))
                return true;
            else 
                return false;
        }
    }
}
