using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabControllerSim.Core.Events
{
    // Zdarzenie przesyłające informacje o nazwie obiektu
    public class SendObjectNameEvent : PubSubEvent<string[]>
    {
    }
}
