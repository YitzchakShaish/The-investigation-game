using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using The_investigation_game.Interfaces;
using The_investigation_game.Models.IranianAgents;
using The_investigation_game.Models.Sensors;

namespace The_investigation_game.Game
{
    internal static class GameUI
    {
        public static void Show()
        {
            bool isRunning = true;
            AgentBase currentAgent = null;
            while (isRunning)
            {
                Console.Clear();
                Console.Title = "Welcome to the investigation game!.";
                Console.ForegroundColor = ConsoleColor.Cyan;

                PrintHeader("Game menu");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please select an action: (0-2)");
                Console.WriteLine("1. Create a new agent");
                Console.WriteLine("2. Attach a sensor to agent");
                Console.WriteLine("0. Exit");

                Console.Write("Your choice: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        currentAgent =  CreateAgent();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();

                        break;
                    case "2":
                        if (currentAgent == null)
                        {
                            Console.WriteLine("You must create an agent first!");
                        }
                        else
                        {
                            ISensors sensor = CreateSensor();
                            InvestigationManager.ExecuteSensorInteractionPhase(currentAgent, sensor);
                        }
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();

                        break;


                    case "0":
                        Console.WriteLine("\nExiting the investigation menu...");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();

                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid selection. Press any key to try again...");
                        Console.ReadKey();
                        Show();
                        break;
                }
            }
        }

        private static void PrintHeader(string title)
        {
            Console.WriteLine(new string('~', 40));
            Console.WriteLine($"            {title}");
            Console.WriteLine(new string('~', 40));
        }
        private static ISensors CreateSensor()
        {
            Console.WriteLine("Please choose a sensor:");
            Console.WriteLine("\n1. Audio\n2. Thermal\n3. Pulse\n4. Motion\n5. Magnetic\n6. Signal\n7. Light");
            Console.Write("Your choice: ");

            string sensorChoice = Console.ReadLine();

            switch (sensorChoice)
            {
                case "1":
                    return new AudioSensor();

                case "2":
                    return new ThermalSensor();
                    
                case "3":
                    return new PulseSensor();

                case "4":
                    return new MotionSensor();

                case "5":
                    return new MagneticSensor();

                case "6":
                    return new SignalSensor();

                case "7":
                    return new LightSensor();


                default:
                    Console.WriteLine("Invalid selection. Press any key to try again...");
                    Console.ReadKey();
                    Console.Clear();
                    return CreateSensor(); 
            }
        }
        private static AgentBase CreateAgent()
        {
            Console.WriteLine("Please choose an agent:\n1. Junior Agent\n2. Squad Leader\n3. Senior Commander\n4. Organization Leader");
            Console.Write("Your choice: ");

            string agentChoice = Console.ReadLine();
            Console.WriteLine("Enter the name of the agent");

            string name = Console.ReadLine();

            switch (agentChoice)
            {
                case "1":
                    return new JuniorAgent(name);

                case "2":
                    return new SquadLeader(name);

                case "3":
                    return new SeniorCommander(name);

                case "4":
                    return new OrganizationLeader(name);

                default:
                    Console.WriteLine("Invalid selection. Press any key to try again...");
                    Console.ReadKey();
                    Console.Clear();
                    return CreateAgent();
            }
        }

    }
}
