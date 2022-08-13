using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AsoFacil.Controllers
{
    [Authorize]
    public class DocumentoController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }
    }
}