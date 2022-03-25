using AdminPannelApp.Models;
using AdminPannelApp.Repository.Interface;
using AdminPannelApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPannelApp.Repository.Services
{
    
    public class BookService: GenericInterface<BookWithAuthorViewModel>,IBook
    {
        private AppDbContext dbContext;
        public BookService()
        {
            dbContext = new AppDbContext();
        }
        public List<BookWithAuthorViewModel> GetData()
        {
            var books = (from book in dbContext.Books
                         join
                         author in dbContext.Authors
                         on book.Author_Id equals author.Id
                         select new BookWithAuthorViewModel()
                         {
                             Id = book.Id,
                             Title = book.Title,
                             Price = book.Price,
                             Quantity = book.Quantity,
                             Published_On = book.Published_On,
                             AuthorName = author.Name,
                             AuthorEMail = author.Email,
                             AuthorMobile = author.Mobile

                         }).ToList();

            return books;
        }

        public bool DeleteBook(int id)
        {
            var book = dbContext.Books.SingleOrDefault(e => e.Id == id);
            if (book != null)
            {
                dbContext.Books.Remove(book);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }



    }
}
