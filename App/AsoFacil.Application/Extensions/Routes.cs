namespace AsoFacil.Application.Extensions
{
    public static class Routes
    {
        #region Empresas

        public const string POST_EMPRESAS = "api/empresas/v1/postasync";
        public const string PUT_EMPRESAS = "api/empresas/v1/putasync";
        public const string DELETE_EMPRESAS = "api/empresas/v1/deleteasync/{id}";
        public const string GET_EMPRESAS = "api/empresas/v1/getasync";
        public const string GETBYID_EMPRESAS = "api/empresas/v1/getbyidasync/{id}";

        #endregion Empresas

        #region Usuarios

        public const string LOGIN = "api/usuarios/v1/loginasync";
        public const string POST_USUARIOS = "api/usuarios/v1/postasync";
        public const string PUT_USUARIOS = "api/usuarios/v1/putasync";
        public const string DELETE_USUARIOS = "api/usuarios/v1/deleteasync/{id}";
        public const string GET_USUARIOS = "api/usuarios/v1/getasync";
        public const string GETBYID_USUARIOS = "api/usuarios/v1/getbyidasync/{id}";

        #endregion Usuarios

        #region Candidatos

        public const string POST_CANDIDATOS = "api/candidatos/v1/postasync";
        public const string PUT_CANDIDATOS = "api/candidatos/v1/putasync";
        public const string DELETE_CANDIDATOS = "api/candidatos/v1/deleteasync/{id}";
        public const string GET_CANDIDATOS = "api/candidatos/v1/getasync";
        public const string GETBYID_CANDIDATOS = "api/candidatos/v1/getbyidasync/{id}";

        #endregion Candidatos

        #region Médicos

        public const string POST_MEDICOS = "api/medicos/v1/postasync";
        public const string PUT_MEDICOS = "api/medicos/v1/putasync";
        public const string DELETE_MEDICOS = "api/medicos/v1/deleteasync/{id}";
        public const string GET_MEDICOS = "api/medicos/v1/getasync";
        public const string GETBYID_MEDICOS = "api/medicos/v1/getbyidasync/{id}";

        #endregion Médicos

        #region Agendamentos

        public const string POST_AGENDAMENTOS = "api/agendamentos/v1/postasync";
        public const string PUT_AGENDAMENTOS = "api/agendamentos/v1/putasync";
        public const string DELETE_AGENDAMENTOS = "api/agendamentos/v1/deleteasync/{id}";
        public const string GET_AGENDAMENTOS = "api/agendamentos/v1/getasync";
        public const string GETBYID_AGENDAMENTOS = "api/agendamentos/v1/getbyidasync/{id}";

        #endregion Agendamentos
    }
}