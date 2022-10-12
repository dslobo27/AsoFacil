using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AsoFacil.Presentation.Controllers.MultiTenant
{
    public class MultiTenantController : Controller
    {
        private string claimEmpresaId =>
             User.Claims.FirstOrDefault(x => x.Type.Equals("EMPRESA_ID", StringComparison.OrdinalIgnoreCase))?.Value;

        private string claimCodigoTipoUsuario =>
             User.Claims.FirstOrDefault(x => x.Type.Equals("COD_TIPO_USUARIO", StringComparison.OrdinalIgnoreCase))?.Value;

        public Guid empresaId => claimCodigoTipoUsuario != "ASOFACIL_ADMIN" ? Guid.Parse(claimEmpresaId) : Guid.Empty;
    }
}