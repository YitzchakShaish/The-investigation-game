using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using The_investigation_game.Interfaces;
using The_investigation_game.Models.Sensors;

namespace The_investigation_game.Models.IranianAgents
{
    abstract class AgentBase
    {
        public string Name { get; set; }
        protected abstract List<SensorType> SecretWeaknesses { get; set; }
        protected abstract List<ISensors> AttachedSensors { get; set; }
        public abstract int MaxSecretWeaknesses { get; set; }
        public abstract void AddSecretWeakness(SensorType weakness);
        public abstract void AddAttachedSensors(ISensors sensor, int index);
        public abstract void GetDetectionAccuracy();


    }
}
