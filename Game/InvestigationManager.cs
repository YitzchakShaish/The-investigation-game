using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_investigation_game.Interfaces;
using The_investigation_game.Models.IranianAgents;
using The_investigation_game.Models.Sensors;

namespace The_investigation_game
{
    internal static class InvestigationManager
    {
        static List<JuniorAgent> listActiveAgents = new List<JuniorAgent>();
        static List<JuniorAgent> listInactiveAgents = new List<JuniorAgent>();

        public static void PrintAgent()
        {

        }
        public static List<ISensors> EvaluateAgent(AgentBase agent)
        {

         
            return agent.GetDetectionAccuracy();
        }
        public static void ActivateAllSensors(List<ISensors> attachedSensors, AgentBase agent)
        {
            foreach (var sensor in attachedSensors)
            {
                //sensor.Activate(); 
                if (sensor is IRevealerSensor revealerSensor)//& sensor.Type is
                {
                    Console.WriteLine(revealerSensor.Reveal(agent));
                }
               
                if (sensor is MagneticSensor magneticSensor)
                {
                    magneticSensor.PreventCounterattackTwoTimes(agent);
                }

            }
        }

        public static void ActivateAdvancedAgentAbilities(AgentBase agent)
        {
            if (agent is ICounterattacker agentCounterattacker)
            {
                agentCounterattacker.Counterattack();
                if (agentCounterattacker is OrganizationLeader agentOrganizationLeader)
                    agentOrganizationLeader.CounterattackAll();
            }
        }

    }
}
