using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Users.Common;
using Cinemax.Domain.User.Entities;
using Cinemax.Domain.ProjectionAggregate.Entities;
using MediatR;
using Cinemax.Domain.Card.Entities;
using Cinemax.Domain.Role.Entities;
using Cinemax.Application.Common.Interfaces.Authentication;

namespace Cinemax.Application.Users.Commands.Create;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _UserRepository; 
    private readonly ICardRepository _CardRepository;
    private readonly IRoleRepository _RoleRepository; 

    public CreateUserCommandHandler(IJwtTokenGenerator jwtTokenGenerator,IUserRepository userRepository,ICardRepository cardRepository, IRoleRepository roleRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _UserRepository = userRepository;  
        _CardRepository = cardRepository;   
        _RoleRepository = roleRepository;
    }
    public async Task<AuthenticationResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_UserRepository.GetByEmail(command.Email) is not null){
            throw new Exception("User with given email alredy exists");
        }

        List<Card> cards = new();

        command.Cards.ForEach(card =>
        {
            Card existingCard = _CardRepository.GetById(card.Id)!;
            if (existingCard is null)
            {
                throw new Exception($"Card '{card.Id}' does not exist in the database");
            }
            cards.Add(existingCard);
        });

        Role existingRole = _RoleRepository.GetByName(command.Role.Name)!;
        if (existingRole is null)
        {
            throw new Exception($"Role '{command.Role.Name}' does not exist in the database");
        }
        if(existingRole.Name == "SUPERADMIN"){
            throw new Exception("You cant create that kind of user");
        }

        User user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password,
            command.BirthDay,
            command.Points,
            existingRole.Id,
            existingRole,
            cards
        );

        _UserRepository.Insert(user);
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

}
