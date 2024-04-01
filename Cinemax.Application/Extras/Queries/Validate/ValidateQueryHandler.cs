
using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.PaymentType.Entities;
using Cinemax.Domain.PaymentType.ValueObjects;
using Cinemax.Domain.User.Entities;
using Cinemax.Domain.User.ValueObjects;
using MediatR;

namespace Cinemax.Application.Extras.Queries.Validate;
public class ValidateQueryHandler : IRequestHandler<ValidateQuery, string>
{
    private readonly IUserRepository _UserRepository; 
    private readonly IPaymentTypeRepository _paymentRepository;

    public ValidateQueryHandler(IUserRepository UserRepository, IPaymentTypeRepository paymentTypeRepository)
    {
        _UserRepository = UserRepository;    
        _paymentRepository = paymentTypeRepository;
    }
    public async Task<string> Handle(ValidateQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if( _UserRepository.GetById(UserId.Create(new(query.UserId))) is not User user){
            throw new Exception("user does not exists");
        }

        if( _paymentRepository.GetById(PaymentTypeId.Create(new(query.idPaymentType))) is not PaymentType paymentType){
            throw new Exception("payment type does not exists");
        }

        if(paymentType.Name == "PUNTOS" && user.Points < query.Cant * 20){
            throw new Exception("not points enough");
        }


        return "ok";
    }
}
