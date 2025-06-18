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
            Console.WriteLine("SquadLeader version");

            if (detectionCallCount == counterattackThreshold)
            {
                Counterattack();
            }
            ++detectionCallCount;

            var copySecretWeaknesses = new List<SensorType>(SecretWeaknesses);
            List<ISensors> detectedSensors = new List<ISensors>();

            for (int i = AttachedSensors.Count - 1; i >= 0; i--)
            {
                AttachedSensors[i].Activate();
                for (int j = 0; j < copySecretWeaknesses.Count; j++)
                {
                    if (AttachedSensors[i] is IBreakableSensor breakableSensor && breakableSensor.CheckBreakCondition())
                    {
                        AttachedSensors.RemoveAt(i);
                        break;
                    }

                    if (AttachedSensors[i].Type == copySecretWeaknesses[j])
                    {
                        detectedSensors.Add(AttachedSensors[i]);
                        copySecretWeaknesses.RemoveAt(j);
                        break;
                    }
                }
            }
            if (copySecretWeaknesses.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("All weaknesses detected! You win!");
                Console.ResetColor();
            }

            Console.WriteLine($"secretWeaknesses{SecretWeaknesses.Count()} copySecretWeaknesses: {copySecretWeaknesses.Count()} secretWeaknesses: {SecretWeaknesses.Count()} .");

            Console.WriteLine($"Detected agent: {SecretWeaknesses.Count() - copySecretWeaknesses.Count()} out of {SecretWeaknesses.Count()} sensors.");
            return detectedSensors;
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
