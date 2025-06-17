using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_investigation_game.Interfaces
{
    public interface ICounterattacker
    {
        void Counterattack();
        void IncreaseCounterattackThreshold(int amount);
    }

}
