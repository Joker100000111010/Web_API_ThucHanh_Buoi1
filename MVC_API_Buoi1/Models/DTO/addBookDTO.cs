using System.ComponentModel.DataAnnotations;

namespace MVC_API_Buoi1.Models.DTO
{
    public class addBookDTO
    {
        public string Title { get; set; }
        public string? description { get; set; }
        public bool? IsRead { get; set; }
        public DateTime? dateRead { get; set; }
        [Range(0,5 ,ErrorMessage="From 0 to 5 ")]
        public int? rate { get; set; }
        public string? genre { get; set; }
        public string ? coverUrl { get; set; }
        public DateTime dateAdded { get; set; }
        public int publisherID { get; set; }
        public List<int> authorIds { get; set; } 
    }
}
