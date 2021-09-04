using SocialNetwork.Functionality.BusinessObjects;
using SocialNetwork.Functionality.Entities;
using SocialNetwork.Functionality.Exceptions;
using SocialNetwork.Functionality.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Functionality.Services
{
    public class PhotoService : IPhotoService
    {
        private IFunctionalityUnitOfWork _functionalityUnitOfWork;
        public PhotoService(IFunctionalityUnitOfWork functionalityUnitOfWork)
        {
            _functionalityUnitOfWork = functionalityUnitOfWork;
        }

        public void CreatePhoto(PhotoBO photo)
        {
            if (photo == null)
                throw new InvalidParameterException("photo info was not provided");

            var photoEntity = new Photo
            {
                MemberId = photo.MemberId,
                PhotoFileName = photo.PhotoFileName
            };

            _functionalityUnitOfWork.Photos.Add(photoEntity);

            _functionalityUnitOfWork.Save();
        }

        public (IList<PhotoBO> records, int total, int totalDisplay) GetAllPhotos(int pageIndex, int pageSize,
            string searchText, string sortText)
        {
            int srctxt = string.IsNullOrWhiteSpace(searchText) ? 0 : Convert.ToInt32(searchText[0]);
            var TypeConvertedSearchText = (string.IsNullOrWhiteSpace(searchText) == false && srctxt >= 49 &&
                                           srctxt <= 57) ? int.Parse(searchText) : 0;

            var photoData = _functionalityUnitOfWork.Photos.GetDynamic(string.IsNullOrWhiteSpace(searchText) ?
                null : x => x.MemberId == TypeConvertedSearchText, sortText, string.Empty, pageIndex, pageSize);

            var resultData = (from photo in photoData.data
                              select new PhotoBO
                              {
                                  Id = photo.Id,
                                  MemberId = photo.MemberId,
                                  PhotoFileName = "/images/" + photo.PhotoFileName
                              }).ToList();

            return (resultData, photoData.total, photoData.totalDisplay);
        }

        public PhotoBO GetPhotoForEdit(int id)
        {
            var photoMember = _functionalityUnitOfWork.Photos.GetById(id);
            var BusObjPhoto = new PhotoBO
            {
                Id = photoMember.Id,
                MemberId = photoMember.MemberId,
                PhotoFileName = "/images/" + photoMember.PhotoFileName
            };

            return BusObjPhoto;
        }

        public void UpdatePhoto(PhotoBO photoinfo)
        {
            if (photoinfo == null)
                throw new InvalidOperationException("photo is missing");

            var entityPhoto = _functionalityUnitOfWork.Photos.GetById(photoinfo.Id);

            if (entityPhoto != null)
            {
                entityPhoto.MemberId = photoinfo.MemberId;
                entityPhoto.PhotoFileName = photoinfo.PhotoFileName;

                _functionalityUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Couldn't find Photo");
        }

        public void DeletePhoto(int id)
        {
            _functionalityUnitOfWork.Photos.Remove(id);

            _functionalityUnitOfWork.Save();
        }

        public PhotoBO GetPhotoForDelete(int id)
        {
            var photoMember = _functionalityUnitOfWork.Photos.GetById(id);
            var BusObjPhoto = new PhotoBO
            {
                Id = photoMember.Id,
                MemberId = photoMember.MemberId,
                PhotoFileName = photoMember.PhotoFileName
            };

            return BusObjPhoto;
        }
    }
}
