﻿using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabControllerSim.Core.Events
{
    public class SendCharFromProgramToConsoleEvent : PubSubEvent<string>
    {
    }
}
