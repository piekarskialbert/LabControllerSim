using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabControllerSim.Core.Events
{
    // Zdarzenie przesyłające znak z konsoli do programu na wirtualnym sterowniku
    public class SendCharFromConsoleToProgramEvent : PubSubEvent<string>
    {
    }
}
