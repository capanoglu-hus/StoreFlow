using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;
using StoreFlow.Entities;
using System.Linq;

namespace StoreFlow.Controllers
{
    public class TodoController : Controller
    {
        private readonly StoreContext _context;
        public TodoController(StoreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateTodos()
        {
            var todos = new List<Todo>
            {
                new Todo  { Description = "Mail gönder" , Status = true, Priority ="birincil" },
                new Todo  { Description = "kargo gönder" , Status = true, Priority ="ikincil" },
                new Todo  { Description = "toplantıya katıl" , Status = true, Priority ="birincil" }

            };
            _context.Todos.AddRange(todos);
            _context.SaveChanges();
            return View();
        }

        public IActionResult TodoAggregate()
        {
            var priorityFirstyTodo = _context.Todos
                .Where(z => z.Priority == "birincil")
                .Select(y => y.Description)
                .ToList();

            string result = priorityFirstyTodo.Aggregate((acc, desc) => acc + "\n" + "-" + desc);
            ViewBag.results = result;
            return View();
        }

        public IActionResult IncompleteTask()
        {
            var values = _context.Todos
                .Where(x => !x.Status)
                .Select(y => y.Description)
                .ToList()
                .Prepend("gün sonunda tüm görevleri kontrol et")
                .ToList();

            return View(values);
        }

        public IActionResult TodoCrunk()
        {
            var values = _context.Todos
                .Where(x => !x.Status)
                .ToList()
                .Chunk(2)
                .ToList();

            return View(values);
        }
        public IActionResult TodoConcat()
        {
            var values = _context.Todos
                .Where(x => x.Priority == "birincil")
                .ToList()
                .Concat(
                _context.Todos.Where(y => y.Priority == "ikincil")).ToList();

            return View(values);

        }

        public IActionResult TodoUnion()
        {
            var values = _context.Todos.Where(x => x.Priority == "birincil").ToList();
            var values2 = _context.Todos.Where(x => x.Priority == "ikincil").ToList();
            var result = values.UnionBy(values2 , x => x.Description).ToList();
            return View(result);
            
        }
    }
}
