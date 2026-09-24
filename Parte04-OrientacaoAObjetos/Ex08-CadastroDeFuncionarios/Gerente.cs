
namespace Ex08.CadastroDeFuncionarios;


public class Gerente : Funcionario
{
    public Gerente(string nome, string cargo, double salarioBase) : base(nome, cargo, salarioBase)
    {
    }



    public double SalarioComBonus()
    {
        double adicional = 0.20;
        double calculo = ExibirSalario() * adicional;
        return ExibirSalario() + calculo;
    }
}