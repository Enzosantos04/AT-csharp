using Ex12.FormatadoresDeContatos.Formatters;
using Ex12.FormatadoresDeContatos.Models;

namespace Ex12.FormatadoresDeContatos;

internal class Program
{
    private static void Main()
    {
        string caminhoArquivo = Path.GetFullPath(
            Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "contatos.txt"));

        while (true)
        {
            Console.WriteLine("\n=== Gerenciador de Contatos ===");
            Console.WriteLine("1 - Adicionar novo contato");
            Console.WriteLine("2 - Listar contatos cadastrados");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AdicionarContato(caminhoArquivo);
                    break;

                case "2":
                    ListarContatos(caminhoArquivo);
                    break;

                case "3":
                    Console.WriteLine("Encerrando programa...");
                    return;

                default:
                    Console.WriteLine("Opção inválida. Digite 1, 2 ou 3.");
                    break;
            }
        }
    }

    private static void AdicionarContato(string caminhoArquivo)
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine() ?? "";

        Console.Write("Telefone: ");
        string telefone = Console.ReadLine() ?? "";

        Console.Write("Email: ");
        string email = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(nome) || nome.Contains(',') ||
            string.IsNullOrWhiteSpace(telefone) || telefone.Contains(',') ||
            string.IsNullOrWhiteSpace(email) || email.Contains(','))
        {
            Console.WriteLine("Dados inválidos. Preencha os três campos sem vírgulas.");
            return;
        }

        Contato contato = new()
        {
            Nome = nome,
            Telefone = telefone,
            Email = email
        };

        try
        {
            using (StreamWriter escritor = File.AppendText(caminhoArquivo))
            {
                escritor.WriteLine($"{contato.Nome},{contato.Telefone},{contato.Email}");
            }

            Console.WriteLine("Contato cadastrado com sucesso!");
        }
        catch (IOException erro)
        {
            Console.WriteLine($"Erro ao salvar contato: {erro.Message}");
        }
    }

    private static void ListarContatos(string caminhoArquivo)
    {
        List<Contato> contatos = new();

        try
        {
            LerContatos(caminhoArquivo, contatos);
        }
        catch (IOException erro)
        {
            Console.WriteLine($"Erro ao ler contatos: {erro.Message}");
            return;
        }

        if (contatos.Count == 0)
        {
            Console.WriteLine("Nenhum contato cadastrado.");
            return;
        }

        Console.WriteLine("1 - Markdown");
        Console.WriteLine("2 - Tabela");
        Console.WriteLine("3 - Texto Puro");
        Console.Write("Escolha o formato de exibição: ");

        ContatoFormatter? formatter = Console.ReadLine() switch
        {
            "1" => new MarkdownFormatter(),
            "2" => new TabelaFormatter(),
            "3" => new RawTextFormatter(),
            _ => null
        };

        if (formatter == null)
        {
            Console.WriteLine("Formato inválido.");
            return;
        }

        formatter.ExibirContatos(contatos);
    }

    private static void LerContatos(string caminhoArquivo, List<Contato> contatos)
    {
        if (!File.Exists(caminhoArquivo))
        {
            return;
        }

        using StreamReader leitor = new(caminhoArquivo);
        string? linha;
        int numeroLinha = 0;

        while ((linha = leitor.ReadLine()) != null)
        {
            numeroLinha++;
            string[] campos = linha.Split(',');

            if (campos.Length != 3 ||
                string.IsNullOrWhiteSpace(campos[0]) ||
                string.IsNullOrWhiteSpace(campos[1]) ||
                string.IsNullOrWhiteSpace(campos[2]))
            {
                Console.WriteLine($"Linha {numeroLinha} inválida; ignorada.");
                continue;
            }

            contatos.Add(new Contato
            {
                Nome = campos[0],
                Telefone = campos[1],
                Email = campos[2]
            });
        }
    }
}
