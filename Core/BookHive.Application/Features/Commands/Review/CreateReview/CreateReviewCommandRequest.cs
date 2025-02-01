using BookHive.Application.DTOs.Review;
using MediatR;

namespace BookHive.Application.Features.Commands.Review.CreateReview
{
    public class CreateReviewCommandRequest : IRequest<CreateReviewCommandResponse>
    {
        public ReviewAddDto ReviewAddDto { get; set; }
    }
}