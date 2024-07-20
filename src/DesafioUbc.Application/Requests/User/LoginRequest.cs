namespace DesafioUbc.Application.Requests.User;

public class LoginRequest : Request
{
    public string Username { get; set; }
    public string Password { get; set; }
}