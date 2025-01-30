
using BookHive.Application.DTOs;
using BookHive.Domain.Entities;
using Mapster;

namespace BookHive.Application.Mappers.Mapster
{
    public class MapsterMapper
    {
        public MapsterMapper()
        {
            TypeAdapterConfig<Book, BookAddDto>.NewConfig().TwoWays();
        }
    } 
}
