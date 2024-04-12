using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTJ.Models;

[Table("Tarefa")]
public class Tarefa
{
    [Key]
    public int Id { get; set; }


    [Required(ErrorMessage = "É necessario informar a Descricao")]
    [MaxLength(200,ErrorMessage = "Descricao deve ter no máximo 200 caracteres")]
    public string Descricao { get; set; }
    public string NumProtocolo { get; set; }

    [Required(ErrorMessage ="É necessario informar a pessoa")]
    public int PessoaId { get; set; }
    public Pessoa Pessoa { get; set; }

    [Required(ErrorMessage ="É preciso informar o Tipo")]
    public string Tipo { get; set; }

    [Required(ErrorMessage = "É preciso informar a Data de Criação")]
    public DateTime DataCriacao { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "É preciso informar a Data Final")]
    public DateTime DataVencimento { get; set; } = DateTime.Now;

    public string? Observacao { get; set; }

    public bool Concluido { get; set; }

    public List<ContasAReceber>? Recebimentos { get; set; }

}
