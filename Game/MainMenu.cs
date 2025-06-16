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
    internal static class MainMenu
    {
        public static void Show()
        {
            bool isRunning = true;
            JuniorAgent currentAgent = null;
            while (isRunning)
            {
                Console.Clear();
                Console.Title = "Welcome to the investigation game.";
                Console.ForegroundColor = ConsoleColor.Cyan;

                PrintHeader("Game menu");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Welcome to the Intelligence Simulation Game!");
                Console.WriteLine("Please select an action:");
                Console.WriteLine("1 - Create a new agent");
                Console.WriteLine("2 - Attach a sensor to agent");
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

                            int index;
                            while (true) 
                            {
                                Console.WriteLine($"Enter your index: min = 0 max = {currentAgent.MaxSecretWeaknesses-1}");
                                string inputi = Console.ReadLine();

                                if (!int.TryParse(inputi, out index))
                                {
                                    Console.WriteLine("Invalid input. Must be a number.");
                                    continue; 
                                }

                                if (index < 0 || index > currentAgent.MaxSecretWeaknesses)
                                {
                                    Console.WriteLine($"Invalid input. Must be between 0 and {currentAgent.MaxSecretWeaknesses}.");
                                    continue; 
                                }

                                break; 
                            }

                            Console.WriteLine($"DEBUG BEFORE: index to send = {index}");

                            currentAgent.AddAttachedSensors(sensor, index);
                            Console.WriteLine("Sensor attached.");
                            currentAgent.GetDetectionAccuracy();
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
            Console.WriteLine(new string('═', 50));
            Console.WriteLine($"            {title}");
            Console.WriteLine(new string('═', 50));
        }
        private static ISensors CreateSensor()
        {
            Console.WriteLine("Please choose a sensor:");
            Console.WriteLine("1 - Audio Sensor");
            Console.WriteLine("2 - Thermal Sensor");
            Console.Write("Your choice: ");

            string sensorChoice = Console.ReadLine();

            switch (sensorChoice)
            {
                case "1":
                case "audioSensor":
                    return new AudioSensor();

                case "2":
                case "thermalSensor":
                    return new ThermalSensor();

                default:
                    Console.WriteLine("Invalid selection. Press any key to try again...");
                    Console.ReadKey();
                    Console.Clear();
                    return CreateSensor(); 
            }
        }
        private static JuniorAgent CreateAgent()
        {
            Console.WriteLine("Please choose a agent:");
            Console.WriteLine("1 - junior agent");
            Console.WriteLine("2 - else");
            Console.Write("Your choice: ");

            string sensorChoice = Console.ReadLine();
            Console.WriteLine("Enter the name of the agent");

            string name = Console.ReadLine();

            switch (sensorChoice)
            {
                case "1":
                case "juniorAgent":
                    return new JuniorAgent(name);

                case "2":
                case "thermalSensor":
                    return new JuniorAgent(name);

                default:
                    Console.WriteLine("Invalid selection. Press any key to try again...");
                    Console.ReadKey();
                    Console.Clear();
                    return CreateAgent();
            }
        }

    }
}
