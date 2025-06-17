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

    internal class SquadLeader : JuniorAgent, ICounterattacker
    {
        public override int MaxSecretWeaknesses { get;  } = 4;

        public SquadLeader(string name) : base(name)
        {
        }
        protected int counterattackThreshold = 3;
        protected int detectionCallCount = 0;



        public override void GetDetectionAccuracy()
        {
            if (detectionCallCount == counterattackThreshold)
            {
                Counterattack();
            }
            detectionCallCount++;


            var copySecretWeaknesses = new List<SensorType>(SecretWeaknesses);
            int counter = 0;
            for (int i = 0; i < AttachedSensors.Count; i++)
            {
                for (int j = 0; j < copySecretWeaknesses.Count; j++)
                {
                    if (AttachedSensors[i].Type == copySecretWeaknesses[j])
                    {
                        AttachedSensors[i].Activate();
                        copySecretWeaknesses.Remove(copySecretWeaknesses[j]);
                        counter++;
                        break;
                    }
                }
            }
            Console.WriteLine($"Detected agent: {SecretWeaknesses.Count - copySecretWeaknesses.Count} out of {SecretWeaknesses.Count} sensors.");
        }

        public void Counterattack()
        {
            int index = RandomGenerator.GetRandomNumber(AttachedSensors.Count);
            AttachedSensors.RemoveAt(index);
        }
        public void IncreaseCounterattackThreshold(int amount)
        {
            counterattackThreshold += amount;
        }
    }
}
