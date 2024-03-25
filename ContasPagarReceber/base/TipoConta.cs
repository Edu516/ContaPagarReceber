public enum TipoConta
{
    [Description("Conta a Receber")]
    ContaReceber = 1,

    [Description("Conta a Pagar")]
    ContaPagar = 2
}

public static class DescricaoConta
{
    public static string ObterDescricao(TipoConta tipoConta)
    {
        var membro = typeof(TipoConta).GetMember(tipoConta.ToString());
        if (membro.Length > 0)
        {
            var descricaoAttribute = membro[0].GetCustomAttributes(typeof(DescriptionAttribute), false)
                                             .FirstOrDefault() as DescriptionAttribute;
            if (descricaoAttribute != null)
                return descricaoAttribute.Description;
        }
        return "Descrição não encontrada";
    }
}