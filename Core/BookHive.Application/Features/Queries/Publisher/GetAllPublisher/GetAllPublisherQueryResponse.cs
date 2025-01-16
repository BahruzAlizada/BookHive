

using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Queries.Publisher.GetAllPublisher
{
    public class GetAllPublisherQueryResponse
    {
        public List<PublisherDto> PublisherDtos { get; set; }
        public Result Result { get; set; }
    }
}
