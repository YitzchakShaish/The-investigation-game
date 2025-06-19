using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_investigation_game.Interfaces;
using The_investigation_game.Models.Sensors;
using The_investigation_game.Services;

namespace The_investigation_game.Models.IranianAgents
{

    internal class SquadLeader : AgentBase, ICounterattacker
    {

        public SquadLeader(string name, int maxSecretWeaknesses = 4) : base(name, maxSecretWeaknesses)
        {
            Console.WriteLine($"create SquadLeader agent {MaxSecretWeaknesses}");
        }



        protected int counterattackThreshold = 3;
        protected int detectionCallCount = 0;



        public override List<ISensors> GetDetectionAccuracy()
        {
   
            ++detectionCallCount;
            return base.GetDetectionAccuracy();

        }
        public void Counterattack()
        {
            if (detectionCallCount == counterattackThreshold)
            {
            int index = RandomGenerator.GetRandomNumber(AttachedSensors.Count);
            AttachedSensors.RemoveAt(index);
            }
        }
        public void IncreaseCounterattackThreshold(int amount)
        {
            counterattackThreshold += amount;
        }
    }
}
