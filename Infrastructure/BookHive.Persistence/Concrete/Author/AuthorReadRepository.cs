using BookHive.Application.Abstracts.Services;
using BookHive.Application.DTOs;
using BookHive.Domain.Entities;
using BookHive.Persistence.Context;
using BookHive.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Persistence.Concrete
{
    public class AuthorReadRepository : ReadRepository<Author>, IAuthorReadRepository
    {
        private readonly AppDbContext context;
        public AuthorReadRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<AuthorDto> GetAuthorDtoAsync(Guid id)
        {
            Author? author = await context.Authors.FirstOrDefaultAsync(c => c.Id == id);
            if (author == null)
                return null;

            AuthorDto authorDto = new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                Bio = author.Bio,
                ProfilePictureUrl = author.ProfilePictureUrl,
                Status = author.Status,
                BookCount = await context.Books.Where(x => x.AuthorId == author.Id).CountAsync()
            };

            return authorDto;
        }

        public async Task<List<AuthorDto>> GetAuthorDtosAsync()
        {
            List<Author> authors = await context.Authors.ToListAsync();
            List<AuthorDto> authorDtos = new List<AuthorDto>();

            foreach (var author in authors)
            {
                AuthorDto dto = new AuthorDto
                {
                    Id = author.Id,
                    Name = author.Name,
                    Bio = author.Bio,
                    ProfilePictureUrl = author.ProfilePictureUrl,
                    Status = author.Status,
                    BookCount = await context.Books.Where(x => x.AuthorId == author.Id).CountAsync()
                };
                authorDtos.Add(dto);
            }

            return authorDtos;
        }
    }
}
