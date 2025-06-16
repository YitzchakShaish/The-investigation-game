using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_investigation_game.Game;
using The_investigation_game.Interfaces;
using The_investigation_game.Models.IranianAgents;
using The_investigation_game.Models.Sensors;

namespace The_investigation_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ISensors s = new AudioSensor();
            //ISensors s2 = new ThermalSensor();

            //JuniorAgent achmad = new JuniorAgent();
            //achmad.AddSecretWeakness(SensorType.Audio);
            //achmad.AddSecretWeakness(SensorType.Audio);
            //achmad.AddAttachedSensors(s);
            //achmad.AddAttachedSensors(s);

            //achmad.GetDetectionAccuracy();
            MainMenu.Show();

        }
    }
}
