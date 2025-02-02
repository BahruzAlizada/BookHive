using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.Parametres.ResponseParametres;
using MediatR;

namespace BookHive.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IOrderWriteRepository orderWriteRepository;
        public CreateOrderCommandHandler(IOrderWriteRepository orderWriteRepository)
        {
            this.orderWriteRepository = orderWriteRepository;
        }


        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            await orderWriteRepository.CreateOrder();
            return new() { Result = new SuccessResult(Messages.SuccessAdded) };
        }
    }
}
