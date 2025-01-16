using AutoMapper;
using BookHive.Application.DTOs;
using BookHive.Application.DTOs;
using BookHive.Application.DTOs.Category;
using BookHive.Domain.Entities;
using BookHive.Domain.Identity;

namespace BookHive.Application.Mappers.AutoMapper
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<Category,CategoryAddDto>().ReverseMap();
            CreateMap<Category,CategoryUpdateDto>().ReverseMap();
            CreateMap<Category,CategoryDto>().ReverseMap();

            CreateMap<BookStatus,BookStatusAddDto>().ReverseMap();
            CreateMap<BookStatus, BookStatusUpdateDto>().ReverseMap();
            CreateMap<BookStatus, BookStatusDto>().ReverseMap();

            CreateMap<BookLanguage,BookLanguageAddDto>().ReverseMap();
            CreateMap<BookLanguage,BookLanguageUpdateDto>().ReverseMap();
            CreateMap<BookLanguage,BookLanguageDto>().ReverseMap();

            CreateMap<Publisher,PublisherAddDto>().ReverseMap();
            CreateMap<Publisher, PublisherUpdateDto>().ReverseMap();

            CreateMap<Genre,GenreAddDto>().ReverseMap();
            CreateMap<Genre,GenreUpdateDto>().ReverseMap();

            CreateMap<Author,AuthorAddDto>().ReverseMap();
            CreateMap<Author,AuthorUpdateDto>().ReverseMap();

            CreateMap<Book,BookAddDto>().ReverseMap();
            CreateMap<Book,BookUpdateDto>().ReverseMap();

            CreateMap<AppUser,UserDto>().ReverseMap();

            CreateMap<AppRole,RoleAddDto>().ReverseMap();
            CreateMap<AppRole,RoleUpdateDto>().ReverseMap();
            CreateMap<AppRole,RoleDto>().ReverseMap();
        }
    }
}
