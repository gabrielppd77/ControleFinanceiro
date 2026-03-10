using Application.Authentications.Common;
using Application.Base;
using Contracts.Authentications;
using Contracts.Repositories;
using Contracts.Repositories.Users;
using Domain.Exceptions;
using Domain.Users;

namespace Application.Authentications.CreateUser;

public class CreateUserService : IServiceHandler<CreateUserRequest, AuthenticationResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtTokenGenerator jwtTokenGenerator,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
        _unitOfWork = unitOfWork;
    }

    public async Task<AuthenticationResponse> Handle(CreateUserRequest request)
    {
        var userFounded = await _userRepository.GetByEmail(request.Email);

        if (userFounded is not null)
        {
            throw new BadRequestException("O Email informado já está cadastrado.");
        }

        var hashedPassword = _passwordHasher.HashPassword(request.Password);

        var user = new User(
            request.Name,
            request.Email,
            hashedPassword);

        await _userRepository.Add(user);

        await _unitOfWork.SaveChanges();

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResponse(token);
    }
}
