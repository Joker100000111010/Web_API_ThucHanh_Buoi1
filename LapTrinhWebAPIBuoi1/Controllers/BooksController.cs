            using Humanizer.Localisation;
            using LapTrinhWebAPIBuoi1.Data;
            using LapTrinhWebAPIBuoi1.Models.Domain;
            using LapTrinhWebAPIBuoi1.Models.DTO;
             using LapTrinhWebAPIBuoi1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
            using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

            namespace LapTrinhWebAPIBuoi1.Controllers
            {
                [ApiController]
                [Route("api/[controller]")]
                public class BooksController : ControllerBase
                {
                   // private readonly IBookstoreServices _BookService;
                   // private readonly ILogger<BooksController> _logger; // Inject ILogger
                   private readonly IBookRepository _bookRepository;
                    
                    public BooksController( IBookRepository bookRepository)
                    {
                    
                     _bookRepository = bookRepository;
                   // _BookService = BookService;
                   //_logger = logger; // Inject ILogger
                    }
            [HttpGet("get-all-books")]
            public IActionResult GetAll()
            {
                var allBooks = _bookRepository.GetAllBooks();
                return Ok(allBooks);
            }
            [HttpGet]
            [Route("get-book-by-id/{id}")]
            public IActionResult GetBookById([FromRoute]int id) 
            {
                var bookWithIdDTO =_bookRepository.GetBookById(id);
                return  Ok(bookWithIdDTO);
            }
        [HttpPost ("and-book")]
       // [ValidateModel]
        [Authorize(Roles = "Write")]
        public IActionResult AddBook([FromBody] AddBookRequestDTO addBookRequestDTO)
        {
            if (ModelState.IsValid)
            {
                var bookAdd = _bookRepository.AddBook(addBookRequestDTO);
                return Ok(bookAdd);
            }
            else return BadRequest(ModelState);
        }

        /*[HttpPost("add-book")]
        public IActionResult AddBook([FromBody] AddBookRequestDTO addBookRequestDTO) 
        { 
            var bookAdd =_bookRepository.AddBook(addBookRequestDTO);
            return Ok(bookAdd);
        } */
        [HttpPut("update-book-by-id/{id}")]
            public IActionResult UpdateBookById(int id, [FromBody]AddBookRequestDTO bookDTO) 
            {
                var updateBook = _bookRepository.UpdateBookById(id, bookDTO);
                return Ok(updateBook);
            }

            [HttpDelete("delete-book-by-id/{id}")]
            public IActionResult DeleteBookById(int id)
            {
                var deleteBook= _bookRepository.DeleteBookById(id);
                return Ok(deleteBook);
            }

   
        }
    }
