namespace TemplarTaskManager.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public required string Opis { get; set; }
        public bool isCompleted { get; set; }
    }
}
