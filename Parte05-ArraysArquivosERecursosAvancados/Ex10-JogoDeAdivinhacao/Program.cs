namespace Ex10.JogoDeAdivinhacao;

internal class Program
{
    private static void Main()
    {
        Random random = new Random();
        int numeroAleatorio = random.Next(1, 51);

        int tentativas = 0;
        while (tentativas < 5)
        {
            Console.Write("Digite um número de 1 a 50: ");
            string? entrada = Console.ReadLine();

            if (entrada == null)
            {
                return;
            }

            int jogada;
            try
            {
                jogada = int.Parse(entrada);
            }
            catch (FormatException)
            {
                Console.WriteLine("Digite um número inteiro válido.");
                continue;
            }

            if (jogada < 1 || jogada > 50)
            {
                Console.WriteLine("Digite apenas números de 1 a 50.");
                continue;
            }

            tentativas++;

            if (jogada == numeroAleatorio)
            {
                Console.WriteLine("Parabéns, você acertou!");
                return;
            }

            if (tentativas < 5)
            {
                Console.WriteLine("Você errou, tente novamente!");
            }
        }

        Console.WriteLine($"Suas 5 tentativas acabaram. O número era {numeroAleatorio}.");
    }
}
