using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabControllerSim.Core.Parameters;

namespace LabControllerSim.Core.Events
{
    // Aktywacja funkcji utworzenia pliku wykonywalnego prze moduł kompilacji
    public class CodeCompileEvent : PubSubEvent<CodeCompileEventParameters>
    {
    }
}
