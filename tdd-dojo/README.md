# TDD Dojo — MHTEC

Repositório inicial para um dojo de TDD com dois katas, em **C# / .NET 8**,
com **Shouldly** (asserções) e **NSubstitute** (mocks, para a 2ª sessão).

- **Kata 1 — String Calculator:** instala o *ritmo* red-green-refactor com
  domínio trivial. Ideal para quem nunca testou.
- **Kata 2 — Extrator de JSON:** mesma cadência, mas em cima de algo real
  (limpar a saída bagunçada de um LLM). Função pura, **zero mock**.

O guia completo, com os requisitos revelados um a um, está em **[KATAS.md](./KATAS.md)**.

## Começando

Pré-requisito: SDK do .NET 8.

```bash
dotnet restore
dotnet test
```

O primeiro teste de cada kata já vem **vermelho** de propósito — é o ponto de
partida do ciclo. Faça-o passar com o mínimo de código e siga o `KATAS.md`.

## Estrutura

```
TddDojo.sln
├── Directory.Build.props            # net8.0, nullable, implicit usings
├── KATAS.md                         # 👈 guia do dojo (comece por aqui)
├── src/
│   ├── StringCalculator/            # Calculator.cs (stub)
│   └── JsonHarness/                 # JsonExtractor.cs (stub) + Result.cs (pronto)
└── tests/
    ├── StringCalculator.Tests/      # 1º teste vermelho
    └── JsonHarness.Tests/           # 1º teste vermelho
```

> Observação: as versões dos pacotes nos `.csproj` são as estáveis mais comuns;
> se o `dotnet restore` reclamar de alguma, basta ajustar para a disponível no
> seu feed do NuGet.
