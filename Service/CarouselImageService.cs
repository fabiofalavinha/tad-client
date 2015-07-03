using Spring.Http;
using System.Collections.Generic;
using System.IO;
using TadManagementTool.Model;

namespace TadManagementTool.Service
{
    public class CarouselImageService : AbstractService
    {
        public IList<CarouselImage> GetImages()
        {
            return restTemplate.GetForObject<IList<CarouselImage>>("/carousel");
        }

        public void UploadImages(IList<FileInfo> selectedImageFiles)
        {
            foreach (var imageFileInfo in selectedImageFiles)
            {
                var parts = new Dictionary<string, object>();
                var entity = new HttpEntity(imageFileInfo);
                entity.Headers["Content-Type"] = string.Format("image/{0}", imageFileInfo.Extension.Replace(".", ""));
                parts.Add("file", entity);
                restTemplate.PostForLocation("/upload", parts);
            }
        }

        public void RemoveImage(CarouselImage carouselImage)
        {
            restTemplate.Delete("/carousel/{name}", carouselImage.Name);
        }
    }
}
