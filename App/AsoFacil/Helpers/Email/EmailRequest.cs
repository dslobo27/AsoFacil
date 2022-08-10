using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace AsoFacil.Helpers.Email
{
    public class EmailRequest
    {
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public string Destinatario { get; set; }
    }

    public static class EmailRequestExtension
    {
        public static void DisableCertificateValidation()
        {
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (
                    object s,
                    X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors
                )
                {
                    return true;
                };
        }
    }
}