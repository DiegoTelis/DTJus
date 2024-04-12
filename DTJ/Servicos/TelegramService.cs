using DTJ.Data;
using DTJ.Models;
using DTJ.Servicos.Interfaces;
using Irony.Parsing;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;

namespace DTJ.Servicos;

public class TelegramService : ITelegramService
{
    HttpClient client = new HttpClient();
    StringBuilder Historico = new StringBuilder();
    string caminho = "";
    string baseApiUri = "https://api.telegram.org/bot";
    string _tokenApiUri = "";
    bool _ativo = false;
    int UltimoID = 0;

    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<ITelegramService> logger;
    private readonly ApplicationDbContext _context;
    //deixando como referencia apenas
    public TelegramService(IWebHostEnvironment environment,
                         ILogger<ITelegramService> logger,
                         ApplicationDbContext context)
    {
       
        _tokenApiUri = Configuracao.HashBot;
        _context = context;
    }




    async Task<HttpResponseMessage> RequestAsync(string endPoint, HttpContent content)
    {
        try
        {
            var response = await client.PostAsync($"{baseApiUri}{_tokenApiUri}/{endPoint}", content);

            return response;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    StringContent CriaStringContent(object body)
    {
        var json = JsonSerializer.Serialize(body);
        return new StringContent(json, Encoding.UTF8, "application/json");
    }

    public Task<HttpResponseMessage> EnviarMenssagem(string menssagem, Message messageRececebida, string markDown = "HTML", HttpContent content = null)
    {

        if (content is null)
        {
            content = CriaStringContent(new
            {
                chat_id = messageRececebida.chat.id,
                text = menssagem,
                parse_mode = markDown

            });
        }

        return RequestAsync("sendMessage", content);
    }

    public async Task<Resultado> GetUpdates()
    {
        var httpContent = CriaStringContent(new { offset = UltimoID });

        var response = await RequestAsync("getUpdates", httpContent);
        if (response != null)
        {
            var responseBody = await response.Content.ReadAsStringAsync();

            Resultado data = new Resultado();
            data = JsonSerializer.Deserialize<Resultado>(responseBody);
            return data;
        }
        else
            return null;
    }

    public async Task LerTelegram(bool ativo)
    {
        _ativo = ativo;
        while (_ativo)
        {
            var resultado = await GetUpdates();
            
            if(resultado is not null)
            {

                foreach (var item in resultado.result)
                {
                    
                    if(item.message is not null && !item.message.from.is_bot)
                    {
                        Responder(item.message);

                    }
                    UltimoID = item.update_id + 1;
                } 
                
            }


            await Task.Delay(5000);
        }
        
    }

    private void Responder(Message message)
    {
        StringBuilder msg = new();

        if (message.text == "/inicio")
        {
            msg.AppendLine($"Olá: {message.from.first_name}");
            msg.AppendLine("Selecione a forma de pesquisa abaixo:");


            var content = CriaStringContent(new
            {
                chat_id = message.chat.id,
                text = msg.ToString(),
                parse_mode = "HTML",
                //protect_content = true
                //,
                reply_markup = new
                {
                    keyboard = new[] {
                new[] { new { text = "Protocolo" }, new { text = "CPF"}, new { text = "Telefone"} }
            }
                },
            });

            RequestAsync("sendMessage", content);

            caminho = "0-";
        }
        else if (caminho == "0-")
        {
            string[] entradas = ["Protocolo", "CPF", "Telefone"];
            if (entradas.Contains(message.text))
            {
                msg.AppendLine($"Digita o numero do <b>{message.text}</b>:");

                caminho += message.text.Substring(0, 1);

                EnviarMenssagem(msg.ToString(), message);
            }
            else
                EnviarMenssagem("Não foi possivel Identificar seu método de pesquisa, tente novamente.", message);
        }
        else if (caminho == "0-P")
        {
            Tarefa t = _context.Tarefas.Include(p => p.Pessoa).AsNoTracking().FirstOrDefault(x => x.NumProtocolo.Contains(message.text));
            msg.AppendLine($"Protocolo numero: <b>{t.NumProtocolo}</b>\t\tData final: {t.DataVencimento.ToString("d")}");
            msg.AppendLine($"Pessoa: {t.Pessoa.Nome}");
            msg.AppendLine($"Descrição: {t.Descricao}");
            msg.AppendLine($"Obs: {t.Observacao}");

            EnviarMenssagem(msg.ToString(), message);
        }
        else if (caminho == "0-C")
        {
            var pessoa = _context.Pessoas.AsNoTracking().FirstOrDefault(c => c.CPF == message.text);
            if (pessoa == null)
            {
                EnviarMenssagem("CPF não encontrado", message);
                return;
            }

            var tarefas = _context.Tarefas.Include(p => p.Pessoa).AsNoTracking().Where(x => x.PessoaId == pessoa.Id ).ToList().OrderByDescending(d => d.DataVencimento);
            if(tarefas.Any() )
            {
                foreach (var t in tarefas)
                {
                    msg.AppendLine($"Protocolo numero: <b>{t.NumProtocolo}</b>\t\tData final: {t.DataVencimento.ToString("d")}");
                    msg.AppendLine($"Pessoa: {t.Pessoa.Nome}");
                    msg.AppendLine($"Descrição: {t.Descricao}");
                    msg.AppendLine($"Obs: {t.Observacao}");

                    EnviarMenssagem(msg.ToString(), message);
                    msg.Clear();
                }

                
            }
            else
                EnviarMenssagem("Não foram encontradas tarefa's ligada à este cliente.", message);
        }
        else if (caminho == "0-T")
        {
            var pessoa = _context.Pessoas.AsNoTracking().FirstOrDefault(t => t.Telefone == message.text);
            if (pessoa == null)
            {
                EnviarMenssagem("Telefone não encontrado", message);
                return;
            }

            var tarefas = _context.Tarefas.Include(p => p.Pessoa).AsNoTracking().Where(x => x.PessoaId == pessoa.Id).ToList().OrderByDescending(d => d.DataVencimento);
            if (tarefas.Any())
            {
                foreach (var t in tarefas)
                {
                    msg.AppendLine($"Protocolo numero: <b>{t.NumProtocolo}</b>\t\tData final: {t.DataVencimento.ToString("d")}");
                    msg.AppendLine($"Pessoa: {t.Pessoa.Nome}");
                    msg.AppendLine($"Descrição: {t.Descricao}");
                    msg.AppendLine($"Obs: {t.Observacao}");

                    EnviarMenssagem(msg.ToString(), message);
                    msg.Clear();
                }


            }
            else
                EnviarMenssagem("Não foram encontradas tarefa's ligada à este cliente.", message);
        }


    }




}
