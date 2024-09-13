namespace NoBSPlanner.Models
{
    public class PlannerItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public DateTime DueDate { get; set; }
        public bool isCompleted {get; set; }
    }
}
