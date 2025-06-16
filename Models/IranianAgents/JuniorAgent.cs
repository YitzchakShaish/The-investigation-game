using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using The_investigation_game.Interfaces;
using The_investigation_game.Models.Sensors;
using The_investigation_game.Services;

namespace The_investigation_game.Models.IranianAgents
{
    internal class JuniorAgent : AgentBase
    {
        public  string Name { get; set; }

        public override int MaxSecretWeaknesses { get; set; } = 2;
        protected override List<SensorType> SecretWeaknesses { get; set; } 
        protected override List<ISensors> AttachedSensors { get; set; } 

        public JuniorAgent(string name)
        {
            Name = name;
            List<SensorType> SecretWeaknessesOptions = new List<SensorType> { SensorType.Audio, SensorType.Thermal};
            SecretWeaknesses = new List<SensorType>() { SecretWeaknessesOptions[RandomGenerator.GetRandomNumber(MaxSecretWeaknesses)], SecretWeaknessesOptions[RandomGenerator.GetRandomNumber(MaxSecretWeaknesses)] };
            AttachedSensors = new List<ISensors>() ;

        }
        public override void AddAttachedSensors(ISensors sensor, int index = -1)
        {
            if (index >= 0 && index < AttachedSensors.Count)
            {
                
                AttachedSensors[index] = sensor;
                Console.WriteLine($"Sensor at index {index} was replaced.");
            }
            else if (index == AttachedSensors.Count && AttachedSensors.Count < MaxSecretWeaknesses)
            {
                
                AttachedSensors.Add(sensor);
                Console.WriteLine($"Sensor was added at index {index}.");
            }
            else
            {
                Console.WriteLine("Invalid index, or list is full.");
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
                        AttachedSensors[i].Activate();
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

