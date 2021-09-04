using SocialNetwork.Functionality.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Functionality.Services
{
    public interface IPhotoService
    {
        void CreatePhoto(PhotoBO photo);
        (IList<PhotoBO> records, int total, int totalDisplay) GetAllPhotos(int pageIndex,
            int pageSize, string searchText, string sortText);
        PhotoBO GetPhotoForEdit(int id);
        void UpdatePhoto(PhotoBO photoinfo);
        void DeletePhoto(int id);
        PhotoBO GetPhotoForDelete(int id);
    }
}
