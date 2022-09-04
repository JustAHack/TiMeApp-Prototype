namespace TiMePrototype.Application.Responses;

public class BaseCommandResponse
{
    public int Id { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public List<string> ValidationErrors { get; set; }
}
