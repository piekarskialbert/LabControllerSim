using LabControllerSim.Core.Parameters;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabControllerSim.Core.Events
{
    // Aktywacja fukncji sprawdzenie błędów przez moduł kompilacji
    public class CodeCheckErrorsEvent : PubSubEvent<CodeCompileEventParameters>
    {
    }
}
