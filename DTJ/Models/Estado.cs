namespace DTJ.Models;

public class Estado
{
    public Estado()
    {
        PreencheEstados();
    }
    private string Sigla { get; set; } = null!;
    private string Nome { get; set; } = null!;

    public List<Estado> Estados = new();


    private void PreencheEstados()
    {
        Estados.Add(new Estado() { Sigla = "AC", Nome = "Acre" });
        Estados.Add(new Estado() { Sigla = "AL", Nome = "Alagoas" });
        Estados.Add(new Estado() { Sigla = "AP", Nome = "Amapá" });
        Estados.Add(new Estado() { Sigla = "AM", Nome = "Amazonas" });
        Estados.Add(new Estado() { Sigla = "BA", Nome = "Bahia" });
        Estados.Add(new Estado() { Sigla = "CE", Nome = "Ceará" });
        Estados.Add(new Estado() { Sigla = "ES", Nome = "Espírito Santo" });
        Estados.Add(new Estado() { Sigla = "GO", Nome = "Goiás" });
        Estados.Add(new Estado() { Sigla = "MA", Nome = "Maranhão" });
        Estados.Add(new Estado() { Sigla = "MT", Nome = "Mato Grosso" });
        Estados.Add(new Estado() { Sigla = "MS", Nome = "Mato Grosso do Sul" });
        Estados.Add(new Estado() { Sigla = "MG", Nome = "Minas Gerais" });
        Estados.Add(new Estado() { Sigla = "PA", Nome = "Pará" });
        Estados.Add(new Estado() { Sigla = "PB", Nome = "Paraíba" });
        Estados.Add(new Estado() { Sigla = "PR", Nome = "Paraná" });
        Estados.Add(new Estado() { Sigla = "PE", Nome = "Pernambuco" });
        Estados.Add(new Estado() { Sigla = "PI", Nome = "Piauí" });
        Estados.Add(new Estado() { Sigla = "RJ", Nome = "Rio de Janeiro" });
        Estados.Add(new Estado() { Sigla = "RN", Nome = "Rio Grande do Norte" });
        Estados.Add(new Estado() { Sigla = "RS", Nome = "Rio Grande do Sul" });
        Estados.Add(new Estado() { Sigla = "RO", Nome = "Rondônia" });
        Estados.Add(new Estado() { Sigla = "RR", Nome = "Roraima" });
        Estados.Add(new Estado() { Sigla = "SC", Nome = "Santa Catarina" });
        Estados.Add(new Estado() { Sigla = "SP", Nome = "São Paulo" });
        Estados.Add(new Estado() { Sigla = "SE", Nome = "Sergipe" });
        Estados.Add(new Estado() { Sigla = "TO", Nome = "Tocantins" });
        Estados.Add(new Estado() { Sigla = "DF", Nome = "Distrito Federal" });

    }
}
