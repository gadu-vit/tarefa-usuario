using Microsoft.AspNetCore.Mvc;

namespace ApiTarefaUsuario.Controllers
{
    public class AdminController : Controller
    {
        private IConfiguration Configuration;
        public AdminController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public IActionResult Index()
        {
            ViewBag.msg = this.Configuration.GetConnectionString("DefaultConnection");
            return View();
        }
    }
}
