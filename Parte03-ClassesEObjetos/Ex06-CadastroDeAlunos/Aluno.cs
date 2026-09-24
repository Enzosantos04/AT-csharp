namespace Ex06.CadastroDeAlunos;

public class Aluno
{
    private readonly string nome;
    private readonly string matricula;
    private readonly string curso;
    private readonly double media;

    public Aluno(string nome, string matricula, string curso, double media)
    {
        this.nome = nome;
        this.matricula = matricula;
        this.curso = curso;
        this.media = media;
    }

    // Mostra as informações cadastradas do aluno.
    public void ExibirDados()
    {
        Console.WriteLine($"Nome: {nome}");
        Console.WriteLine($"Matrícula: {matricula}");
        Console.WriteLine($"Curso: {curso}");
        Console.WriteLine($"Média das notas: {media:F1}");
    }

    public string VerificarAprovacao()
    {
        // A média mínima para aprovação é 7.
        if (media >= 7)
        {
            return "Aprovado";
        }

        return "Reprovado";
    }
}
