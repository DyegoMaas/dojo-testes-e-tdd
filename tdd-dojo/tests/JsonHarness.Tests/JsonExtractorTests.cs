using JsonHarness;
using Shouldly;
using Xunit;

namespace JsonHarness.Tests;

public class JsonExtractorTests
{
    // ===========================================================
    //  PRIMEIRO TESTE VERMELHO — função pura, ZERO mock.
    //  Mesmo ritmo do String Calculator, mas em cima de algo "real":
    //  limpar a saída bagunçada de um LLM. Rode `dotnet test`,
    //  veja vermelho, faça passar com o mínimo, e siga o KATAS.md.
    // ===========================================================

    [Fact]
    public void Json_limpo_retorna_sucesso_com_o_mesmo_conteudo()
    {
        var raw = """{"nome":"Ada"}""";

        var resultado = JsonExtractor.Extract(raw);

        resultado.IsSuccess.ShouldBeTrue();
        resultado.Value.ShouldBe("""{"nome":"Ada"}""");
    }

    // Próximos testes entram aqui, UM DE CADA VEZ, seguindo o KATAS.md.
}
