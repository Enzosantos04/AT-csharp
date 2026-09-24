namespace Ex09A.EstoqueArrays;

internal class Program
{
    private static void Main()
    {
        Produto[] produtos = new Produto[5];
        int totalProdutos = 0;

        while (true)
        {
            int opcao = LerOpcao();

            switch (opcao)
            {
                case 1:
                    InserirProduto(produtos, ref totalProdutos);
                    break;

                case 2:
                    ListarProdutos(produtos, totalProdutos);
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


    private static void InserirProduto(Produto[] produtos, ref int totalProdutos)
    {
        if (totalProdutos >= produtos.Length)
        {
            Console.WriteLine("Limite de produtos atingido!");
            return;
        }

        Console.Write("Nome: ");
        string nomeInput = Console.ReadLine() ?? "";

        Console.Write("Quantidade em estoque: ");
        int quantidadeInput = int.Parse(Console.ReadLine()!);

        Console.Write("Preço unitário: ");
        decimal precoInput = decimal.Parse(Console.ReadLine()!);

        produtos[totalProdutos] = new Produto
        {
            Nome = nomeInput,
            Quantidade = quantidadeInput,
            Preco = precoInput
        };

        totalProdutos++;
    }

    private static void ListarProdutos(Produto[] produtos, int totalProdutos)
    {
        for (int i = 0; i < totalProdutos; i++)
        {

            Produto produto = produtos[i];
            Console.WriteLine(
                $"Produto: {produto.Nome} | Quantidade: {produto.Quantidade} | Preço: R$ {produto.Preco}");
        }
    }
}
