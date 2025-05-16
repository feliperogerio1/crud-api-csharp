namespace crud_api.Utils
{
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
            => new(false, error);

        public static Result Success()
            => new(true, string.Empty);

        public static Result<T> Failure<T>(string error)
            => new(false, default, error);

        public static Result<T> Success<T>(T value)
            => new(true, value, string.Empty);
    }

    public class Result<T> : Result
    {
        public readonly T Value;

        public Result(bool isSuccess, T value, string error) : base(isSuccess, error)
        {
            Value = value;
        }
    }
}
