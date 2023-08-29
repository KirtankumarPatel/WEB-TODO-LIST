using Microsoft.AspNetCore.Mvc;

namespace AspCore_MVC_Todo.Controllers
{
    public class TodoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
