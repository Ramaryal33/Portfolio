using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home() => View();
        public IActionResult About() => View();         // About Me
        public IActionResult Portfolio() => View();     // Portfolio
        public IActionResult Resume() => View();        // Resume
        public IActionResult Blog() => View();          // Blog
        public IActionResult Contact() => View();       // Contact

        public IActionResult HireMe () => View();
    }
}

// In Controllers/ContactController.cs
public class ContactController : Controller
{
    public IActionResult HireMe()
    {
        return RedirectToAction("Contact"); 
                                            
    }
}


