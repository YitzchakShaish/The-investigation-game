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
    internal class SeniorCommander : AgentBase, ICounterattacker
    {

        public SeniorCommander ( string name, int maxSecretWeaknesses = 6) : base(name, maxSecretWeaknesses)
        {
            Console.WriteLine("create senior commander");
        }
        protected int counterattackThreshold = 3;
        protected int detectionCallCount = 0;
        public override List<ISensors> GetDetectionAccuracy()
        {
            Console.WriteLine("SeniorCommander version");

            ++detectionCallCount;
            return base.GetDetectionAccuracy();
            
        }

        public void Counterattack()
        {
            if (detectionCallCount == counterattackThreshold)
            {
            if (AttachedSensors.Count < 2)
                return;
            int index = RandomGenerator.GetRandomNumber(AttachedSensors.Count);
            AttachedSensors.RemoveAt(index);
            int index2 = RandomGenerator.GetRandomNumber(AttachedSensors.Count);
            AttachedSensors.RemoveAt(index2);
            }
        }
    
        public void IncreaseCounterattackThreshold(int amount)
        {
            counterattackThreshold += amount;
        }
    }
}
