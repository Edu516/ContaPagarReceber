public class Parcela
{
    private int cod;
    private float valor;
    private StatusParcela status;
    public Parcela(int cod, float valor)
    {
        Cod = cod;
        Valor = valor;
        Status = status;
        status = StatusParcela.Pendente;
    }

    public int Cod 
    {
        get { return cod; }
        set { cod = value; }
    }

    public float Valor 
    {
        get { return valor; }
        set { valor = value; }
    }

    public StatusParcela Status 
    {
        get { return status; }
        set { status = value; }
    }
}
