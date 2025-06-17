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
    internal class OrganizationLeader : SquadLeader, ICounterattacker
    {
        public override int MaxSecretWeaknesses { get; } = 8;

        public OrganizationLeader(string name) : base(name)
        {
        }

        protected int detectionCallCountOll = 0;



        public override void GetDetectionAccuracy()
        {
            if (detectionCallCount == counterattackThreshold)
            {
                Counterattack();
            }
            if (detectionCallCountOll>=10)
            {
                CounterattackOll();
            }
            ++detectionCallCount;
            ++detectionCallCountOll;


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

        public void CounterattackOll()
        {
            AttachedSensors = new List<ISensors>();
            SensorType[] SecretWeaknessesOptions = (SensorType[])Enum.GetValues(typeof(SensorType));
        }
    }
}
