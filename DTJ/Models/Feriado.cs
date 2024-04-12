using System.ComponentModel.DataAnnotations;

namespace DTJ.Models;

public class Feriado
{
    public Feriado()
    {

    }
    public Feriado(string local, DateTime dia, string diaSemana, string descricao, string feriado)
    {
        Local = local;
        Dia = dia;
        DiaSemana = diaSemana;
        Descricao = descricao;
        FeriadoDesc = feriado;
    }
    [Key]
    public int Id { get; set; }
    public string Local { get; set; }
    public DateTime Dia { get; set; }
    public string DiaSemana { get; set; }
    public string Descricao { get; set; }
    public string FeriadoDesc { get; set; }
}
