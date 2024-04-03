using DTJ.Components.Compartilhado.Enums;
using DTJ.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DTJ.Models;

[Table("ContasAReceber")]
public class ContasAReceber
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Descrição é Obrigatório")]
    [MaxLength(150, ErrorMessage ="Tamanho máximo do campo é 150 caracteres")]
    public string Descricao { get; set; } = String.Empty;

    public RecebimentoEnum TipoRecebimento { get; set; } 

    [Required]
    public double ValorBase { get; set; }
    public double Adicional { get; set; }
    public double Desconto{ get; set; }
    public double Total { get { return ValorBase + Adicional - Desconto; } }
    public double ValorRecebido { get; set; }

    public DateTime DataLancamento { get; set; } = DateTime.Now;
    public DateTime DataVencimento { get; set; } = DateTime.Now.AddMonths(1);
    public DateTime? DataRecebimento { get; set; }
    public char Status { get; set; } = 'A';
    public int Parcela { get; set; } = 1;

    [MaxLength(250,ErrorMessage ="Tamanho máximo 250 caracteres")]
    public string? Observacao { get; set; }

    public int TarefaId { get; set; }
    public Tarefa? Tarefa { get; set; }
    [Required(ErrorMessage ="É preciso selecionar o Cliente")]
    public int PessoaId { get; set; }
    public Pessoa? Pessoa { get; set; }

   
}
