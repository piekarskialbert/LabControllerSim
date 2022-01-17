using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LabControllerSim.Core.Events
{
    // Zdarzenie przesyłające zmienne wejściowe z obiektu do symulatora obiektu
    public class  SendInputFromObjectToObjectSimulatorEvent : PubSubEvent<string>
    {
    }
}
