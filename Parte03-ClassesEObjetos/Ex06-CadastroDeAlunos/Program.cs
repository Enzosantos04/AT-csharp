namespace Ex06.CadastroDeAlunos;

internal class Program
{
    private static void Main()
    {
        // Instancia a classe aluno passando os dados para os atributos
        Aluno aluno = new Aluno("Enzo", "2026001", "Engenharia de Software", 8.5);

        aluno.ExibirDados();
        Console.WriteLine($"Situação: {aluno.VerificarAprovacao()}");
    }
}
