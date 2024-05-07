using static LapTrinhWebAPIBuoi1.Models.DTO.PublishersDTO;
using System.Security.Policy;
using LapTrinhWebAPIBuoi1.Models.DTO;

namespace LapTrinhWebAPIBuoi1.Repositories
{
    public interface IPublisherRepository
    {
        List<PublisherDTO> GetAllPublishers();
        PublisherNoIdDTO GetPublisherById(int id);
        AddPublishers AddPublisher(AddPublishers addPublisherRequestDTO);
        PublisherNoIdDTO UpdatePublisherById(int id, PublisherNoIdDTO publisherNoIdDTO);
        Publisher? DeletePublisherById(int id);
    }
}

