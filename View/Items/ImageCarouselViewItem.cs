using System;
using System.Configuration;
using TadManagementTool.Model;

namespace TadManagementTool.View.Items
{
    public class ImageCarouselViewItem
    {
        private readonly Uri serverBaseUrl;

        public CarouselImage Wrapper { get; private set; }
        public bool IsSelected { get; private set; }
        
        public Uri ImageUrl 
        { 
            get 
            {
                return new Uri(string.Format("http://{0}/images/app/{1}", serverBaseUrl.Host, Wrapper.Name));
            }
        }

        public ImageCarouselViewItem(CarouselImage carouselImage)
        {
            Wrapper = carouselImage;
            this.serverBaseUrl = new Uri(ConfigurationManager.AppSettings["tad.server"]);
        }

        public void Select()
        {
            IsSelected = true;
        }

        public void Unselect()
        {
            IsSelected = false;
        }

        public override bool Equals(object obj)
        {
            var other = obj as ImageCarouselViewItem;
            return other != null && Wrapper.Equals(other.Wrapper);
        }

        public override int GetHashCode()
        {
            return Wrapper.GetHashCode();
        }
    }
}
