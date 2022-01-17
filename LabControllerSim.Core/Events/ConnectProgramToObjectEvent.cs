using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabControllerSim.Core.Events
{
    // Zdarzenie przesyłające informacje czy program ma wymieniać informacje z symulatorem obiektów
    public class ConnectProgramToObjectEvent : PubSubEvent<bool>
    {
    }
}
