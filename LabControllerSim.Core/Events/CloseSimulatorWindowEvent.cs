using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabControllerSim.Core.Events
{
    // Zdarzenie przesyłające informacjię o zamknięciu okna symulatora
    public class CloseSimulatorWindowEvent : PubSubEvent<string>
    {
    }
}
