using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace CiberGestion.Dominio.Util
{
    public class Email
    {
        public string EmailDestinatario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

        public Email(string emaildestinatario)
        {
            this.EmailDestinatario = emaildestinatario;
        }

        public bool Enviar(string login, string nome, string email, string senha)
        {
            var retorno = false;

            var smtpUsuario = WebConfigurationManager.AppSettings["smtpUsuario"];
            var smtpSenha = WebConfigurationManager.AppSettings["smtpSenha"];
            var hostRemetente = WebConfigurationManager.AppSettings["hostRemetente"];
            var hostSmtp = WebConfigurationManager.AppSettings["hostSMTP"];
            var hostPort = WebConfigurationManager.AppSettings["hostPORT"];

            var html = WebConfigurationManager.AppSettings["htmlEsqueciSenha"];
            var assunto = WebConfigurationManager.AppSettings["assuntoEsqueciSenha"];

            html = System.IO.File.ReadAllText(html);

            html = html.Replace("#USUARIO#", nome)
                .Replace("#LOGIN#", login)
                .Replace("#SENHA#", Crypto.Decrypt(senha, Crypto.Key256, 256));

            using (var client = new SmtpClient(hostSmtp, Convert.ToInt16(hostPort)))
            {

                client.Credentials = new NetworkCredential(smtpUsuario, smtpSenha);
                client.EnableSsl = true;

                try
                {
                    var msg = new MailMessage(hostRemetente, email, assunto, html) {IsBodyHtml = true};

                    client.Send(msg);
                    retorno = true;

                }
                catch (Exception ex)
                {
                }

                return retorno;
            }
        }
    }
}
