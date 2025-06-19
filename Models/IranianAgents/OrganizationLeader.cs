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
    internal class OrganizationLeader : AgentBase, ICounterattacker
    {

        public OrganizationLeader(string name, int maxSecretWeaknesses = 8) : base(name, maxSecretWeaknesses)
        {
            Console.WriteLine("create OrganizationLeader agent");

        }

        protected int detectionCallCountOll = 0;
        protected int counterattackThreshold = 3;
        protected int detectionCallCount = 0;


        public override List<ISensors> GetDetectionAccuracy()
        {
            ++detectionCallCount;
            ++detectionCallCountOll;
      
            return base.GetDetectionAccuracy();
        }

        public void CounterattackAll()
        {
            if (detectionCallCountOll >= 10)
            {
                AttachedSensors = new List<ISensors>();
                SensorType[] SecretWeaknessesOptions = (SensorType[])Enum.GetValues(typeof(SensorType));
                SecretWeaknesses = new List<SensorType>();
                for (int i = 0; i < MaxSecretWeaknesses; i++)
                {
                    SecretWeaknesses.Add(SecretWeaknessesOptions[RandomGenerator.GetRandomNumber(SecretWeaknessesOptions.Length)]);
                }
                Console.WriteLine($"Secret Weaknesses for {Name}: {string.Join(", ", SecretWeaknesses)}");
            }
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
