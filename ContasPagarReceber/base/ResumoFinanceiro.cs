using System;
using System.Collections.Generic;

public class ResumoFinanceiro
{
    private List<Conta> listaContas;
    private float totalReceber;
    private float totalPagar;
    private float saldo;

    public List<Conta> ListaContas
    {
        get { return listaContas; }
        set
        {
            listaContas = value;
            CalcularTotaisESaldo();
        }
    }

    public float TotalReceber => totalReceber;

    public float TotalPagar => totalPagar;

    public float Saldo => saldo;

    // Construtor padrão que inicializa com valores padrão
    public ResumoFinanceiro()
    {
        listaContas = new List<Conta>();
        totalReceber = 0;
        totalPagar = 0;
        saldo = 0;
    }

    // Sobrecarga do construtor que permite inicializar com valores específicos
    public ResumoFinanceiro(List<Conta> listaContas, float totalReceber, float totalPagar, float saldo)
    {
        this.listaContas = listaContas;
        this.totalReceber = totalReceber;
        this.totalPagar = totalPagar;
        this.saldo = saldo;
        CalcularTotaisESaldo();
    }

    public void CalcularTotaisESaldo()
    {
        totalReceber = 0;
        totalPagar = 0;

        foreach (var conta in listaContas)
        {
            if (conta.Tipo == TipoConta.ContaReceber)
            {
                foreach (var parcela in conta.Parcelas)
                {
                    if (parcela.Status == StatusParcela.Pendente)
                        totalReceber += parcela.Valor;
                }
            }
            else if (conta.Tipo == TipoConta.ContaPagar)
            {
                foreach (var parcela in conta.Parcelas)
                {
                    if (parcela.Status == StatusParcela.Pendente)
                        totalPagar += parcela.Valor;
                }
            }
        }

        saldo = totalReceber - totalPagar;
    }



    // Método para adicionar uma nova conta ao resumo financeiro
    public void AdicionarConta(Conta novaConta)
    {
        listaContas.Add(novaConta);
        // Recalcula os totais e o saldo após adicionar a conta
        CalcularTotaisESaldo();
    }

    // Método para remover uma conta do resumo financeiro com base no código
    public Boolean RemoverConta(int cod)
    {
        Conta contaParaRemover = listaContas.Find(c => c.Cod == cod);
        if (contaParaRemover != null)
        {
            listaContas.Remove(contaParaRemover);
            // Recalcula os totais e o saldo após remover a conta
            CalcularTotaisESaldo();
            return true;
        }
        return false;
    }

    public bool PagarParcela(int codConta, int numParcela)
    {
        Conta conta = ListaContas.Find(c => c.Cod == codConta);

        if (conta != null && numParcela >= 1 && numParcela <= conta.QuantParcelas)
        {
            Parcela parcela = conta.Parcelas[numParcela - 1];
            if (parcela.Status == StatusParcela.Pendente)
            {
                parcela.Status = StatusParcela.Pago;
                return true;
            }
        }

        return false;
    }

    public bool ReceberParcela(int codConta, int numParcela)
    {
        Conta conta = ListaContas.Find(c => c.Cod == codConta);

        if (conta != null && numParcela >= 1 && numParcela <= conta.QuantParcelas)
        {
            Parcela parcela = conta.Parcelas[numParcela - 1];
            if (parcela.Status == StatusParcela.Pendente)
            {
                parcela.Status = StatusParcela.Pago;
                return true;
            }
        }

        return false;
    }

     public override string ToString()
    {
        string resumo = "Resumo Financeiro:\n";
        resumo += $"Total a Receber: {totalReceber:C2}\n";
        resumo += $"Total a Pagar: {totalPagar:C2}\n";
        resumo += $"Saldo: {saldo:C2}\n";
        resumo += "Lista de Contas:\n";
        
        foreach (var conta in listaContas)
        {
            resumo += $"Código: {conta.Cod}, Descrição: {conta.Descricao}, Valor Total: {conta.ValorTotal:C2}\n";
        }

        return resumo;
    }

}
