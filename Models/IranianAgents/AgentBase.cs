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
    internal abstract class AgentBase
    {
        public int MaxSecretWeaknesses { get; protected set; }

        protected virtual TerrorGroup TerrorAffiliation { get; set; }
        protected virtual List<SensorType> SecretWeaknesses { get; set; }
        protected virtual List<ISensors> AttachedSensors { get; set; }

        protected string Name { get; set; }
        public virtual string GetName => Name;
        public virtual string GetTerrorAffiliation => TerrorAffiliation.ToString();

        public AgentBase(string name, int maxSecretWeaknesses)
        {
            Name = name;
            MaxSecretWeaknesses = maxSecretWeaknesses;
            AttachedSensors = new List<ISensors>();
            SecretWeaknesses = new List<SensorType>();
            TerrorGroup[] TerrorAffiliationOptions = (TerrorGroup[])Enum.GetValues(typeof(TerrorGroup));
            TerrorAffiliation = (TerrorGroup)TerrorAffiliationOptions.GetValue(RandomGenerator.GetRandomNumber(TerrorAffiliationOptions.Length));

            SensorType[] SecretWeaknessesOptions = (SensorType[])Enum.GetValues(typeof(SensorType));
            SecretWeaknesses = new List<SensorType>();
            for (int i = 0; i < MaxSecretWeaknesses; i++)
            {
                SecretWeaknesses.Add(SecretWeaknessesOptions[RandomGenerator.GetRandomNumber(SecretWeaknessesOptions.Length)]);
            }
            Console.WriteLine($"Secret Weaknesses for {Name}: {string.Join(", ", SecretWeaknesses)}");

            AttachedSensors = new List<ISensors>();

        }

        public virtual void AddSecretWeakness(SensorType weakness)
        {
            if (SecretWeaknesses.Count < MaxSecretWeaknesses)
            {
                SecretWeaknesses.Add(weakness);
            }
            else
            {
                Console.WriteLine("List is full, cannot insert sensor at index.");
            }
        }

        public virtual void AddAttachedSensors(ISensors sensor)
        {
            AttachedSensors.Add(sensor);
            Console.WriteLine($"Sensor: {sensor.Type.ToString()} was added");
        }

        public virtual void RemoveAttachedSensor(ISensors sensor)
        {
            AttachedSensors.Remove(sensor);
        }

        public virtual List<ISensors> GetAttachedSensors()
        {
            return AttachedSensors;
        }

        public virtual string GetRandomWeakness()
        {
            if (SecretWeaknesses.Count == 0)
                return "No weakness assigned.";
            int index = RandomGenerator.GetRandomNumber(SecretWeaknesses.Count);
            return SecretWeaknesses[index].ToString();
        }

        public virtual List<ISensors> GetDetectionAccuracy()
        {
            var copySecretWeaknesses = new List<SensorType>(SecretWeaknesses);
            List<ISensors> detectedSensors = new List<ISensors>();

            for (int i = AttachedSensors.Count - 1; i >= 0; i--)
            {
                AttachedSensors[i].Activate();

                for (int j = 0; j < copySecretWeaknesses.Count(); j++)
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
    }
}
