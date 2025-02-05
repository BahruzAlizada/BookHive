using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Queries.Book.GetBookStatistic
{
    public class GetBookStatisticQueryResponse
    {
        public BookStatisticDto? BookStatisticDto { get; set; }
        public Result Result { get; set; }
    }
}