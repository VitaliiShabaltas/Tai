using System.Text.Json;

namespace trainingBase
{
    class ListOfExercises
    {
        public static List<Exercise> LoadFromFile()
        {
            List<Exercise> exercises =
            JsonSerializer.Deserialize<List<Exercise>>(File.ReadAllText
            ("ExerciseBase.json"))!;
            return exercises;
        }
        public static void LoadToFile(List<Exercise> exercises)
        {
            File.WriteAllText("ExerciseBase.json",
            JsonSerializer.Serialize(exercises));
        }
    }
}
