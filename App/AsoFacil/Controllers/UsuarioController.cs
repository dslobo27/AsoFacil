using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AsoFacil.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }
    }
}