namespace LapTrinhWebAPIBuoi1.Models.DTO
{
    public interface IImageRepository
    {
        Image UpLoad(Image image);
        List<Image> GetAllInfoImages();
        (byte[], string, string) DownloadFile(int Id);
    }
}
