namespace CrudApi.Utils;

public class Result
{
    public readonly bool IsSuccess;
    public readonly string Error;

    public Result(bool isSuccess, string error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Failure(string error)
    {
        return new Result(false, error);
    }

    public static Result Success()
    {
        return new Result(true, string.Empty);
    }

    public static Result<T> Failure<T>(string error)
    {
        return new Result<T>(false, error, default);
    }

    public static Result<T> Success<T>(T value)
    {
        return new Result<T>(true, string.Empty, value);
    }
}

public class Result<T> : Result
{
    public T Value { get; set; }

    public Result(bool isSuccess, string error, T value) : base(isSuccess, error)
    {
        Value = value;
    }
}
