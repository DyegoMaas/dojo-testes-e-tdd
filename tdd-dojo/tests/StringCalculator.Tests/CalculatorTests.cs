using Shouldly;
using StringCalculator;
using Xunit;

namespace StringCalculator.Tests;

public class CalculatorTests
{
    // ===========================================================
    //  PRIMEIRO TESTE VERMELHO — já escrito para destravar.
    //  Rode `dotnet test`: ele falha porque Add lança NotImplemented.
    //  Faça-o passar com o MÍNIMO de código possível. Depois,
    //  abra o KATAS.md e revele o próximo requisito.
    // ===========================================================

    [Fact]
    public void String_vazia_retorna_zero()
    {
        var calculator = new Calculator();

        var resultado = calculator.Add("");

        resultado.ShouldBe(0);
    }

    // Próximos testes entram aqui, UM DE CADA VEZ, seguindo o KATAS.md.
    // Não escreva vários de uma vez. Não leia os requisitos à frente.
}
