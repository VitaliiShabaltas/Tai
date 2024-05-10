using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace trainingBase
{
    class Exercise

{
public string Name { get; set; }
    public string MuscleGroup { get; set; }
    public string Difficulty { get; set; }
    public string Description { get; set; }
    public Exercise(string name, string muscleGroup, string
    difficulty, string description)
    {
        Name = name;
        MuscleGroup = muscleGroup;
        Difficulty = difficulty;
        Description = description;
    }
}
}