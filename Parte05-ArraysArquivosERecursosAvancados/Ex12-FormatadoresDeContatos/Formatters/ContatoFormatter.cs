using Ex12.FormatadoresDeContatos.Models;

namespace Ex12.FormatadoresDeContatos.Formatters;

public class ContatoFormatter
{
    public virtual void ExibirContatos(List<Contato> contatos)
    {
        throw new NotImplementedException("Escolha um formato de exibição.");
    }
}
