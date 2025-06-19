using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
        public static void TriggerMatchingSensors(List<ISensors> attachedSensors, AgentBase agent)
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
        public static void ActivateAllSensors(List<ISensors> attachedSensors)
        {
            foreach (var sensor in attachedSensors)
            {
                sensor.Activate();
            }
        }
        //An example of implementing the division into interfaces, checking whether it has the special capabilities, and if so, activating them.
        public static void ActivateAdvancedAgentAbilities(AgentBase agent)
        {
            if (agent is ICounterattacker agentCounterattacker)
            {
                agentCounterattacker.Counterattack();
                if (agentCounterattacker is OrganizationLeader agentOrganizationLeader)
                    agentOrganizationLeader.CounterattackAll();
            }
        }
        //An example of implementing the division into interfaces, checking whether it has the special capabilities, and if so, activating them.
        public static List<ISensors> CheckAndRemoveBrokenSensors(List<ISensors> sensors)
        {
            for (int i = sensors.Count - 1; i >= 0; i--)
            {
                if (sensors[i] is IBreakableSensor breakableSensor && breakableSensor.CheckBreakCondition())
                {
                    sensors.RemoveAt(i);

                }
            }
            return sensors;
        }
        public static void ExecuteSensorInteractionPhase(AgentBase currentAgent, ISensors sensor)
        {
            currentAgent.AddAttachedSensors(sensor);
           // Console.WriteLine($"Secret : {string.Join(", ", currentAgent.GetAttachedSensors())}");

            List<ISensors> attachedSensors = currentAgent.GetAttachedSensors();
            ActivateAllSensors(attachedSensors);
            List<ISensors> detectedSensors = EvaluateAgent(currentAgent);
            TriggerMatchingSensors(detectedSensors, currentAgent);
            CheckAndRemoveBrokenSensors(attachedSensors);
            ActivateAdvancedAgentAbilities(currentAgent);
        }

    }
}
