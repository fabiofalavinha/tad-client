using Spring.Http;
using System;
using System.Collections.Generic;
using System.IO;
using TadManagementTool.Model;

namespace TadManagementTool.Service
{
    public class CarouselImageService : AbstractService
    {
        private const int MaxFileSizeInBytes = 1048576;

        public IList<CarouselImage> GetImages()
        {
            return restTemplate.GetForObject<IList<CarouselImage>>("/carousel");
        }

        public void UploadImages(IList<FileInfo> selectedImageFiles)
        {
            foreach (var imageFileInfo in selectedImageFiles)
            {
                if (imageFileInfo.Length > MaxFileSizeInBytes)
                {
                    throw new ArgumentException(string.Format("A imagem [{0}] ultrapassou o tamanho máximo de [{1}]", imageFileInfo.Name, (MaxFileSizeInBytes / (1<<20)).ToString("# MB")));
                }
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
