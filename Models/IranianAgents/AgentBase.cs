using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using The_investigation_game.Interfaces;

namespace The_investigation_game.Models.IranianAgents
{
    abstract class AgentBase
    {
        protected abstract List<ISensors> SecretWeaknesses { get; set; }
        protected abstract List<ISensors> AttachedSensors { get; set; }
        protected abstract int MaxSecretWeaknesses { get; set; }
        public abstract void AddSecretWeakness(ISensors sensor);
        public abstract void AddAttachedSensors(ISensors sensor, int index);
        public abstract void GetDetectionAccuracy();


    }
}
