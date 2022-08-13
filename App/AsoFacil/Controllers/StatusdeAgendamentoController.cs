using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AsoFacil.Controllers
{
    [Authorize]
    public class StatusdeAgendamentoController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }
    }
}