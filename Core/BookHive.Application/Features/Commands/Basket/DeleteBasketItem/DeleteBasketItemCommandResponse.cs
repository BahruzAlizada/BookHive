using BookHive.Application.Parametres.ResponseParametres;
using Microsoft.AspNetCore.Http;

namespace BookHive.Application.Features.Commands.Basket.DeleteBasketItem
{
    public class DeleteBasketItemCommandResponse
    {
        public Result Result { get; set; }
    }
}