using System.Collections.Generic;
using TadManagementTool.Model;

namespace TadManagementTool.Service
{
    public class CarouselImageService : AbstractService
    {
        public IList<CarouselImage> GetImages()
        {
            return restTemplate.GetForObject<IList<CarouselImage>>("/carousel");
        }
    }
}
