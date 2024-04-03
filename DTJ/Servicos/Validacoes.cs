using System.Text.RegularExpressions;

namespace DTJ.Servicos;

public static class Validacoes
{

    public static bool ApenasNumeros(string texto)
    {
        return Regex.IsMatch(texto, @"^\d+$");
    }
}
