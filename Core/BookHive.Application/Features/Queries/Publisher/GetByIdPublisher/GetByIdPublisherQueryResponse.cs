using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Queries.Publisher.GetByIdPublisher
{
    public class GetByIdPublisherQueryResponse
    {
        public PublisherDto? PublisherDto { get; set; }
        public Result Result { get; set; }
    }
}
