namespace Ex07.BancoDigital;

internal class Program
{
    private static void Main()
    {
        ContaBancaria contaBancaria = new ContaBancaria("Enzo");
        contaBancaria.Depositar(200);
        contaBancaria.ExibirSaldo();
        contaBancaria.Sacar(300);
        contaBancaria.Sacar(50);
        contaBancaria.Depositar(-10);
        contaBancaria.ExibirSaldo();
    }
}
