using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_investigation_game.Interfaces
{
    internal interface IBreakableSensor
    {
        int MaxActivations { get; }
        int CurrentActivations { get; set; }
        bool IsBroken { get; }

        void Activate();
    }
}
