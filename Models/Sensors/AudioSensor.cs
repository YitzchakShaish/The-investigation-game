using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_investigation_game.Interfaces;

namespace The_investigation_game.Models.Sensors
{
    internal class AudioSensor : ISensors
    {
        
        public SensorType Type { get;  } = SensorType.Audio;

        public void Activate()
        {
            Console.WriteLine($"The {Type} sensor with name  is activated.");
        }
    }
}
