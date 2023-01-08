namespace NutritionCalc.Web.Models
{
    public class Exercise
    {
        public required string Name { get; init; }
        public List<Set> Sets { get; set; }
        public string Note { get; set; }
    }

    public class Activity
    {
        public string Name { get; set; }
        public string Note { get; set; }
    }

    public class Set
    {
        public int Reps { get; set; }
        public double Weight { get; set; }
        public TimeOnly Rest { get; set; }
    }
    
    public class Repetition 
    {
        public int Count { get; set; }
    }    
}
