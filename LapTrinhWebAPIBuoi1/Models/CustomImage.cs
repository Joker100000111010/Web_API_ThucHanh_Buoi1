using System.ComponentModel.DataAnnotations.Schema;
namespace LapTrinhWebAPIBuoi1.Models
{
    public class CustomImage
    {
        public int Id { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
        public string? FileExtensison { get; set; }
        public long FileSizeInBytes { get; set; }
        public string FilePath { get; set; }


    }
}
