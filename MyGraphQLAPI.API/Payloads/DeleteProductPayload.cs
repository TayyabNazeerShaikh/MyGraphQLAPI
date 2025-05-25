namespace MyGraphQLAPI.API.Payloads;

public class DeleteProductPayload
{
    public DeleteProductPayload(bool success /*, IReadOnlyList<string>? errors = null*/)
    {
        Success = success;
        // Errors = errors;
    }

    public bool Success { get; }
    // public IReadOnlyList<string>? Errors { get; }
}