using BookHive.Application.Abstracts.Services;
using BookHive.Application.DTOs;
using BookHive.Application.DTOs.Discount;
using BookHive.Domain.Entities;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Persistence.Services.EntityFramework
{
    public class DiscountWriteRepository : WriteRepository<BookDiscount>, IDiscountWriteRepository
    {
        private readonly Context context;
        public DiscountWriteRepository(Context context) : base(context)
        {
            this.context = context;
        }

        private double CalculateDiscount(double price, int discountPercentage)
        {
                return price - (price * discountPercentage / 100);
        }


        public async Task DiscountApplyGenre(DiscountGenreDto discountGenreDto)
        {
            Genre? genre = await context.Genres.Include(x=>x.Books).FirstOrDefaultAsync(x=>x.Id==discountGenreDto.GenreId);
            foreach (var book in genre.Books)
            {
                book.DiscountPrice =  CalculateDiscount(book.Price, discountGenreDto.DiscountPercentage);
                context.Books.Update(book);
            }
            BookDiscount bookDiscount = new BookDiscount
            {
                GenreId = discountGenreDto.GenreId,
                DiscountPercentage = discountGenreDto.DiscountPercentage,
                IsDiscount = true
            };
            await context.BookDiscounts.AddAsync(bookDiscount);
            await context.SaveChangesAsync();   
        }

        public async Task DiscountApplyBook(DiscountBookDto discountBookDto)
        {
            Book? book = await context.Books.FindAsync(discountBookDto.BookId);

            book.DiscountPrice = CalculateDiscount(book.Price, discountBookDto.DiscountPercentage);
            context.Books.Update(book);
            BookDiscount bookDiscount = new BookDiscount
            {
                BookId = discountBookDto.BookId,
                DiscountPercentage = discountBookDto.DiscountPercentage,
                IsDiscount = true
            };
            await context.BookDiscounts.AddAsync(bookDiscount);
            await context.SaveChangesAsync();
        }
    }
}
