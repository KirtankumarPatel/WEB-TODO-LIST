using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspCore_MVC_Todo.Models.Entities
{

    // Todo table entity modal 
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        [Required]
        public string Task { get; set; }
        public bool IsCompleted { get; set; } = false;

        [Display(Name = "CompleteOn")]
        [DataType(DataType.Date)]
        public DateTime? CompleteOn { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; } = DateTime.Now;

    }
}
