using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabControllerSim.Core.Events
{
    // Zdarzenie przesyłające znak z symulatora sterownika do konsoli
    public class SendCharFromProgramToConsoleEvent : PubSubEvent<string>
    {
    }
}
