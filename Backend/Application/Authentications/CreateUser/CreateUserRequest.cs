namespace Application.Authentications.CreateUser;

public record CreateUserRequest(
    string Name,
    string Email,
    string Password);
