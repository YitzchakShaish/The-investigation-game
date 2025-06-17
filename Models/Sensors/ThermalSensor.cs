using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_investigation_game.Interfaces;
using The_investigation_game.Models.IranianAgents;

namespace The_investigation_game.Models.Sensors
{
    internal class ThermalSensor: ISensors, IRevealerSensor
    {
       
        public SensorType Type { get;  } = SensorType.Thermal;

        public void Activate()
        {
            Console.WriteLine($"The {Type} sensor with name  is activated.");
        }

        public string Reveal(JuniorAgent agent)
        {
            

            return $"Hey, here's one of my weaknesses: \"{agent.GetRandomWeakness()}\"";
        }
    }
}
