using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPChat.Models
{
    public interface IImageRepository
    {
        Image GetImageByName(string name);
        void CreateImage(Image image);
    }
}
