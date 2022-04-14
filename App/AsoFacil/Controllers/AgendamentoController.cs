using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsoFacil.Controllers
{
    public class AgendamentoController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }
    }
}
