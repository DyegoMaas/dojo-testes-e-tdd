namespace JsonHarness;

/// <summary>
/// Extrai um payload JSON válido do texto "sujo" que um LLM costuma devolver
/// (cercas markdown, prosa antes/depois, etc.).
///
/// É uma FUNÇÃO PURA: string entra, Result&lt;string&gt; sai. Sem rede, sem
/// LLM, sem mock. Por isso é o kata perfeito para quem está começando em
/// testes — toda a complexidade vira lógica determinística e testável.
///
/// Não implemente nada aqui ainda. Deixe cada teste vermelho do KATAS.md
/// pedir a próxima linha.
/// </summary>
public static class JsonExtractor
{
    public static Result<string> Extract(string raw)
    {
        throw new NotImplementedException();
    }
}
