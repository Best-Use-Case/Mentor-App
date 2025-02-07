namespace API.Utils;

public class ResponseManager
{
    public int UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public List<string> Role { get; set; } = [];
    public string Message { get; set; } = string.Empty;
    public bool IsSuccess { get; set; }
    public IEnumerable<string> Errors { get; set; } = [];
}
