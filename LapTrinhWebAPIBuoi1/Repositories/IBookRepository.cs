using LapTrinhWebAPIBuoi1.Models.Domain;
using LapTrinhWebAPIBuoi1.Models.DTO;

namespace LapTrinhWebAPIBuoi1.Repositories
{
    public interface IBookRepository
    {
        List<BookWithAuthorAndPublisherDTO> GetAllBooks();
        BookWithAuthorAndPublisherDTO GetBookById(int id);
        AddBookRequestDTO AddBook(AddBookRequestDTO addBookRequestDTO);
        AddBookRequestDTO? UpdateBookById(int id, AddBookRequestDTO bookDTO);
        Books? DeleteBookById(int id);
   
    }
}
