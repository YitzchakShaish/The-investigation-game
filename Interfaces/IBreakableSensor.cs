using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_investigation_game.Models.IranianAgents;

namespace The_investigation_game.Interfaces
{
    //Special interface for sensors that break after several uses
    internal interface IBreakableSensor
    {
        int MaxActivations { get; }
        int CurrentActivations { get; set; }
        bool IsBroken { get; }

        void Activate();
        bool CheckBreakCondition();
    }
}
