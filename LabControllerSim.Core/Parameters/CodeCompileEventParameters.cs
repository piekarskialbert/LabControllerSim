using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabControllerSim.Core.Parameters
{
    // Klasa zawierająca parametry do przesyłania zdarzenia do modułu kompilacji
    public class CodeCompileEventParameters
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}
