using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabControllerSim.Core.Events
{
    // Zdarzenie przesyłające informacje z symulatora obiektów do obiektu o resecie zmiennych
    public class ResetObjectEvent : PubSubEvent<string>
    {
    }
}
