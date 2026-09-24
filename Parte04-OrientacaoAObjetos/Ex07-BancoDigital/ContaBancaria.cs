namespace Ex07.BancoDigital;

public class ContaBancaria
{
    public string Titular;
    // O saldo é privado e só pode ser alterado por depósito ou saque.
    private decimal saldo;

    public ContaBancaria(string titular)
    {
        Titular = titular;
    }


    public void Depositar(decimal valor)
    {
        // Valores nulos ou negativos não podem entrar na conta.
        if (valor <= 0)
        {
            Console.WriteLine("O valor do depósito deve ser positivo!");
            return;
        }

        saldo += valor;
        Console.WriteLine($"Depósito de {FormatarReais(valor)} realizado com sucesso!");
    }


    public void Sacar(decimal valor)
    {
        // O saldo só é reduzido depois de validar o valor e a disponibilidade.
        if (valor <= 0)
        {
            Console.WriteLine("O valor do saque deve ser positivo!");
            return;
        }

        if (valor > saldo)
        {
            Console.WriteLine("Saldo insuficiente para realizar o saque!");
            return;
        }

        saldo -= valor;
        Console.WriteLine($"Saque de {FormatarReais(valor)} realizado com sucesso!");
    }

    public void ExibirSaldo()
    {
        Console.WriteLine($"Titular: {Titular}");
        Console.WriteLine($"Saldo atual: {FormatarReais(saldo)}");
    }

    // Mantém o símbolo R$ literal e usa vírgula para os centavos.
    private static string FormatarReais(decimal valor)
    {
        return $"R$ {valor:0.00}".Replace('.', ',');
    }
}
