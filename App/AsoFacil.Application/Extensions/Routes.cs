namespace AsoFacil.Application.Extensions
{
    public static class Routes
    {
        #region Empresas

        public const string POST_EMPRESAS = "api/empresas/v1/postasync";
        public const string PUT_EMPRESAS = "api/empresas/v1/putasync";
        public const string DELETE_EMPRESAS = "api/empresas/v1/deleteasync/{empresaId}";
        public const string GET_EMPRESAS = "api/empresas/v1/getasync";
        public const string GETBYID_EMPRESAS = "api/empresas/v1/getbyidasync/{empresaId}";

        #endregion Empresas

        #region Usuarios

        public const string LOGIN = "api/usuarios/v1/loginasync";
        public const string POST_USUARIOS = "api/usuarios/v1/postasync";
        public const string PUT_USUARIOS = "api/usuarios/v1/putasync";
        public const string DELETE_USUARIOS = "api/usuarios/v1/deleteasync/{usuarioId}";
        public const string GET_USUARIOS = "api/usuarios/v1/getasync";
        public const string GETBYID_USUARIOS = "api/usuarios/v1/getbyidasync/{usuarioId}";

        #endregion Usuarios
    }
}