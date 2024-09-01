using Microsoft.AspNetCore.Mvc;
using task2asp9.Data;
using task2asp9.Models;

namespace task2asp9.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext context;

        public UserController(ApplicationDbContext context)
        {
            this.context = context;
        }
       
        public IActionResult Index()
        {
            var users = context.users.Where(x => x.IsActive == false).ToList();
            return View(users);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            context.users.Add(user);
            context.SaveChanges();
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login() { return View(); }
        [HttpPost]
        public IActionResult Login(User user)
        {

            var CheckUser = context.users.Where(x => x.UserName == user.UserName && x.Password == user.Password);

            if (CheckUser.Any())
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Error = "error username / pasword";

            return View(user);

        }
        public IActionResult Edit(int id)
        {

            var user = context.users.Find(id);
            user.IsActive = true;
            context.SaveChanges();
            return RedirectToAction("Index", user);

        }
    }
}
