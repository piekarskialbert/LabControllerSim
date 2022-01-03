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

        //Toolbar commands
        public ICommand NewCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand OpenComand { get; }

        //public DelegateCommand SendCodeCommand { get; private set; }

        public FileViewModel(DocumentModel document)
        {
  
            Document = document;
            Document.EditorDocument = new TextDocument();
            NewCommand = new RelayCommand(NewFile);
            SaveCommand = new RelayCommand(SaveFile, () => !Document.isEmpty);
            SaveAsCommand = new RelayCommand(SaveFileAs);
            OpenComand = new RelayCommand(OpenFile);
        }




        public void NewFile()
        {
            Document.FileName = string.Empty;
            Document.FilePath = string.Empty;
            Document.EditorDocument.Text = NewFilePattern();
        }

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
        public void SaveFile()
        {
            File.WriteAllText(Document.FilePath, Document.EditorDocument.Text);
        }

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
        public void OpenFile()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                DockFile(openFileDialog);
                Document.EditorDocument.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }
        private void DockFile<T>(T dialog) where T : FileDialog
        {
            Document.FilePath = dialog.FileName;
            Document.FileName = dialog.SafeFileName;
        }

        public bool CheckChanges()
        {
            if (Document.EditorDocument.Text == File.ReadAllText(Document.FilePath))
                return true;
            else 
                return false;
        }
    }
}
