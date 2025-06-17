using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_investigation_game.Models.Sensors;

namespace The_investigation_game.Interfaces
{
    internal interface ISensors
    {
       
        SensorType Type { get;  }
        void Activate();
    }
}
