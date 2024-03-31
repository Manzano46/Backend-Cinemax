using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Users.Common;
using Cinemax.Domain.User.Entities;
using Cinemax.Domain.ProjectionAggregate.Entities;
using MediatR;

namespace Cinemax.Application.Users.Commands.Create;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserResult>
{
    private readonly IUserRepository _UserRepository; 
    private readonly ICardRepository _CardRepository;

    public CreateUserCommandHandler(IUserRepository userRepository,ICardRepository cardRepository)
    {
        _UserRepository = userRepository;  
        _CardRepository = cardRepository;   
    }
    public async Task<UserResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_UserRepository.GetById(command.Id) is not null){
            throw new Exception("User with given id alredy exists");
        }

        List<Card> cards = new();

        command.Cards.ForEach(card =>
        {
            Card existingCard = _CardRepository.GetByName(card.Name)!;
            if (existingCard is null)
            {
                throw new Exception($"Card '{card.Name}' does not exist in the database");
            }
            cards.Add(existingCard);
        });

        User user = User.Create(
            command.Email,
            command.Password,
            command.BirthDay,
            command.Name,
            command.Points,
            command.Role,
            cards
        );

        _UserRepository.Add(user);

        return new UserResult(user);
    }

}
