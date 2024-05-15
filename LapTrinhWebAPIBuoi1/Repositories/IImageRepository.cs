using LapTrinhWebAPIBuoi1.Models;

namespace LapTrinhWebAPIBuoi1.Repositories
{
    public interface IImageRepository
    {
        CustomImage UpLoad(CustomImage image);
        List<CustomImage> GetAllInfoImages();
        (byte[], string, string) DownloadFile(int Id);
    }
}
