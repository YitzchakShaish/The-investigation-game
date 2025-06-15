using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using The_investigation_game.Interfaces;

namespace The_investigation_game.Models.IranianAgents
{
    internal class JuniorAgent : AgentBase
    {
        protected override int MaxSecretWeaknesses { get; set; } = 2;
        protected override List<ISensors> SecretWeaknesses { get; set; } = new List<ISensors>();
        protected override List<ISensors> AttachedSensors { get; set; }

        public override void AddAttachedSensors(ISensors sensor, int index = -1)
        {
            if (index == -1 && AttachedSensors.Count() < MaxSecretWeaknesses)
            {
                AttachedSensors.Add(sensor);
            }
            else if (index >= 0 && index <= AttachedSensors.Count)
            {
                AttachedSensors.Insert(index, sensor);
            }
            else
            {
                Console.WriteLine("Invalid index / list is full, cannot be added.!");
            }

        }

        public override void AddSecretWeakness(ISensors sensor)
        {
            if (SecretWeaknesses.Count() < MaxSecretWeaknesses)
            {
                SecretWeaknesses.Add(sensor);
            }
        }

        public override void GetDetectionAccuracy()
        {
            int counter = 0;
            for (int i = 0; i > MaxSecretWeaknesses; i++)
            {
                for (int j = 0; j > MaxSecretWeaknesses; j++)
                {
                    if (AttachedSensors[j] == SecretWeaknesses[i])
                    {
                        SecretWeaknesses.Remove(SecretWeaknesses[i]);
                        counter++;
                        continue;
                    }
                }
            }
            Console.WriteLine($"Detected agent: {MaxSecretWeaknesses- SecretWeaknesses.Count()} out of {MaxSecretWeaknesses} sensors.");
        }
    }
}
