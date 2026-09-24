using System.Globalization;

namespace Ex04.ProximoAniversario;

internal class Program
{
    private static void Main()
    {
        Console.Write("Digite sua data de nascimento (dd/MM/yyyy): ");
        string? input = Console.ReadLine();

        if (!DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime nascimento))
        {
            Console.WriteLine("Data inválida. Use o formato dd/MM/yyyy.");
            return;
        }

        DateTime hoje = DateTime.Today;
        DateTime proximoNiver = ObterAniversario(nascimento, hoje.Year);

        if (proximoNiver < hoje)
        {
            proximoNiver = ObterAniversario(nascimento, hoje.Year + 1);
        }

        int diasRestantes = (proximoNiver - hoje).Days;

        if (diasRestantes > 0 && diasRestantes < 7)
        {
            Console.WriteLine("Atenção: seu aniversário está próximo!");
        }

        if (diasRestantes == 0)
        {
            Console.WriteLine("Hoje é seu aniversário! Parabéns!");
        }
        else if (diasRestantes == 1)
        {
            Console.WriteLine("Falta 1 dia para seu aniversário!");
        }
        else
        {
            Console.WriteLine($"Faltam {diasRestantes} dias para seu aniversário!");
        }
    }

    private static DateTime ObterAniversario(DateTime nascimento, int ano)
    {
        bool nasceuEm29DeFevereiro =
            nascimento.Day == 29 && nascimento.Month == 2;

        if (nasceuEm29DeFevereiro && !DateTime.IsLeapYear(ano))
        {
            // Em anos não bissextos, considera o aniversário em 28 de fevereiro.
            return new DateTime(ano, 2, 28);
        }

        return new DateTime(ano, nascimento.Month, nascimento.Day);
    }
}
