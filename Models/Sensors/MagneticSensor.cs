using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_investigation_game.Interfaces;
using The_investigation_game.Models.IranianAgents;

namespace The_investigation_game.Models.Sensors
{
    internal class MagneticSensor : ISensors
    {

        public SensorType Type { get; } = SensorType.Magnetic;

        public void Activate()
        {
            Console.WriteLine($"The {Type} sensor with name  is activated.");
        }
        public void PreventCounterattackTwoTimes(AgentBase agent)
        {
            if (agent is ICounterattacker counterattacker)
                counterattacker.IncreaseCounterattackThreshold(6);
        }

    }
}
