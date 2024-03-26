using System;
using System.IO;
using Newtonsoft.Json;

public class PersisteJson
{
    private readonly string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dados.json");

    public void Gravar(ResumoFinanceiro resumo)
    {
        string json = JsonConvert.SerializeObject(resumo);
        File.WriteAllText(basePath, json);
    }

    public ResumoFinanceiro Ler()
    {
        // Retorna uma nova instância de ResumoFinanceiro se o arquivo não existir
        if (!File.Exists(basePath))
            return new ResumoFinanceiro();

        try
        {
            string json = File.ReadAllText(basePath);
            ResumoFinanceiro resumo = JsonConvert.DeserializeObject<ResumoFinanceiro>(json);
            return resumo;
        }
        catch (Exception ex)
        {
            // Retorna uma nova instância de ResumoFinanceiro em caso de erro de leitura
            Console.WriteLine($"Erro ao ler o arquivo {basePath}: {ex.Message}");
            return new ResumoFinanceiro();
        }
    }
}
