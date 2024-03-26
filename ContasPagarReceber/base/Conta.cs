using System;
using System.Collections.Generic;

public class Conta
{
    private int cod;
    private string descricao;
    private float valorTotal;
    private int quantParcelas;
    private List<Parcela> parcelas;
    private TipoConta tipo;
    private DateTime dataInicio;
    private DateTime dataFim;

    public Conta()
    {   
         // Define a data de início como a data atual ao criar uma nova Conta
        dataInicio = DateTime.Today;
        descricao = "";
    }

    public int Cod 
    {
        get { return cod; }
        set { cod = value; }
    }

    public string Descricao 
    {
        get { return descricao; }
        set { descricao = value; }
    }

    public float ValorTotal 
    {
        get { return valorTotal; }
        set { valorTotal = value; }
    }

    public int QuantParcelas 
    {
        get { return quantParcelas; }
        set 
        { 
            quantParcelas = value; 
            GerarParcelas();    
        }
    }

    public List<Parcela> Parcelas 
    {
        get { return parcelas; }
        set { parcelas = value; }
    }

    public TipoConta Tipo 
    {
        get { return tipo; }
        set { tipo = value; }
    }

    public DateTime DataInicio 
    {
        get { return dataInicio; }
        set { dataInicio = value; }
    }

    public DateTime DataFim 
    {
        get { return dataFim; }
        set { dataFim = value; }
    }

    private void GerarParcelas()
    {
        parcelas = new List<Parcela>();
        float valorParcela = valorTotal / quantParcelas;
        for (int i = 1; i <= quantParcelas; i++)
        {
            parcelas.Add(new Parcela(i, valorParcela));
        }
    }

    private void CalcularDataFim()
    {
        if (quantParcelas > 0)
        {
            dataFim = dataInicio.AddMonths(quantParcelas);
        }
    }
}
