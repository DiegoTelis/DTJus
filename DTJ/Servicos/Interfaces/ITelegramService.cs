using DTJ.Models;

namespace DTJ.Servicos.Interfaces;

public interface ITelegramService
{
    Task<HttpResponseMessage> EnviarMenssagem(string menssagem, Message messageRececebida, string markDown ="HTML", HttpContent content = null);
    Task<Resultado> GetUpdates();

    Task LerTelegram(bool ativo);
}
