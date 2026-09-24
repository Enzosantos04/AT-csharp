namespace Ex08.CadastroDeFuncionarios;

internal class Program
{
    private static void Main()
    {
        Gerente gerente = new Gerente("Enzo", "Engenheiro de software", 2000);
        Funcionario funcionario = new Funcionario("Caio", "Estagiario", 2000);

        Console.WriteLine("=== Salários dos funcionários ===");
        Console.WriteLine($"Gerente (com bônus de 20%): R$ {gerente.SalarioComBonus()}");
        Console.WriteLine($"Funcionário: R$ {funcionario.ExibirSalario()}");
    }
}
