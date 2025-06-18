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
            Console.WriteLine("SquadLeader version");

            if (detectionCallCount == counterattackThreshold)
            {
                Counterattack();
            }
            ++detectionCallCount;
            var copySecretWeaknesses = new List<SensorType>(SecretWeaknesses);
            List<ISensors> detectedSensors = new List<ISensors>();

            for (int i = 0; i < AttachedSensors.Count(); i++)
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
            if (AttachedSensors.Count < 2)
                return;
            int index = RandomGenerator.GetRandomNumber(AttachedSensors.Count);
            AttachedSensors.RemoveAt(index);
            int index2 = RandomGenerator.GetRandomNumber(AttachedSensors.Count);
            AttachedSensors.RemoveAt(index2);
        }
    
        public void IncreaseCounterattackThreshold(int amount)
        {
            counterattackThreshold += amount;
        }
    }
}
