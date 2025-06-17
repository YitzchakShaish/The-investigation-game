using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_investigation_game.Models.IranianAgents;

namespace The_investigation_game.Interfaces
{
    internal interface IRevealerSensor
    {
        string Reveal(JuniorAgent agent);
        
    }
}
