using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_investigation_game.Interfaces;
using The_investigation_game.Models.IranianAgents;
using The_investigation_game.Services;

namespace The_investigation_game.Models.Sensors
{
    internal class SignalSensor : ISensors, IRevealerSensor
    {

        public SensorType Type { get; } = SensorType.Signal;

        public void Activate()
        {
            Console.WriteLine($"The {Type} sensor with name  is activated.");
        }

        public string Reveal(JuniorAgent agent)
        {
            string[] information = {$"Hey, I found out something about the agent. His name is: {agent.Name}",
             $"Hey, I found out something about the agent. He is affiliated with the organization: {agent.TerrorAffiliation.ToString()}" };
           return information[RandomGenerator.GetRandomNumber(information.Length)];
        }
    }
}
