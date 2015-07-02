using System;
using System.Configuration;
using TadManagementTool.Model;

namespace TadManagementTool.View.Items
{
    public class ImageCarouselViewItem
    {
        private readonly string serverBaseUrl;

        public CarouselImage Wrapper { get; private set; }
        
        public Uri ImageUrl 
        { 
            get 
            {
                var baseUrl = new Uri(serverBaseUrl);
                return new Uri(string.Format("http://{0}:3000/images/{1}", baseUrl.Host, Wrapper.Name));
            }
        }

        public ImageCarouselViewItem(CarouselImage carouselImage)
        {
            Wrapper = carouselImage;
            this.serverBaseUrl = ConfigurationManager.AppSettings["tad.server"];
        }
    }
}
