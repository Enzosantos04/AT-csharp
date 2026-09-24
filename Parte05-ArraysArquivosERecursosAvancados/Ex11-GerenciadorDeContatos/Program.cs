namespace Ex11.GerenciadorDeContatos;

internal class Program
{
    private static void Main()
    {
        string caminhoArquivo = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "contatos.txt"));

        try
        {
            if (!File.Exists(caminhoArquivo))
            {
                using (StreamWriter escritor = File.AppendText(caminhoArquivo))
                {
                }

                Console.WriteLine($"Arquivo de contatos criado em: {caminhoArquivo}");
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Erro ao criar o arquivo de contatos: {e.Message}");
        }

        while (true)
        {
            int opcao = LerOpcao();

            switch (opcao)
            {
                case 1:
                    InserirContatos(caminhoArquivo);
                    break;

                case 2:
                    ListarContatos(caminhoArquivo);
                    break;

                case 3:
                    Console.WriteLine("Encerrando programa...");
                    return;
            }
        }
    }
    
    private static int LerOpcao()
    {
        int opcao;

        // Repete o menu até o usuário escolher uma das três opções.
        while (true)
        {
            Console.WriteLine("\n=== Gerenciador de Contatos ===");
            Console.WriteLine("1. Adicionar novo contato");
            Console.WriteLine("2. Listar contatos cadastrados");
            Console.WriteLine("3. Sair");
            Console.Write("Opção: ");

            if (int.TryParse(Console.ReadLine(), out opcao) &&
                opcao >= 1 && opcao <= 3)
            {
                return opcao;
            }
            
            Console.WriteLine("Opção inválida. Digite 1, 2 ou 3.");
        }
    }

    private static void InserirContatos(string caminhoArquivo)
    {

        try
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine() ?? "";
        
            if (string.IsNullOrWhiteSpace(nome) || nome.Contains(','))
            {
                Console.WriteLine("Nome inválido.");
                return;
            }
        
            Console.Write("Telefone: ");
            string telefone =  Console.ReadLine() ?? ""; 
        
            if (string.IsNullOrWhiteSpace(telefone) || telefone.Contains(','))
            {
                Console.WriteLine("Telefone inválido.");
                return;
            }
        
            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";
        
        
            if (string.IsNullOrWhiteSpace(email) || email.Contains(','))
            {
                Console.WriteLine("Email inválido.");
                return;
            }

            Contato contato = new Contato()
            {
                Nome = nome,
                Telefone = telefone,
                Email = email
            };

            using (StreamWriter escritor = File.AppendText(caminhoArquivo))
            {
                escritor.WriteLine(
                    $"{contato.Nome},{contato.Telefone},{contato.Email}");
            }
            
            Console.WriteLine("Contato cadastrado com sucesso!");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Erro ao acessar o arquivo: {e.Message}");
        }
       
        
    }

    private static void ListarContatos(string caminhoArquivo)
    {
        try
        {
            if (!File.Exists(caminhoArquivo))
            {
                Console.WriteLine("Nenhum contato cadastrado.");
                return;
            }

            using StreamReader leitor = new(caminhoArquivo);

            bool encontrouContato = false;
            int numeroLinha = 0;
            string? linha;
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

                if (!encontrouContato)
                {
                    Console.WriteLine("Contatos cadastrados:");
                }

                Console.WriteLine($"Nome: {campos[0]} | Telefone: {campos[1]} | Email: {campos[2]}");

                encontrouContato = true;
            }

            if (!encontrouContato)
            {
                Console.WriteLine("Nenhum contato cadastrado.");
            }


        }
        catch (IOException e)
        {
            Console.WriteLine($"Erro ao acessar o arquivo: {e.Message}");
        }
    }




}
