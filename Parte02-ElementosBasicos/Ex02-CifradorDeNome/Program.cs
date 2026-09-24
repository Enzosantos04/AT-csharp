namespace Ex02.CifradorDeNome;

internal class Program
{
    private static void Main()
    {
        Console.Write("Digite seu nome completo: ");
        string nome = Console.ReadLine() ?? "";
        


        // O array permite alterar as letras sem remover espaços ou acentos.
        char[] caracteres = nome.ToCharArray();

        for (int i = 0; i < caracteres.Length; i++)
        {
            char letra = caracteres[i];

            
            // O módulo faz a contagem voltar ao início após a letra Z.
            if (letra >= 'a' && letra <= 'z')
            {
                caracteres[i] = (char)('a' + (letra - 'a' + 2) % 26); 
            }else if (letra >= 'A' && letra <= 'Z')
            {
                caracteres[i] = (char)('A' + (letra - 'A' + 2) % 26); 
            }
            
        }

        string nomeCifrado = new string(caracteres);
        
        Console.WriteLine($"Nome cifrado: {nomeCifrado}");



    }
}
