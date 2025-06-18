using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_investigation_game.Interfaces;
using The_investigation_game.Models.IranianAgents;

namespace The_investigation_game.Models.Sensors
{
    internal class LightSensor : ISensors, IRevealerSensor
    {
        
        public SensorType Type { get; } = SensorType.Light;

        public void Activate()
        {
            Console.WriteLine($"The {Type} sensor with name  is activated.");
        }
        public string Reveal(AgentBase agent)
        {
            string name = $"Hey, I found out something about the agent. His name is: {agent.GetName}";
            string organization = $"Hey, I found out something about the agent. He is affiliated with the organization: {agent.GetTerrorAffiliation}";
            return name + "\n" + organization;
        }
    }
}
