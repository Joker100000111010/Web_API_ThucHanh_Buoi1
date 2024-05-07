using LapTrinhWebAPIBuoi1.Models.Domain;
using LapTrinhWebAPIBuoi1.Models.DTO;

namespace LapTrinhWebAPIBuoi1.Repositories
{
    public interface IAuthorRepository
    {
        List<AuthorDTO> GellAllAuthors();
        AuthorNoIdDTO GetAuthorById(int id);
        AddAuthorRequestDTO AddAuthor(AddAuthorRequestDTO addAuthorRequestDTO);
        AuthorNoIdDTO UpdateAuthorById(int id, AuthorNoIdDTO authorNoIdDTO);
        Authors? DeleteAuthorById(int id);

    }
}
