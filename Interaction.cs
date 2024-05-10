using System;
using System.Text.Json;
using System.Xml.Linq;
using trainingBase;
namespace trainingBase
{
    static class Interaction
    {
        public static void Add(List<Exercise> exercises)
        {
            Console.WriteLine("Enter name of added exrcise: ");
            
            string ? name = Console.ReadLine();
            Console.WriteLine();
            while (name == null || name == "")
            {
                Console.WriteLine("You write nothing, try again: ");
            name = Console.ReadLine();
                Console.WriteLine();
                }
Console.WriteLine("Select muscle group of added exrcises: ");
Console.WriteLine("1 - Chest");
                Console.WriteLine("2 - Back");
                Console.WriteLine("3 - Legs");
                Console.WriteLine("4 - Arms");
                Console.WriteLine();
                string? muscleGroup = Console.ReadLine();
                Console.WriteLine();
                while (muscleGroup != "1" && muscleGroup
                != "2" &&
                muscleGroup != "3" && muscleGroup != "4")
                {
                    Console.WriteLine("You write incorrect command, try again: ");
                muscleGroup = Console.ReadLine();
                    Console.WriteLine();
                    }
Console.WriteLine("Select difficulty of added exrcise from 1 to 5:");
string ? difficulty = Console.ReadLine();
                    Console.WriteLine();
                    while (difficulty != "1" && difficulty != "2" && difficulty
                    != "3" && difficulty != "4" && difficulty != "5")
                    {
                        Console.WriteLine("You write incorrect command, try again: ");
                        difficulty = Console.ReadLine();
                        Console.WriteLine();
                        }
Console.WriteLine("Enter description of added exrcise:");
                        string? description = Console.ReadLine();
                        Console.WriteLine();
                        while (description == null ||
                        description == "")
                        {
                            Console.WriteLine("You write nothing, try again: ");
                        description = Console.ReadLine();
                            Console.WriteLine();
                            }
if (muscleGroup == "1")
                            {
                                muscleGroup = "Chest";
                            }
                            else if (muscleGroup == "2")
                            {
                                muscleGroup = "Back";
                              
                            }
                            else if (muscleGroup == "3")
                            {
                                muscleGroup = "Legs";
                            }
                            else if (muscleGroup == "4")
                            {
                                muscleGroup = "Arms";
                            }
                            Exercise exercise = new(name, muscleGroup,
                            difficulty,
                            description);
                            exercises.Add(exercise);
                        }
                        public static void Search
                        (List<Exercise> exercises)
                        {
                            Console.WriteLine("Select muscle group of searched exrcises: ");
                            Console.WriteLine("1 - Chest");
                            Console.WriteLine("2 - Back");
                            Console.WriteLine("3 - Legs");
                            Console.WriteLine("4 - Arms");
                            string? muscleGroup = Console.ReadLine();
                            while (muscleGroup != "1" && muscleGroup !=
                            "2" && muscleGroup
                            != "3" && muscleGroup != "4")
                            {
                                Console.WriteLine("You write incorrect command, try again: ");
                                muscleGroup = Console.ReadLine();
                                }
List<Exercise> results = new();
                                if (muscleGroup == "1")
                                {
                                    results = exercises.FindAll
                                    (exercise => exercise.MuscleGroup
                                    == "Chest");
                                }
                                else if (muscleGroup == "2")
                                {
                                    results = exercises.FindAll
                                    (exercise => exercise.MuscleGroup ==
                                    "Back");
                                }
                                else if (muscleGroup == "3")
                                {
                                    results = exercises.FindAll
                                    (exercise => exercise.MuscleGroup ==
                                    "Legs");
                                }
                                else if (muscleGroup == "4")
                                {
                                    results = exercises.FindAll
                                    (exercise => exercise.MuscleGroup ==
                                    "Arms");
                                }
                                if (results.Count != 0)
                                {
                                    foreach (Exercise exercise in results)
                                        
                                {
                                        Console.WriteLine("\nName:{ 0}\nMuscle group:{ 1}\nDifficulty: { 2}\nDescription: { 3}", exercise.Name,exercise.MuscleGroup,exercise.Difficulty, exercise.Description);
                        Console.WriteLine();
                    }
                    Console.WriteLine("Results was saved to file");
                    File.WriteAllText("Results.json",
                    JsonSerializer.Serialize(results));
                }
else
                {
                    Console.WriteLine("No exercises found.");
}
            }
            public static void Read(List<Exercise> exercises)
            {
                if (exercises.Count < 1)
                {
                    Console.WriteLine("No exercises in the base");
                   
                }
                else
                {
                    int i = 1;
                    while (true)
                    {
                        foreach (Exercise exercise in exercises)
                        {
                            Console.WriteLine(exercises.IndexOf
                            (exercise) + 1 + ") " + exercise.Name + "\n");
                            i++;
                        }
                        Console.WriteLine("1-" + exercises.Count + " - Select exercise");
                        Console.WriteLine(exercises.Count + 1 + " - Back");
                        int select = Convert.ToInt32(Console.ReadLine());
                        if (select == exercises.Count + 1)
                        {
                            break;
                        }
                        else if (select > 0 && select <= exercises.Count)
                        {
                            
                        while (true)
                            {
                                Console.WriteLine("\nName: {0}\nMuscle group: { 1}\nDifficulty: { 2}\nDescription:{ 3}", exercises[select - 1].Name, exercises[select - 1].MuscleGroup, exercises[select - 1].Difficulty, exercises[select - 1].Description);
                                Console.WriteLine();
                                Console.WriteLine("You want to do something with this exercise ? ");
                                Console.WriteLine("1 - delete");
                                Console.WriteLine("2 - edit");
                                Console.WriteLine("3 - exit");
                                string? action = Console.ReadLine();
                                if (action == "3")
                                {
                                    break;
                                }
                                else if (action == "1")
                                {
                                    
                                exercises.RemoveAt(select - 1);
                                    Console.WriteLine("succesfull deleted");
                                    break;
                                }
                                else if (action == "2")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("What you want to edit ? ");
                                        Console.WriteLine("1 - Name");
                                        Console.WriteLine("2 - Muscle group");
                                        Console.WriteLine("3 - Difficulty");
                                        Console.WriteLine("4 -Description");
                                        Console.WriteLine("5 - Exit");
                                        string? action2 =
                                        Console.ReadLine();
                                        if (action2 == "1")
                                        {
                                            Console.WriteLine("Enter new                                           name: ");
                                            string ? name =
                                            Console.ReadLine();
                                            Console.WriteLine();
                                            while (name == null ||
                                            name == "")
                                            {
                                                Console.WriteLine("You write                                                nothing, try again: ");
                                                name = Console.ReadLine();
                                                Console.WriteLine();
                                                }
exercises[select - 1].Name = name;
                                            }else if (action2 == "2")
                                            {
                                                Console.WriteLine("Select new                                                muscle group: ");
                                                Console.WriteLine("1 - Chest");
                                                Console.WriteLine("2 - Back");
                                                
                                            Console.WriteLine("3 - Legs");
                                                Console.WriteLine("4 - Arms");
                                                Console.WriteLine();
                                                string? muscleGroup =
                                                Console.ReadLine();
                                                Console.WriteLine();
                                                while (muscleGroup != "1" &&
                                                muscleGroup != "2" &&
                                                muscleGroup != "3" &&
                                                muscleGroup != "4")
                                                {
                                                    Console.WriteLine("You write                                                    incorrect command, try again: ");
                                                    muscleGroup
                                                    = Console.ReadLine();
                                                    Console.WriteLine();
                                                    }
if (muscleGroup == "1")
                                                    {
                                                       
muscleGroup = "Chest";
                                                    }
                                                    else if (muscleGroup == "2")
                                                    {
                                                        muscleGroup = "Back";
                                                    }
                                                    else if (muscleGroup == "3")
                                                    {
                                                        muscleGroup = "Legs";
                                                    }
                                                    else if (muscleGroup == "4")
                                                    {
                                                        muscleGroup = "Arms";
                                                    }
                                                    exercises[select
                                                    - 1].MuscleGroup = muscleGroup;
                                                }
else if (action2 == "3")
                                                {
                                                    
Console.WriteLine("Select newdifficulty from 1 to 5:");
        string? difficulty =
        Console.ReadLine();
            Console.WriteLine();
            while (difficulty != "1" &&
            difficulty != "2" &&
            difficulty != "3" &&
            difficulty != "4" &&
            difficulty != "5")
            {
                Console.WriteLine("You write                incorrect command, try again: ");
                difficulty =
                Console.ReadLine();
                Console.WriteLine();
                }
exercises[select - 1].Difficulty
= difficulty;
            }
            
else if (action2 == "4")
            {
                Console.WriteLine("Enter new                description: ");                string ? description =
                Console.ReadLine();
                Console.WriteLine();
                while (description == null ||
                description == "")
                {
                    Console.WriteLine("You write                    nothing, try again: ");
                    description =
                    Console.ReadLine();
                    Console.WriteLine();
                    }
exercises[select-1].Description = description;
                }else if (action2 == "5")
                   
{
                    break;
                }
else
                {
                    Console.WriteLine("Incorrect                    command try again: ");
                    }
}
            }
        }
    } else {
Console.WriteLine("try again:");
}
}
}
}
public static void SortByDifficult(List<Exercise> exercises)
{
    exercises.Sort(delegate (Exercise x, Exercise y)
    {
        if (x.Difficulty == null && y.Difficulty == null) return
        
    0;
else if (x.Difficulty == null) return -1;
        else if (y.Difficulty == null) return 1;
        else return x.Difficulty.CompareTo(y.Difficulty);
    });
    Console.WriteLine("Base was sorted succesfuly");
    foreach (Exercise exercise in exercises)
    {
        Console.WriteLine("\nName: {0}\nDifficulty: {1}",
        exercise.Name,
        exercise.Difficulty);
        Console.WriteLine();
    }
}
}
}
