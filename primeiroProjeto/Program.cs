//Screen Sound
string mensagemDeBoasVindas = "\nBoas vindas ao Screen Sound";
//List<string> bandas = new List<string> {"Fleetwood Mac", "Cage The Elephant", "Artic Monkeys"};

Dictionary<string, List<int>> bandas = new Dictionary<string, List<int>>();
bandas.Add("Fleetwood Mac", new List<int> { 10, 8 });
bandas.Add("Cage The Elephant", new List<int> { 7, 8 });
bandas.Add("Artic Monkeys", new List<int>());
void MostrarLogo() {
    Console.WriteLine(@"
█▀ █▀▀ █▀█ █▀▀ █▀▀ █▄░█   █▀ █▀█ █░█ █▄░█ █▀▄
▄█ █▄▄ █▀▄ ██▄ ██▄ █░▀█   ▄█ █▄█ █▄█ █░▀█ █▄▀");
    Console.WriteLine(mensagemDeBoasVindas);
}

void OpcoesMenu()
{
    Console.Clear();
    MostrarLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digire 5 para sair");

    Console.Write("\nDigite uma opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaInt = int.Parse(opcaoEscolhida);
    switch (opcaoEscolhidaInt)
    {
        case 1: RegistrarBandas();
            break;
        case 2: MostrarBandas();
            break;
        case 3:
            AvaliarBanda();
            break;
        case 4: mediaBanda();
            break;
        case 5: Console.WriteLine("\nVocê saiu :(");
            break;
        default: Console.WriteLine("Opção inválida");
            break;

    } 
}

void RegistrarBandas()
{
    tituloOpcoes("Registro de bandas");
    Console.Write("\nDigite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"\nA banda {nomeDaBanda} foi registrada com sucesso");
    Thread.Sleep(2000);
    OpcoesMenu();
}

void MostrarBandas()
{
    
    tituloOpcoes("Bandas registradas: ");
    foreach (string banda in bandas.Keys)
    {
        Console.WriteLine($"- {banda}");
    }
    Console.WriteLine("\nDigite qualquer tecla para voltar ao menu");
    Console.ReadKey();
    OpcoesMenu();
}

void tituloOpcoes(string titulo)
{
    Console.Clear();
    int qntLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(qntLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarBanda()
{
    tituloOpcoes("Avaliar banda");
    Console.Write("Digir o nome da banda que dejesa avaliar: ");
    string nomeBanda = Console.ReadLine()!;
    if (bandas.ContainsKey(nomeBanda))
    {
        Console.Write($"\nQual a nota você quer dar para a banda {nomeBanda}: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandas[nomeBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeBanda}");
        Thread.Sleep(2000);
        OpcoesMenu();

    } else
    {
        Console.WriteLine($"\nA banda {nomeBanda} não foi encontrada");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        OpcoesMenu();
    }
}

void mediaBanda()
{
    tituloOpcoes("Média de notas da banda");
    Console.Write("\nDigir o nome da banda que dejesa saber a média: ");
    string nomeBanda = Console.ReadLine()!;
    if (bandas.ContainsKey(nomeBanda))
    {
        List<int> notas = bandas[nomeBanda];
        if (notas.Count > 0)
        {
            double media = notas.Average();
            Console.WriteLine($"\nA média das notas da banda {nomeBanda} é {media}.");
        } else
        {
            Console.WriteLine($"\nA banda {nomeBanda} não possui notas registradas.");
        }
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        OpcoesMenu();

    }
    else
    {
        Console.WriteLine($"\nA banda {nomeBanda} não foi encontrada");
        Thread.Sleep(2000);
        OpcoesMenu();
    }
}

OpcoesMenu();

