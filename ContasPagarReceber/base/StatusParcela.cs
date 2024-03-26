using System.ComponentModel;
using System.Linq;
public enum StatusParcela
{
    [Description("Pendente")]
    Pendente = 1,

    [Description("Pago")]
    Pago = 2
}

public static class DescricaoStatusParcela
{
    public static string ObterDescricao(StatusParcela statusParcela)
    {
        var membro = typeof(StatusParcela).GetMember(statusParcela.ToString());
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
