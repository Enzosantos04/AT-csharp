using System.Globalization;

namespace Ex05.TempoAteFormatura;

internal class Program
{
    private static void Main()
    {
        Console.Write("Digite a data atual (dd/MM/yyyy): ");
        string? input = Console.ReadLine();

        DateTime dataFormatura = new DateTime(2026, 12, 15);

        if (!DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime dataAtual))
        {
            Console.WriteLine("Data inválida. Use o formato dd/MM/yyyy.");
            return;
        }

        if (dataAtual > DateTime.Today)
        {
            Console.WriteLine("Erro: A data informada não pode ser no futuro!");
            return;
        }

        if (dataFormatura < dataAtual)
        {
            Console.WriteLine("Parabéns! Você já deveria estar formado!");
            return;
        }

        int anos = dataFormatura.Year - dataAtual.Year;
        if (dataAtual.AddYears(anos) > dataFormatura)
        {
            anos--;
        }

        DateTime referencia = dataAtual.AddYears(anos);
        
        int meses = dataFormatura.Month - referencia.Month;
        if (referencia.Year < dataFormatura.Year)
        {
            meses += 12;
        }
        if (referencia.AddMonths(meses) > dataFormatura)
        {
            meses--;
        }

        int dias = (dataFormatura - referencia.AddMonths(meses)).Days;

        Console.WriteLine($"Faltam {anos} anos, {meses} meses e {dias} dias para sua formatura!");

        if (anos == 0 && meses < 6)
            Console.WriteLine("A reta final chegou! Prepare-se para a formatura!");
    }
}
