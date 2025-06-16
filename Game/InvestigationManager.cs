using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_investigation_game.Interfaces;
using The_investigation_game.Models.IranianAgents;

namespace The_investigation_game
{
    internal  static class InvestigationManager
    {
       static List<JuniorAgent> listActiveAgents = new List<JuniorAgent>();
       static List<JuniorAgent> listInactiveAgents = new List<JuniorAgent>();
       static JuniorAgent  ja = new JuniorAgent("ja");
      public static void PrintAgent()
        {

        }
     public static void Activate()
        {
            ja.GetDetectionAccuracy();
        }
    
    public static void AddAttachedSensors(ISensors sensor, int index=-1)
        {
            ja.AddAttachedSensors(sensor, index);
        }

    }
}
