namespace DesafioUbc.Application.Responses.User;

public class TokenResponse
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}