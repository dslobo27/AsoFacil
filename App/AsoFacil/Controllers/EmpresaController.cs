using AsoFacil.Models.Empresa;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AsoFacil.Controllers
{
    public class EmpresaController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult EditarCadastro()
        {
            var model = new EditarEmpresaViewModel
            {
                CNPJ = "70.918.873/0001-63",
                RazaoSocial = "IBLUE CONSULTING LTDA",
                Email = "rh@iblueconsulting.com.br",
                Id = Guid.NewGuid()
            };

            return View("EditarCadastro", model);
        }
    }
}
