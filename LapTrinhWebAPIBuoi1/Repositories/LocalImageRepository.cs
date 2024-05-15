using LapTrinhWebAPIBuoi1.Data;
using LapTrinhWebAPIBuoi1.Models;

namespace LapTrinhWebAPIBuoi1.Repositories
{
    public class LocalImageRepository 
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _dbContext;
        public LocalImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, AppDbContext dbContext)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
        }
        // https://localhost:8080/images/image.jpg
        public CustomImage Upload(CustomImage image)
        {
            var loaclFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", $"{image.FileName}{image.FileExtensison}");
            using var stream = new FileStream(loaclFilePath, FileMode.Create);
            image.File.CopyTo(stream);
            var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtensison}";
            image.FilePath = urlFilePath;
            //
            _dbContext.Images.Add(image);
            _dbContext.SaveChanges();
            return image;
        }
        public List<CustomImage> GetAllInfoImages()
        {
            var allImages = _dbContext.Images.ToList();
            return allImages;
        }
        public (byte[], string, string) DownloadFile(int Id)
        {
            try
            {
                var FileById = _dbContext.Images.Where(x => x.Id == Id).FirstOrDefault();
                var path = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", $"{FileById.FileName}{FileById.FileExtensison}");
                var stream = File.ReadAllBytes(path);
                var fileName = FileById.FileName + FileById.FileExtensison;
                return (stream, "application/octer-stream", fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        } 
    }
}
