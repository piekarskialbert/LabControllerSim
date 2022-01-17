using ICSharpCode.AvalonEdit.Document;
using LabControllerSim.Core;
using Prism.Common;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabControllerSim.Models
{
    public class DocumentModel : ObservableObject
    {
        // Właściwość użyta aby możliwa była synchornizacja testu edytora ze zmienną EditorDocument.Text
        public TextDocument EditorDocument { get; set; }

        private string _filePath;
        
        // Właściość przechowująca ścieżke pliku
        public string FilePath
        {
            get { return _filePath; }
            set { OnPropertyChange(ref _filePath, value); }
        }
        private string _fileName;

        // Właściwość przechowująca nazwe pliku
        public string FileName
        {
            get { return _fileName; }
            set { OnPropertyChange(ref _fileName, value); }
        }

        // Właściwość sprawdzająca czy plik jest zapisany
        public bool isEmpty
        {
            get
            {
                if (string.IsNullOrEmpty(FileName) ||
                    string.IsNullOrEmpty(FilePath))
                    return true;
                return false;
            }

        }
    }

}
