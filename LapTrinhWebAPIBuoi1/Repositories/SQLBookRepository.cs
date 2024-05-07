using LapTrinhWebAPIBuoi1.Data;
using LapTrinhWebAPIBuoi1.Models.Domain;
using LapTrinhWebAPIBuoi1.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace LapTrinhWebAPIBuoi1.Repositories
{
    public class SQLBookRepository : IBookRepository
    {
        private readonly AppDbContext _dbContext;
        public SQLBookRepository (AppDbContext dpContext)
        {
            _dbContext = dpContext;
        }
        public List<BookWithAuthorAndPublisherDTO> GetAllBooks()
        {
            var allBooksDTO = _dbContext.Books.Select(book => new BookWithAuthorAndPublisherDTO
                {
                    Id = book.BooksId,
                    Title = book.Title,
                    Description = book.Description,
                    IsRead = book.IsRead,
                    DateRead = book.IsRead && book.DateRead != null ? book.DateRead : null,
                    Rate = book.IsRead ? book.Rate : null,
                    Genre = book.Genre,
                    CoverUrl = book.CoverUrl,
                    PublisherName = book.Publishers.Name,
                    AuthorName = book.Book_Authors.Select(n => n.Authors.FullName).ToList(),
                }).ToList();
            return allBooksDTO;
        }

        public BookWithAuthorAndPublisherDTO GetBookById(int id)
        {
            var bookWithDomain = _dbContext.Books.Where(n => n.BooksId == id);
            //Map Domain Model to DTOs
            var bookWithIdDTO = bookWithDomain.Select(book => new BookWithAuthorAndPublisherDTO()
            {
                Id = book.BooksId,
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publishers.Name,
                AuthorName = book.Book_Authors.Select(n => n.Authors.FullName).ToList()
            }).FirstOrDefault();
            return bookWithIdDTO;
        }

    public AddBookRequestDTO AddBook(AddBookRequestDTO addBookRequestDTO)
    {
            var bookDomainModel = new Books
            {
                Title = addBookRequestDTO.Title,
                Description = addBookRequestDTO.Description,
                IsRead = addBookRequestDTO.IsRead,
                DateRead = addBookRequestDTO.DateReaad,
                Rate = addBookRequestDTO.Rate,
                Genre = addBookRequestDTO.Genre,
                CoverUrl = addBookRequestDTO.CoverUrl,
                DateAdded = addBookRequestDTO.DateAdded,
                PublishersId = addBookRequestDTO.PublisherID
            };
            _dbContext.Books.Add(bookDomainModel);
            _dbContext.SaveChanges();
            foreach (var id in addBookRequestDTO.AuthorIds)
            {   
                var _book_author = new Book_Author()
                {
                    BooksId = bookDomainModel.BooksId,
                    AuthorsId = id
                };
                _dbContext.Books_Author.Add(_book_author);
                _dbContext.SaveChanges();
            }
            return addBookRequestDTO;
    }


        public AddBookRequestDTO? UpdateBookById(int id,AddBookRequestDTO bookDTO)
        {
            var bookDomain = _dbContext.Books.FirstOrDefault(n => n.BooksId == id);
                if(bookDomain != null)
            {
                bookDomain.Title = bookDTO.Title;
                bookDomain.Description = bookDTO.Description;
                bookDomain.IsRead = bookDTO.IsRead;
                bookDomain.DateRead = bookDTO.DateReaad;
                bookDomain.Rate = bookDTO.Rate;
                bookDomain.Genre = bookDTO.Genre;
                bookDomain.CoverUrl = bookDTO.CoverUrl;
                bookDomain.DateAdded = bookDTO.DateAdded;
                bookDomain.PublishersId = bookDTO.PublisherID;
            }
            var existingAuthors = _dbContext.Books_Author.Where(a => a.BooksId == id).ToList();
            _dbContext.Books_Author.RemoveRange(existingAuthors);

            foreach (var authorId in bookDTO.AuthorIds)
            {
                var _book_author = new Book_Author
                {
                    BooksId = id,
                    AuthorsId = authorId
                };
                _dbContext.Books_Author.Add(_book_author);
            }
            _dbContext.SaveChanges();
            return bookDTO;
        }

        public Books? DeleteBookById(int id)
        {
            var bookDomain = _dbContext.Books.FirstOrDefault(n => n.BooksId == id);
            if(bookDomain != null)
            {
                _dbContext.Books.Remove(bookDomain);
                _dbContext.SaveChanges();
            }
            return bookDomain;
        }
    }
}
