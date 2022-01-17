using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LabControllerSim.Core.Events
{
    // Zdarzenie przesyłające informacje o puszczonym klawiszu w oknie symulatora
    public class KeyUpWindowEvent : PubSubEvent<KeyEventArgs>
    {
    }
}
