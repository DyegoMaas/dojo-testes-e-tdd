# 🥋 Dojo de TDD — MHTEC

Guia do facilitador e dos participantes. **Leia os requisitos UM DE CADA VEZ.**
Não role a página para frente: a graça do dojo é o requisito te surpreender.

---

## O ciclo (cole isto na parede)

```
🔴 RED    → escreva UM teste que falha. Só um.
🟢 GREEN  → faça passar com o MÍNIMO de código. Pode ser "feio" / hardcoded.
♻️  REFACTOR → limpe o código com os testes verdes te protegendo.
```

**Três regras de ouro para iniciantes:**

1. **Nenhuma linha de produção sem um teste vermelho pedindo por ela.** Se você se pegou escrevendo código "que vai precisar", apague.
2. **Passos de bebê.** Hardcode é permitido — e até incentivado — no GREEN. A generalização vem do *próximo* teste, não da sua imaginação.
3. **Um teste por vez.** Nada de escrever cinco testes e sair implementando.

---

## Formato sugerido (≈ 3h)

| Bloco | Tempo | Formato |
|---|---|---|
| Abertura: o ciclo + as 3 regras | 15 min | Você explica e faz 1 demo ao vivo |
| **Kata 1 — String Calculator** | 60 min | Randori (1 teclado, troca a cada 🟢) |
| Pausa | 10 min | ☕ |
| **Kata 2 — Extrator de JSON** | 60 min | Pares ping-pong (A escreve 🔴, B faz 🟢 e escreve o próximo 🔴) |
| Retrospectiva | 20 min | "O que foi estranho? Onde o teste te ajudou?" |

> Dica de facilitação: rode você mesmo, em silêncio, o passo que está pedindo.
> Quando alguém pular o teste e ir direto pro código, não corrija com discurso —
> pergunte: *"qual teste vermelho pediu essa linha?"*. O grupo se autorregula.

---

## 🥋 Kata 1 — String Calculator

`int Add(string numbers)`. Comece pelos arquivos já prontos:
- Produção: `src/StringCalculator/Calculator.cs`
- Testes: `tests/StringCalculator.Tests/CalculatorTests.cs` (o 1º teste já está lá, vermelho)

**Revele um requisito por vez. Não leia o próximo antes de fechar o atual.**

<details>
<summary>Requisito 1 — (já implementado como exemplo no repo)</summary>

String vazia retorna `0`. → `Add("")` ➜ `0`
</details>

<details>
<summary>Requisito 2</summary>

Um único número retorna ele mesmo. → `Add("1")` ➜ `1`, `Add("42")` ➜ `42`
</details>

<details>
<summary>Requisito 3</summary>

Dois números separados por vírgula são somados. → `Add("1,2")` ➜ `3`
</details>

<details>
<summary>Requisito 4</summary>

Uma quantidade **qualquer** de números. → `Add("1,2,3,4,5")` ➜ `15`
</details>

<details>
<summary>Requisito 5</summary>

Quebra de linha também separa números (junto da vírgula).
→ `Add("1\n2,3")` ➜ `6`
</details>

<details>
<summary>Requisito 6</summary>

Delimitador customizado no início, no formato `//[delim]\n[números]`.
→ `Add("//;\n1;2")` ➜ `3`
</details>

<details>
<summary>Requisito 7</summary>

Números negativos são proibidos: lance uma exceção cuja mensagem **liste os
negativos** encontrados. → `Add("1,-2,-5")` ➜ lança, mensagem contém `-2` e `-5`.

Em Shouldly:
```csharp
var ex = Should.Throw<ArgumentException>(() => calculator.Add("1,-2,-5"));
ex.Message.ShouldContain("-2");
ex.Message.ShouldContain("-5");
```
</details>

<details>
<summary>Requisito 8 (extra, se sobrar tempo)</summary>

Números maiores que 1000 são ignorados. → `Add("2,1001")` ➜ `2`
</details>

> Para um time muito novato, **parar no Requisito 5 ou 6 já é um dojo completo
> e vitorioso.** Melhor sair com o ciclo dominado do que correr até o 8.

---

## 🥋 Kata 2 — Extrator de JSON (temática IA, sem mock)

`Result<string> Extract(string raw)`. A entrada é o texto cru que um LLM
devolve; a saída é o JSON válido isolado, ou uma falha graciosa.
- Produção: `src/JsonHarness/JsonExtractor.cs`
- Testes: `tests/JsonHarness.Tests/JsonExtractorTests.cs` (1º teste já vermelho)
- Apoio pronto: `src/JsonHarness/Result.cs` (não precisa mexer)

**É função pura.** Sem rede, sem LLM, sem NSubstitute. Cada teste é um jeito
diferente de um modelo baratinho se comportar mal — exatamente a dor real de
quem coloca LLM em produção.

<details>
<summary>Requisito 1 — (já implementado como exemplo no repo)</summary>

JSON limpo entra → sucesso com o mesmo conteúdo.
→ `Extract("""{"nome":"Ada"}""")` ➜ `Success("""{"nome":"Ada"}""")`
</details>

<details>
<summary>Requisito 2</summary>

O modelo embrulhou em cerca de markdown. Extraia só o JSON de dentro.
→ entrada:
````
```json
{"nome":"Ada"}
```
````
➜ `Success("""{"nome":"Ada"}""")`
</details>

<details>
<summary>Requisito 3</summary>

O modelo tagarelou antes e depois. Isole o objeto.
→ `Extract("Claro! Aqui está: {\"nome\":\"Ada\"} 😊")` ➜ `Success("""{"nome":"Ada"}""")`

(Dica de implementação que o teste vai *forçar*: localizar o primeiro `{` e o
último `}` e validar o miolo. Mas só implemente quando o teste pedir.)
</details>

<details>
<summary>Requisito 4</summary>

Lixo ou string vazia → falha graciosa, **sem lançar exceção**.
→ `Extract("")`, `Extract("desculpe, não consegui")` ➜ `IsFailure == true`
</details>

<details>
<summary>Requisito 5</summary>

JSON truncado/inválido (o modelo cortou no meio) → falha graciosa.
→ `Extract("""{"nome":"Ada""")` ➜ `IsFailure == true`

(Aqui entra a validação de verdade: tentar `JsonDocument.Parse` e tratar o
`JsonException`. Isso separa "achei chaves" de "é JSON válido".)
</details>

<details>
<summary>Requisito 6 (extra)</summary>

O payload é um array no topo, não um objeto.
→ `Extract("[1,2,3]")` ➜ `Success("[1,2,3]")`.
Force a generalização de "procurar `{...}`" para "procurar o primeiro valor
JSON válido".
</details>

> **Ponte para a Sessão 2:** quando o grupo perceber que `Extract` é fácil de
> testar *porque não fala com o LLM*, você tem o gancho perfeito. Na próxima
> sessão, o passo que chama o modelo (lento, caro, não-determinístico) é escondido
> atrás de uma interface e **mockado com NSubstitute** (já instalado no repo).
> Aí DI e mock deixam de ser cerimônia e viram alívio.

---

## Comandos

```bash
dotnet restore        # baixa Shouldly, xUnit, NSubstitute
dotnet test           # roda tudo — começa VERMELHO, como esperado
dotnet test --filter "FullyQualifiedName~StringCalculator"   # só o kata 1
dotnet test --filter "FullyQualifiedName~JsonHarness"        # só o kata 2
```

Bom dojo. 🚀
