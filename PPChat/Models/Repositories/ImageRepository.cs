using PPChat.Data;
using PPChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPChat.Models
{
    public class ImageRepository : IImageRepository
    {
        private ApplicationDbContext _applicationDbContext;

        public ImageRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void CreateImage(Image image)
        {
            _applicationDbContext.Add(image);
            _applicationDbContext.SaveChanges();
        }

        public Image GetImageByName(string name)
        {
            return _applicationDbContext.Images.FirstOrDefault(c => c.ImageName.Equals(name));
        }
    }
}
