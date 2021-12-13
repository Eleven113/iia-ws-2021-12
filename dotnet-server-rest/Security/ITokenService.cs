namespace Security;

public interface ITokenService
{
    public string BuildToken(UserModel user);
}