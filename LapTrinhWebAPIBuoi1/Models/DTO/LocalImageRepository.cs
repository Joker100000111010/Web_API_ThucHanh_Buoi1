using LapTrinhWebAPIBuoi1.Data;

namespace LapTrinhWebAPIBuoi1.Models.DTO
{
    public class LocalImageRepository: IImageRepository
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
        public Image Upload(Image image)
        {
            var local
        }
    }
}
