

using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Queries.Publisher.GetByIdPublisher
{
    public class GetByIdPublisherQueryHandler : IRequestHandler<GetByIdPublisheQueryRequest, GetByIdPublisherQueryResponse>
    {
        private readonly IPublisherReadRepository publisherReadRepository;
        public GetByIdPublisherQueryHandler(IPublisherReadRepository publisherReadRepository)
        {
            this.publisherReadRepository = publisherReadRepository;
        }


        public async Task<GetByIdPublisherQueryResponse> Handle(GetByIdPublisheQueryRequest request, CancellationToken cancellationToken)
        {
            PublisherDto? publisherDto = await publisherReadRepository.GetPublisherDtosAsync(request.Id);
            if (publisherDto == null)
            {
                return new GetByIdPublisherQueryResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = Messages.IdNull
                    }
                };
            }
            

            return new GetByIdPublisherQueryResponse
            {
                PublisherDto = publisherDto,
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = false,
                    Message = Messages.SuccessGetFiltered
                }
            };
        }
    }
}
