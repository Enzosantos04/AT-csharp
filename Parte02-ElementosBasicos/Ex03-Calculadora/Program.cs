namespace Ex03.Calculadora;

internal class Program
{
    private static void Main()
    {
        int option = LerOpcao();
        double numero1 = LerNumero("Digite o primeiro número: ");
        double numero2 = LerNumero("Digite o segundo número: ");
        double resultado;

        switch (option)
        {
            case 1:
                resultado = Somar(numero1, numero2);
                break;

            case 2:
                resultado = Subtrair(numero1, numero2);
                break;

            case 3:
                resultado = Multiplicar(numero1, numero2);
                break;

            case 4:
                // Só o segundo número é o divisor; ele não pode ser zero.
                if (numero2 == 0)
                {
                    Console.WriteLine("Não é possível dividir por zero.");
                    return;
                }

                resultado = Dividir(numero1, numero2);
                break;

            default:
                return;
        }
        Console.WriteLine($"Resultado: {resultado}");
    }

    private static int LerOpcao()
    {
        int opcao;

        // Repete o menu até o usuário escolher uma das quatro operações.
        while (true)
        {
            Console.WriteLine("\nEscolha uma operação:");
            Console.WriteLine("1. Soma");
            Console.WriteLine("2. Subtração");
            Console.WriteLine("3. Multiplicação");
            Console.WriteLine("4. Divisão");
            Console.Write("Opção: ");

            if (int.TryParse(Console.ReadLine(), out opcao) &&
                opcao >= 1 && opcao <= 4)
            {
                return opcao;
            }

            Console.WriteLine("Opção inválida. Digite 1, 2, 3 ou 4.");
        }
    }

    private static double LerNumero(string mensagem)
    {
        double numero;

        // Pede novamente a entrada quando ela não representa um número.
        while (true)
        {
            Console.Write(mensagem);

            if (double.TryParse(Console.ReadLine(), out numero) && double.IsFinite(numero))
            {
                return numero;
            }

            Console.WriteLine("Valor inválido. Digite um número.");
        }
    }

    private static double Somar(double num1, double num2)
    {
        return num1 + num2;
    }

    private static double Subtrair(double num1, double num2)
    {
        return num1 - num2;
    }

    private static double Multiplicar(double num1, double num2)
    {
        return num1 * num2;
    }

    private static double Dividir(double num1, double num2)
    {
        return num1 / num2;
    }
}
