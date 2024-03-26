using System;

class Program
{
    static void Main(string[] args)
    {
        PersisteJson json = new PersisteJson();
        ResumoFinanceiro resumoFinanceiro = json.Ler();
        while (true)
        {
            Console.WriteLine("----------------------Saldo-------------------");
            Console.WriteLine("Pagar   :R$ " + resumoFinanceiro.TotalPagar);
            Console.WriteLine("Receber :R$ " + resumoFinanceiro.TotalReceber);
            Console.WriteLine("Saldo   :R$ " + resumoFinanceiro.Saldo);
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Escolha uma operação:");
            Console.WriteLine("1 - Incluir conta");
            Console.WriteLine("2 - Listar contas");
            Console.WriteLine("3 - Excluir conta");
            Console.WriteLine("4 - Pagar parcela");
            Console.WriteLine("5 - Receber parcela");
            Console.WriteLine("6 - Sair");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    IncluirConta(resumoFinanceiro);
                    break;
                case "2":
                    ListarContas(resumoFinanceiro);
                    break;
                case "3":
                    ExcluirConta(resumoFinanceiro);
                    break;
                case "4":
                    PagarParcela(resumoFinanceiro);
                    break;
                case "5":
                    ReceberParcela(resumoFinanceiro);
                    break;
                case "6":
                    json.Gravar(resumoFinanceiro);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Escolha uma operação válida.");
                    break;
            }
        }
    }


    static void IncluirConta(ResumoFinanceiro resumoFinanceiro)
    {
        Console.WriteLine("Incluir nova conta:");

        Console.Write("Código da conta: ");
        int codigo = int.Parse(Console.ReadLine());

        Console.Write("Descrição da conta: ");
        string descricao = Console.ReadLine();

        Console.Write("Valor total da conta: ");
        float valorTotal = float.Parse(Console.ReadLine());

        Console.Write("Quantidade de parcelas: ");
        int quantParcelas = int.Parse(Console.ReadLine());

        Console.Write("Tipo da conta (1 - Conta a Receber, 2 - Conta a Pagar): ");
        int tipoContaInt = int.Parse(Console.ReadLine());
        TipoConta tipoConta = (TipoConta)tipoContaInt;

        Conta novaConta = new Conta
        {
            Cod = codigo,
            Descricao = descricao,
            ValorTotal = valorTotal,
            QuantParcelas = quantParcelas,
            Tipo = tipoConta
        };

        resumoFinanceiro.AdicionarConta(novaConta);

        Console.WriteLine("Conta adicionada com sucesso!");
    }


    static void ListarContas(ResumoFinanceiro resumoFinanceiro, int tipo = 0)
    {
        Console.WriteLine("Lista de contas:");

        foreach (var conta in resumoFinanceiro.ListaContas)
        {
            if (tipo == 0 || (int)conta.Tipo == tipo)
            {
                Console.WriteLine($"Código: {conta.Cod}");
                Console.WriteLine($"Descrição: {conta.Descricao}");
                Console.WriteLine($"Valor Total: {conta.ValorTotal}");
                Console.WriteLine($"Quantidade de Parcelas: {conta.QuantParcelas}");
                Console.WriteLine($"Tipo: {(conta.Tipo == TipoConta.ContaReceber ? "Conta a Receber" : "Conta a Pagar")}");
                Console.WriteLine($"Data de Início: {conta.DataInicio.ToShortDateString()}");
                Console.WriteLine($"Data de Fim: {conta.DataFim.ToShortDateString()}");
                Console.WriteLine("-------------------------------------");
            }
        }
    }


    static void ExcluirConta(ResumoFinanceiro resumoFinanceiro)
    {
        // Lista as contas antes de excluir
        ListarContas(resumoFinanceiro);
        int codConta = int.Parse(Console.ReadLine());

        if (resumoFinanceiro.RemoverConta(codConta))
        {
            Console.WriteLine("Conta removida com sucesso!");
        }
        else
        {
            Console.WriteLine("Conta não encontrada !");
        }
    }

    static void PagarParcela(ResumoFinanceiro resumoFinanceiro)
    {
        Console.WriteLine("Pagar parcela:");
        ListarContas(resumoFinanceiro, (int)TipoConta.ContaPagar);
        Console.Write("Digite o código da conta: ");
        int codConta = int.Parse(Console.ReadLine());

        Console.Write("Digite o número da parcela a ser paga: ");
        int numParcela = int.Parse(Console.ReadLine());

        if (resumoFinanceiro.PagarParcela(codConta, numParcela))
        {
            Console.WriteLine("Parcela paga com sucesso!");
        }
        else
        {
            Console.WriteLine("Não foi possível pagar a parcela. Verifique o código da conta e o número da parcela.");
        }
    }

    static void ReceberParcela(ResumoFinanceiro resumoFinanceiro)
    {
        Console.WriteLine("Receber parcela:");
        ListarContas(resumoFinanceiro, (int)TipoConta.ContaReceber);
        Console.Write("Digite o código da conta: ");
        int codConta = int.Parse(Console.ReadLine());

        Console.Write("Digite o número da parcela a ser recebida: ");
        int numParcela = int.Parse(Console.ReadLine());

        if (resumoFinanceiro.ReceberParcela(codConta, numParcela))
        {
            Console.WriteLine("Parcela recebida com sucesso!");
        }
        else
        {
            Console.WriteLine("Não foi possível receber a parcela. Verifique o código da conta e o número da parcela.");
        }
    }


}
