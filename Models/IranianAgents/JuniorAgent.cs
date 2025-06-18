using System;
using System.Collections.Generic;
using System.Linq;
using The_investigation_game.Interfaces;
using The_investigation_game.Models.Sensors;
using The_investigation_game.Services;

namespace The_investigation_game.Models.IranianAgents
{
    internal class JuniorAgent : AgentBase
    {
        public JuniorAgent(string name, int maxSecretWeaknesses = 2) : base( name ,maxSecretWeaknesses)
        {
            Console.WriteLine("create junior agent");
            
        }
    }
}
