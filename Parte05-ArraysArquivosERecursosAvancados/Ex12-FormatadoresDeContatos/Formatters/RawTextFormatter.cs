using Ex12.FormatadoresDeContatos.Models;

namespace Ex12.FormatadoresDeContatos.Formatters;

public class RawTextFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        foreach (Contato contato in contatos)
        {
            Console.WriteLine(
                $"Nome: {contato.Nome} | Telefone: {contato.Telefone} | Email: {contato.Email}");
        }
    }
}
