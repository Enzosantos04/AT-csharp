namespace Ex08.CadastroDeFuncionarios;

public class Funcionario
{
    private string nome;
    private string cargo;
    private double salarioBase;
    
  
    public Funcionario(string nome, string cargo, double salarioBase)
    {
        this.nome = nome;
        this.cargo = cargo;
        this.salarioBase = salarioBase;
    }
    
    
    public double ExibirSalario()
    {
        return salarioBase;
    }
}