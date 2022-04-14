using AsoFacil.Models.Conta;
using Microsoft.AspNetCore.Mvc;

namespace AsoFacil.Controllers
{
    public class ContaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(LoginViewModel model)
        {
            if (!string.IsNullOrEmpty(model.Login) 
                && model.Login.Contains("suporte"))
            {
                return RedirectToAction("DashBoard", "");
            }                

            return RedirectToAction("Cadastro", "Candidato");
        }
    }
}
