using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using The_investigation_game.Interfaces;
using The_investigation_game.Models.Sensors;

namespace The_investigation_game.Models.IranianAgents
{
    internal class JuniorAgent : AgentBase
    {
        protected override int MaxSecretWeaknesses { get; set; } = 2;
        protected override List<SensorType> SecretWeaknesses { get; set; } = new List<SensorType>();
        protected override List<ISensors> AttachedSensors { get; set; } = new List<ISensors>();

        public override void AddAttachedSensors(ISensors sensor, int index = -1)
        {
            if (index == -1)
            {
                if (AttachedSensors.Count() < MaxSecretWeaknesses)
                {
                    AttachedSensors.Add(sensor);
                }
                else
                {
                    Console.WriteLine("List is full, cannot add sensor.");
                }
            }
            else if (index >= 0 && index <= AttachedSensors.Count)
            {
                if (AttachedSensors.Count() < MaxSecretWeaknesses)
                {
                    AttachedSensors.Insert(index, sensor);
                }
                else
                {
                    Console.WriteLine("List is full, cannot insert sensor at index.");
                }
            }
            else
            {
                Console.WriteLine("Invalid index, cannot add sensor.");
            }
        }


        public override void AddSecretWeakness(SensorType weakness)
        {
            if (SecretWeaknesses.Count() < MaxSecretWeaknesses)
            {
                SecretWeaknesses.Add(weakness);
            }
            else
            {
                Console.WriteLine("List is full, cannot insert sensor at index.");
            }
        }

        public override void GetDetectionAccuracy()
        {

            var copySecretWeaknesses = new List<SensorType>(SecretWeaknesses);
            int counter = 0;
            for (int i = 0; i < AttachedSensors.Count(); i++)
            {
                for (int j = 0; j < copySecretWeaknesses.Count(); j++)
                {
                    if (AttachedSensors[i].Type == copySecretWeaknesses[j])
                    {
                        copySecretWeaknesses.Remove(copySecretWeaknesses[j]);
                        counter++;
                        continue;
                    }
                }
            }
            Console.WriteLine($"Detected agent: {SecretWeaknesses.Count() - copySecretWeaknesses.Count()} out of {SecretWeaknesses.Count()} sensors.");
        }
    }
    }

