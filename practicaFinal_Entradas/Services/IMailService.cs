namespace practicaFinal_Entradas.Services
{
    public interface IMailService
    {
        void EnviarMensaje(string to, string subject, string body);
    }
}