using System.Text.Json;
using System.Xml.Linq;
using System;
using trainingBase;
using static System.Net.Mime.MediaTypeNames;

namespace trainingBase
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Exercise> exercises = ListOfExercises.LoadFromFile();
            while (true)
            {
                Console.WriteLine("Select action:");
                Console.WriteLine("1 - Watch all exercises");
                Console.WriteLine("2 - Add exercise");
                Console.WriteLine("3 - Delete all exercises");
                Console.WriteLine("4 - Search by muscle group");
                Console.WriteLine("5 - Sort by difficult");
                Console.WriteLine("6 - Exit");
                string? action = Console.ReadLine();
                Console.WriteLine();
                if (action == "1")
                {
                    Interaction.Read(exercises);
                }
                else if (action == "2")
                {
                    Interaction.Add(exercises);
                }
                else if (action == "3")
                {
                    exercises = new();
                }
                else if (action == "4")
                {
                    Interaction.Search(exercises);
                    
                }
                else if (action == "5")
                {
                    Interaction.SortByDifficult(exercises);
                }
                else if (action == "6")
                {
                    ListOfExercises.LoadToFile(exercises);
                    break;
                }
                else Console.WriteLine("Incorrect command, try again");
            }
        }
    }
}



