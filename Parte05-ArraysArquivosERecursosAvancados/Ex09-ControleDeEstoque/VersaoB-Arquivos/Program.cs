namespace Ex09B.EstoqueArquivos;

internal class Program
{
    private static void Main()
    {
      string caminhoArquivo = Path.GetFullPath(
          Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "estoque.txt"));
      
      if (!File.Exists(caminhoArquivo))
      {
          using (StreamWriter escritor = File.AppendText(caminhoArquivo))
          {
          }

          Console.WriteLine($"Arquivo de estoque criado em: {caminhoArquivo}");
      }

        while (true) {
            int opcao = LerOpcao();

            switch (opcao)
            {
                case 1:
                    InserirProduto(caminhoArquivo);
                    break;

                case 2:
                    ListarProdutos(caminhoArquivo);
                    break;

                case 3:
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
            Console.WriteLine("\nEscolha uma operação:");
            Console.WriteLine("1. Inserir Produto");
            Console.WriteLine("2. Listar Produtos");
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


    private static void InserirProduto(string caminhoArquivo)
    {
        try
        {
            int totalProdutos = 0;

            using (StreamReader leitor = new(caminhoArquivo))
            {
                while (leitor.ReadLine() != null)
                {
                    totalProdutos++;
                }
            }

            if (totalProdutos >= 5)
            {
                Console.WriteLine("Limite de produtos atingido!");
                return;
            }

            Console.Write("Nome: ");
            string nome = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(nome) || nome.Contains(','))
            {
                Console.WriteLine("Nome inválido.");
                return;
            }

            Console.Write("Quantidade em estoque: ");
            if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade < 0)
            {
                Console.WriteLine("Quantidade inválida.");
                return;
            }

            Console.Write("Preço unitário: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal preco) || preco < 0)
            {
                Console.WriteLine("Preço inválido.");
                return;
            }

            Produto produto = new()
            {
                Nome = nome,
                Quantidade = quantidade,
                Preco = preco
            };
            

            using (StreamWriter escritor = File.AppendText(caminhoArquivo))
            {
                escritor.WriteLine(
                    $"{produto.Nome},{produto.Quantidade},{produto.Preco.ToString("F2").Replace(',', '.')}");
            }

            Console.WriteLine("Produto salvo com sucesso!");
        }
        catch (IOException erro)
        {
            Console.WriteLine($"Erro ao acessar o arquivo: {erro.Message}");
        }
    }

    private static void ListarProdutos(string caminhoArquivo)
    {
        try
        {
            using StreamReader leitor = new(caminhoArquivo);

            bool encontrouProduto = false;
            int numeroLinha = 0;
            string? linha;

            while ((linha = leitor.ReadLine()) != null)
            {
                numeroLinha++;
                string[] campos = linha.Split(',');

                if (campos.Length != 3 ||
                    string.IsNullOrWhiteSpace(campos[0]) ||
                    !int.TryParse(campos[1], out int quantidade) ||
                    quantidade < 0 ||
                    !decimal.TryParse(campos[2], out _))
                {
                    Console.WriteLine($"Linha {numeroLinha} inválida; ignorada.");
                    continue;
                }

                string precoExibicao = campos[2].Replace('.', ',');

                Console.WriteLine(
                    $"Produto: {campos[0]} | Quantidade: {quantidade} | Preço: R$ {precoExibicao}");

                encontrouProduto = true;
            }

            if (!encontrouProduto)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
            }
        }
        catch (IOException erro)
        {
            Console.WriteLine($"Erro ao acessar o arquivo: {erro.Message}");
        }
    }
}
