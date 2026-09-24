using Ex12.FormatadoresDeContatos.Models;

namespace Ex12.FormatadoresDeContatos.Formatters;

public class TabelaFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        const string separador = "----------------------------------------";

        Console.WriteLine(separador);
        Console.WriteLine("| Nome | Telefone | Email |");
        Console.WriteLine(separador);

        foreach (Contato contato in contatos)
        {
            Console.WriteLine($"| {contato.Nome} | {contato.Telefone} | {contato.Email} |");
        }

        Console.WriteLine(separador);
    }
}
