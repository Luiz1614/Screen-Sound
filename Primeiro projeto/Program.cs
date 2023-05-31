// Screen Sound
using System.ComponentModel.Design;

string boasVindas = "Boas vindas ao Screen Sound";

//List <string> listaBandas = new List<string> { "The Beatles", "Foo figthers", "Charle Brown" };

Dictionary<string, List<int>>  bandasRegistradas = new Dictionary<string, List<int>>();


void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine(boasVindas);
}

void ExibirOpcoesMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar uma banda");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");

    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBanda();
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: AvaliaUmaBanda();
            break;
        case 4: ExibeMedia();
            break;
        case -1: Console.WriteLine("Tchau Tchau :)");
            break;
        default: Console.WriteLine("Opçao inválida");
            break;

    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro das Bandas");

    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomebanda = Console.ReadLine();
    bandasRegistradas.Add(nomebanda, new List<int>()); 
    Console.WriteLine($"A banda foi {nomebanda} registrada com sucesso!"); //interpolaçao de string
    Thread.Sleep(1000); //Dá um tempo de espera até executar o proximo comando
    Console.Clear();
    ExibirOpcoesMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas na nossa aplicação!");

    //for (int i = 0; i < listaBandas.Count; i++) //somente mostra a lista das bandas que foram adicionadas
    //{
    //    Console.WriteLine($"Banda: {listaBandas[i]}");
    //}

    foreach (string banda in bandasRegistradas.Keys) // Para cada banda na lista de Bandas
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nPressine qualquer tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliaUmaBanda()
{
    //Digite qual banda quer avaliar
    //se a banda exite no dicionario >> atribuir uma nota
    //se não volta ao menu principal

    Console.Clear();
    ExibirTituloDaOpcao("Avaliar Banda");

    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual nota a banda {nomeDaBanda} merece?");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada para a banda {nomeDaBanda}");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encotrada!\n");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Thread.Sleep(1000);
        Console.Clear();
        ExibirOpcoesMenu();
    }


}

void ExibeMedia()
{
    Console.Clear();
    ExibirTituloDaOpcao("Médias das bandas");
    Console.Write("Qual banda voce gostaria de ver a média?");
    string nomeDaBanda = Console.ReadLine()!;
    
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notasBanda = bandasRegistradas[nomeDaBanda]; 
        Console.WriteLine($"\nA média da banda {nomeDaBanda} é: {notasBanda.Average()}."); //.Average faz a média das notas 
        Console.WriteLine("Precione qualquer tecla para voltal ao menu principal");
        Console.ReadKey();
        Thread.Sleep(1000);
        Console.Clear();
        ExibirOpcoesMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encotrada!\n");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Thread.Sleep(1000);
        Console.Clear();
        ExibirOpcoesMenu();
    }

}

ExibirOpcoesMenu();

