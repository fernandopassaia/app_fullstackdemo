namespace AppFullStackDemo.Domain.Results
{
    public interface IBaseCommandResult
    {
        object ResponseDataObj { get; set; }

        string Message { get; set; }

        bool Success { get; set; }
    }
}