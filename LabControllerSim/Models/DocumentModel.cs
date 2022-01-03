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
        public TextDocument EditorDocument { get; set; }


        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set { OnPropertyChange(ref _filePath, value); }
        }
        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set { OnPropertyChange(ref _fileName, value); }
        }

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
