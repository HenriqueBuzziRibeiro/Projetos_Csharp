
using System.Security.Cryptography;

Console.WriteLine("Digite a quantidade de ruas a monitorar: ");
int N = Convert.ToInt32(Console.ReadLine());
int somaCarros = 0;

List<(string nome, int qntCarros)> ruas = new List<(string, int)>();

for (int i = 1; i <= N; i++)
{
    Console.WriteLine($"Digite o nome da {i}° rua: ");
    string nome = Console.ReadLine();

    Console.WriteLine($"Digite a quantidade de carros da {i}° rua: ");
    int qntCarros = Convert.ToInt32(Console.ReadLine());
    
    ruas.Add((nome, qntCarros));

    somaCarros = somaCarros + qntCarros;
}

int T = 300;
int tempoMinimo = 30; //assism´que aparece a mudança
int tempoMaximo = 120;

for (int i = 0; i < ruas.Count; i++)
{
    double tempo_abertura_rua = (T * ruas[i].qntCarros) / somaCarros;

    if (tempo_abertura_rua < tempoMinimo) Console.WriteLine($"A rua {ruas[i].nome} e possui 30 segundos de tempo de abertura");
    else if (tempo_abertura_rua > tempoMaximo) Console.WriteLine($"A rua {ruas[i].nome} e possui 120 segundos de tempo de abertura");
    else Console.WriteLine($"A rua {ruas[i].nome} e possui {(int)tempo_abertura_rua} segundos de tempo de abertura");
}




Oid arthur