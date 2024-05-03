
class Hotel
{
    public List<Quarto> Quartos { get; set; }

    public Hotel()
    {
        Quartos = new List<Quarto>();
    }
}

class Quarto
{
    public int Numero { get; set; }
    public string Tipo { get; set; }
    public bool Ocupado { get; set; }
    public double Preco { get; set; }

    public int DiasOcupado { get; set; }

    public int NumeroPessoas { get; set; }  
    public Quarto(int numero, string tipo, double preco)
    {
        Numero = numero;
        Tipo = tipo;
        Ocupado = false;
        Preco = preco;
        DiasOcupado = 0;    
    }
}

class Program
{
    static void Main(string[] args)
    {
        Hotel hotel = new Hotel();
        hotel.Quartos.Add(new Quarto(1, "comum", 100.00));
        hotel.Quartos.Add(new Quarto(2, "comum", 100.00));
        hotel.Quartos.Add(new Quarto(3, "comum", 100.00)); 
        hotel.Quartos.Add(new Quarto(4, "comum", 100.00));


        hotel.Quartos.Add(new Quarto(5, "Luxo", 150.00));
        hotel.Quartos.Add(new Quarto(6, "Luxo", 150.00));
        hotel.Quartos.Add(new Quarto(7, "Luxo", 150.00));




        hotel.Quartos.Add(new Quarto(8, "Suite", 200.00));
        hotel.Quartos.Add(new Quarto(9, "Suite", 200.00));
        hotel.Quartos.Add(new Quarto(10, "Suite", 200.00));

        while (true)
        {
            Console.WriteLine("Bem vindo ao Hotel Express!");
            Console.WriteLine("------------------------");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Quartos Disponíveis");
            Console.WriteLine("2. Reserve seu Quarto");
            Console.WriteLine("3. Sair");

            int opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                Console.WriteLine("Quartos Disponíveis:");
                foreach (var quarto in hotel.Quartos)
                {
                    if (!quarto.Ocupado)
                    {
                        Console.WriteLine($"Quarto {quarto.Numero} ({quarto.Tipo}): R${quarto.Preco} por noite");
                    }
                }
            }
            else if (opcao == 2)
            {
                Console.WriteLine("Digite o número do quarto que deseja reservar:");
                int numeroQuarto = int.Parse(Console.ReadLine());
                Quarto quartoSelecionado = hotel.Quartos.Find(q => q.Numero == numeroQuarto);

                if (quartoSelecionado != null && !quartoSelecionado.Ocupado)
                {
                    Console.WriteLine("Digite o número de dias de hospedagem:");
                    int diasHospedagem = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite o número de pessoas no quarto:");
                    int numeroPessoas = int.Parse(Console.ReadLine());

                    quartoSelecionado.Ocupado = true;
                    quartoSelecionado.DiasOcupado = diasHospedagem;
                    quartoSelecionado.NumeroPessoas = numeroPessoas;

                    double precoTotal = quartoSelecionado.Preco * diasHospedagem;
                    if (numeroPessoas > 4)
                    {
                        Console.WriteLine("Erro: Não é permitido mais de 4 pessoas em um quarto.");
                    }
                    else if (numeroPessoas > 3)
                    {
                        precoTotal += 50.00;
                        Console.WriteLine($"Quarto {quartoSelecionado.Numero} ({quartoSelecionado.Tipo}) reservado com sucesso por R${quartoSelecionado.Preco} por noite + R$50.00 de acréscimo.");

                    }


                    else
                    {
                        Console.WriteLine($"Quarto {quartoSelecionado.Numero} ({quartoSelecionado.Tipo}) reservado com sucesso por R${quartoSelecionado.Preco} por noite.");
                    }

                    Console.WriteLine($"Preço total da hospedagem: R${precoTotal}");
                }
                else
                {
                    Console.WriteLine("Quarto indisponível ou número de quarto inválido.");
                }
            }
            else if (opcao == 3)
            {
                Console.WriteLine("Obrigado por usar o sistema de hospedagem. Adeus!");
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }
    }
}