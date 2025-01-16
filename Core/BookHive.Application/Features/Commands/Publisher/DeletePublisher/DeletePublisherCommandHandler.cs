﻿

using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using MediatR;

namespace BookHive.Application.Features.Commands.Publisher.DeletePublisher
{
    public class DeletePublisherCommandHandler : IRequestHandler<DeletePublisherCommandRequest, DeletePublisherCommandResponse>
    {
        private readonly IPublisherReadRepository publisherReadRepository;
        private readonly IPublisherWriteRepository publisherWriteRepository;
        public DeletePublisherCommandHandler(IPublisherReadRepository publisherReadRepository, IPublisherWriteRepository publisherWriteRepository)
        {
            this.publisherReadRepository = publisherReadRepository;
            this.publisherWriteRepository = publisherWriteRepository;
        }


        public async Task<DeletePublisherCommandResponse> Handle(DeletePublisherCommandRequest request, CancellationToken cancellationToken)
        {
            BookHive.Domain.Entities.Publisher? publisher = await publisherReadRepository.GetSingleAsync(x=>x.Id == request.Id);
            if (publisher is null)
            {
                return new DeletePublisherCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = Messages.IdNull
                    }
                };
            }

            publisherWriteRepository.Remove(publisher);
            await publisherWriteRepository.SaveAsync();

            return new DeletePublisherCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessDeleted
                }
            };
        }
    }
}
