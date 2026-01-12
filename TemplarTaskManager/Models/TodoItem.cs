using System.ComponentModel.DataAnnotations;

namespace TemplarTaskManager.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Opis jest wymagany!")] // Nie można dodać zadania bez opisu
        [MaxLength(100)] // Opis nie może być dłuższy niż 100 znaków
        public string Opis { get; set; }

        public bool isCompleted { get; set; }
    }
}
