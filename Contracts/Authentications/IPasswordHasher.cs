namespace Contracts.Authentications;

public interface IPasswordHasher
{
    public string HashPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
}