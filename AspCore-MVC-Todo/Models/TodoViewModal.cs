namespace AspCore_MVC_Todo.Models
{

    // Todos 
    public class Todos
    {
        public List<TodoViewModal> TodoList { get; set; }
    }
    //View modal for getting data
    public class TodoViewModal
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompleteOn { get; set; }
    }

}
