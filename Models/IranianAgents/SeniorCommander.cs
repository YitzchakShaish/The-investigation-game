using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_investigation_game.Interfaces;
using The_investigation_game.Services;

namespace The_investigation_game.Models.IranianAgents
{
    internal class SeniorCommander : SquadLeader, ICounterattacker
    {
        public override int MaxSecretWeaknesses { get;  } = 6;

        public SeniorCommander(string name) : base(name)
        {
        }
        public void Counterattack()
        {
            int index = RandomGenerator.GetRandomNumber(AttachedSensors.Count);
            AttachedSensors.RemoveAt(index);
            int index2 = RandomGenerator.GetRandomNumber(AttachedSensors.Count);
            AttachedSensors.RemoveAt(index2);
        }
    }
}
