using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AsoFacil.Controllers
{
    [Authorize]
    public class StatusdeSolicitacaodeAtivacaoController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }
    }
}