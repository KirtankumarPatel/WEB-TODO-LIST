using AspCore_MVC_Todo.Models;
using AspCore_MVC_Todo.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspCore_MVC_Todo.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoDbContext _context;
        public TodoController(TodoDbContext context)
        {
            _context = context;
        }

        // GET: ToDoList
        [HttpGet]
        public IActionResult Index()
        {
            var todos = _context.Todo.ToList();

            if (todos == null)
                return View(new Todos());

            List<TodoViewModal> todoList = new List<TodoViewModal>();
            foreach (var todo in todos)
            {
                todoList.Add(new TodoViewModal() { Id = todo.Id, CompleteOn = todo.CompleteOn, IsCompleted = todo.IsCompleted, Task = todo.Task });
            }
            return View(new Todos() { TodoList = todoList });
        }


        // GET: ToDo/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new TodoViewModal());
        }

        // POST: ToDo/Create
        [HttpPost]
        public IActionResult Create(TodoViewModal viewModal)
        {
            if (ModelState.IsValid)
            {
                var todo = new Todo()
                {
                    Task = viewModal.Task,
                };

                _context.Add(todo);
                _context.SaveChanges();
                TempData["Success"] = "To Do created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(new TodoViewModal());
        }

        // GET: ToDo/MarkToComplete/1
        public async Task<IActionResult> MarkToComplete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoList = await _context.Todo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDoList == null)
            {
                return NotFound();
            }

            toDoList.CompleteOn = DateTime.Now;
            toDoList.IsCompleted = true;
            TempData["Success"] = "To Do completed successfully";
            return RedirectToAction(nameof(Index));
        }       
    }
}
