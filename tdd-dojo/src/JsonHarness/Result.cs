namespace JsonHarness;

/// <summary>
/// Resultado de uma operação que pode falhar sem lançar exceção.
/// Já vem pronto: não é o foco do kata. O foco é deixar os testes
/// guiarem o JsonExtractor. Use Result&lt;T&gt;.Success(valor) ou
/// Result&lt;T&gt;.Failure("motivo").
/// </summary>
public sealed class Result<T>
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public T? Value { get; }
    public string? Error { get; }

    private Result(bool isSuccess, T? value, string? error)
    {
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }

    public static Result<T> Success(T value) => new(true, value, null);

    public static Result<T> Failure(string error) => new(false, default, error);
}
