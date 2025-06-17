using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_investigation_game.Interfaces;

namespace The_investigation_game.Models.Sensors
{
    internal class MotionSensor : ISensors, IBreakableSensor
    {

        public SensorType Type { get; } = SensorType.Motion;
        public int MaxActivations { get; } = 3;

        public int CurrentActivations { get; set; } = 0;

        public int ActivationsLeft => MaxActivations - CurrentActivations;

        public bool IsBroken => ActivationsLeft <= 0;
        public void Activate()
        {
            {
                if (IsBroken)
                {
                    Console.WriteLine($"The {Type} sensor  is broken and cannot be activated.");
                }
                else
                {
                    CurrentActivations++;
                    Console.WriteLine($"The {Type} sensor  is activated. Activations left: {ActivationsLeft}");
                }
            }
        }
    }
}
