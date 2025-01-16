using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Persistence.Context;
using BookHive.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Persistence.Concrete
{
    public class PublisherReadRepository : ReadRepository<BookHive.Domain.Entities.Publisher>, IPublisherReadRepository
    {
        private readonly AppDbContext context;
        public PublisherReadRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<PublisherDto>> GetPublisherDtosAsync()
        {
            List<BookHive.Domain.Entities.Publisher> publishers = await context.Publishers.OrderByDescending(x => x.Id).ToListAsync();
            List<PublisherDto> publisherDtos = new List<PublisherDto>();

            foreach (var publisher in publishers)
            {
                PublisherDto dto = new PublisherDto
                {
                    Id = publisher.Id,
                    Name = publisher.Name,
                    Address = publisher.Address,
                    ContactNumber = publisher.ContactNumber,
                    Status = publisher.Status,
                    BookCount = await context.Books.Where(x => x.PublisherId == publisher.Id).CountAsync()
                };
                publisherDtos.Add(dto);
            }

            return publisherDtos;
        }

        public async Task<PublisherDto> GetPublisherDtosAsync(Guid Id)
        {
            BookHive.Domain.Entities.Publisher? publisher = await context.Publishers.FirstOrDefaultAsync(x=> x.Id == Id);
            if (publisher == null)
                return null;
           

            PublisherDto publisherDto = new PublisherDto
            {
                Id = publisher.Id,
                Name = publisher.Name,
                Address = publisher.Address,
                ContactNumber = publisher.ContactNumber,
                Status = publisher.Status,
                BookCount = await context.Books.Where(x => x.PublisherId == publisher.Id).CountAsync()
            };

            return publisherDto;
        }
    }
}
